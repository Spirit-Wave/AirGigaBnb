using GigaBnB.Business.DTOs;
using GigaBnB.DataAccess.Repository.IRepository;
using GigaBnB.Model.Models;

namespace GigaBnB.Business.Validation;

public class LoginUserValidator : BaseValidator, IValidator<LoginDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public LoginUserValidator(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public async Task<bool> Validate(LoginDto value)
    {
        var user = await _unitOfWork.User.GetAsync(u => u.Email == value.Email);
        if (user is null)
        {
            AddError(nameof(User.Email), "Invalid Email");
            return false;
        }

        if (user.Password == value.Password) return true;
        AddError(nameof(User.Password), "Invalid Password");
        return false;
    }
}