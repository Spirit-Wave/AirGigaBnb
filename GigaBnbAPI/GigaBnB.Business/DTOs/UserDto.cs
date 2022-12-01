﻿using GigaBnB.Model.Enum;

namespace GigaBnB.Business.DTOs;
public class UserDto
{
    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Description { get; set; }

    public UserRole Role { get; set; }
}