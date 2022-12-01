using GigaBnB.Business.DTOs;
using GigaBnB.Business.Services.IServices;
using GigaBnB.Business.Validation;
using GigaBnB.DataAccess.Repository.IRepository;
using GigaBnB.Model.Models;

namespace GigaBnB.Business.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidation _validationDictionary;

    public UserService(IUnitOfWork unitOfWork, IValidation validationDictionary)
    {
        this._unitOfWork = unitOfWork;
        this._validationDictionary = validationDictionary;
    }

    public async Task<User> RegisterUser(UserDto user)
    {
        var userCreated = new User()
        {
            Id = Guid.NewGuid(),
            Name = user.Name,
            Email = user.Email,
            Password = user.Password,
            CreatedDate = DateTime.Now,
            UpdatedDate = DateTime.Now,
        };
        _validationDictionary.AddError(nameof(user.Password), "Incorrect Password");
        _validationDictionary.AddError(nameof(user.Email), "Invalid Email");
        _validationDictionary.AddError("Smedva", "Stinky Email");
        _validationDictionary.ThrowErrorsIfExists();
        _unitOfWork.User.Add(userCreated);
        await _unitOfWork.SaveAsync();
        return userCreated;
    }

    public bool LoginUser(UserDto user)
    {
        throw new NotImplementedException();
    }
}