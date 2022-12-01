using GigaBnB.Business.DTOs;
using GigaBnB.Business.Filters;
using GigaBnB.Business.Services.IServices;
using GigaBnB.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace GigaBnbAPI.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        this._userService = userService;
    }

    [HttpPost("/register")]
    [ValidationExceptionFilter]
    public async Task<ActionResult<User>> RegisterUser([FromBody] UserDto user)
    {
        User? registeredUser = null;
        registeredUser = await _userService.RegisterUser(user);
        return registeredUser ?? new User();
    }
}