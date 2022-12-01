using GigaBnB.Business.DTOs;
using GigaBnB.Business.Utility;
using GigaBnB.Model.Models;

namespace GigaBnB.Business.Services.IServices;

public interface IUserService
{
    Task<Result<User>> RegisterClient(RegisterDto register);

    Task<Result<User>> RegisterWorker(RegisterDto register);

    Task<Result<User?>> LoginUser(LoginDto user);
}