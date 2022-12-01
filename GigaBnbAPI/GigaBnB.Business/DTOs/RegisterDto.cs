using System.ComponentModel.DataAnnotations;
using GigaBnB.Model.Enum;

namespace GigaBnB.Business.DTOs;
public class RegisterDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;

    [Required]
    public string ConfirmPassword { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }

    public string? Description { get; set; }

    public UserRole Role { get; set; }
}