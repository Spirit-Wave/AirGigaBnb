using GigaBnB.Business.DTOs;
using GigaBnB.Business.Exceptions;
using GigaBnB.Business.Services.IServices;
using GigaBnB.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace GigaBnbAPI.Controllers;

[ApiController]
[Route(template: "user")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        this._userService = userService;
    }

    [HttpPost("register/register-client")]
    public async Task<ActionResult<User>> RegisterLessee([FromBody] RegisterDto register)
    {
        var result = await _userService.RegisterClient(register);
        if (result.Exception is ValidationException exception)
        {
            return Unauthorized(exception.Messages);
        }

        return Ok(result.Value);
    }

    [HttpPost("register/register-worker")]
    public async Task<ActionResult<User>> RegisterWorker([FromBody] RegisterDto register)
    {
        var result = await _userService.RegisterWorker(register);
        if (result.Exception is ValidationException exception)
        {
            return Unauthorized(exception.Messages);
        }

        return Ok(result.Value);
    }

    [HttpPost("login")]
    public async Task<ActionResult<User>> LoginUser([FromBody] LoginDto login)
    {
        var result = await _userService.LoginUser(login);
        if (result.Exception is ValidationException exception)
        {
            return Unauthorized(exception.Messages);
        }

        return Ok(new LoginResponseDto()
        {
            Id = result.Value!.Id,
            Role = result.Value!.Role,
        });
    }
}