using GigaBnB.Business.DTOs;
using GigaBnB.Model.Models;

namespace GigaBnB.Business.Services.IServices;

public interface IUserService
{
    Task<User> RegisterUser(UserDto user);

    bool LoginUser(UserDto user);
}