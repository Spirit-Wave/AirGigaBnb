using GigaBnB.Business.DTOs;
using GigaBnB.Business.Exceptions;
using GigaBnB.Business.Services.IServices;
using GigaBnB.Business.Utility;
using GigaBnB.Business.Validation;
using GigaBnB.DataAccess.Repository.IRepository;
using GigaBnB.Model.Enum;
using GigaBnB.Model.Models;


namespace GigaBnB.Business.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<LoginDto> _loginValidator;
    private readonly IValidator<RegisterDto> _registerValidator;

    public UserService(IUnitOfWork unitOfWork, IValidator<LoginDto> loginValidator,
        IValidator<RegisterDto> registerValidator)
    {
        this._unitOfWork = unitOfWork;
        this._loginValidator = loginValidator;
        this._registerValidator = registerValidator;
    }

    public async Task<Result<User>> RegisterClient(RegisterDto register)
    {
        if (!await _registerValidator.Validate(register)) return new Result<User>(new ValidationException(_registerValidator.Errors));
        var userCreated = new User()
        {
            Name = register.Name,
            Email = register.Email,
            Password = register.Password,
            DateCreated = DateTime.Now,
            DateUpdated = DateTime.Now,
            PhoneNumber = register.PhoneNumber,
            Description = register.Description,
            Role = register.Role,
        };
        _unitOfWork.User.Add(userCreated);
        await _unitOfWork.SaveAsync();
        return userCreated;
    }

    public async Task<Result<User>> RegisterWorker(RegisterDto register)
    {
        if (!await _registerValidator.Validate(register))
            return new Result<User>(new ValidationException(_registerValidator.Errors));
        var userCreated = new User()
        {
            Name = register.Name,
            Email = register.Email,
            Password = register.Password,
            DateCreated = DateTime.Now,
            DateUpdated = DateTime.Now,
            PhoneNumber = register.PhoneNumber,
            Description = register.Description,
            Role = UserRole.Worker
        };
        _unitOfWork.User.Add(userCreated);
        await _unitOfWork.SaveAsync();
        return userCreated;
    }

    public async Task<Result<User?>> LoginUser(LoginDto user)
    {
        if (!await _loginValidator.Validate(user))
            return new Result<User?>(new ValidationException(_loginValidator.Errors));
        var userLoggedIn = await _unitOfWork.User.GetAsync(u => u.Email == user.Email);
        return userLoggedIn;
    }
}