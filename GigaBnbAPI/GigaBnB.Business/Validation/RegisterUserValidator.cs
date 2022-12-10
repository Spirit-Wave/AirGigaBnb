using System.Text.RegularExpressions;
using GigaBnB.Business.DTOs;
using GigaBnB.Business.Utility;
using GigaBnB.DataAccess.Repository.IRepository;
using GigaBnB.Model.Enum;
using GigaBnB.Model.Models;
using Microsoft.IdentityModel.Tokens;

namespace GigaBnB.Business.Validation;

public class RegisterUserValidator : BaseValidator, IValidator<RegisterDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public RegisterUserValidator(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public async Task<bool> Validate(RegisterDto value)
    {
        if (value.Role == UserRole.Lessee)
        {
            await ValidateLessee(value);
        }
        else
        {
            await ValidateLessor(value);
        }

        return Errors.IsNullOrEmpty();
    }

    private async Task ValidateLessee(RegisterDto register)
    {
        await ValidateEmail(register.Email);
        ValidatePassword(register.Password, register.ConfirmPassword);
    }

    private async Task ValidateLessor(RegisterDto register)
    {
        await ValidateEmail(register.Email);
        ValidatePassword(register.Password, register.ConfirmPassword);
    }

    private void ValidatePassword(string userPassword, string confirmPassword)
    {
        if (userPassword != confirmPassword)
        {
            AddError(nameof(User.Password), "Password does not match confirm password");
        }

        if (userPassword.Length < 8)
        {
            AddError(nameof(User.Password), "Password must contain 8 or more characters");
        }

        var rg = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{1,}$");
        if (!rg.IsMatch(userPassword))
        {
            AddError(nameof(User.Password), "Password must contain at least one uppercase letter, one lowercase letter, one number and one special character");
        }
    }

    private async Task ValidateEmail(string userEmail)
    {
        ValidateEmailFormat(userEmail);
        await ValidateIsEmailTaken(userEmail);
    }

    private async Task ValidateIsEmailTaken(string email)
    {
        var duplicateUser = await _unitOfWork.User.GetAsync(u => u.Email == email);
        if (duplicateUser is null) return;
        AddError(nameof(User.Email), "Specified email is already taken");
    }

    private void ValidateEmailFormat(string userEmail)
    {
        if (!DataMatcher.MatchEmail(userEmail)) return;
        AddError(nameof(User.Email), "Invalid email format");
    }
}