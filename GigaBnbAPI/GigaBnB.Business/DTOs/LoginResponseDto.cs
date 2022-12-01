using GigaBnB.Model.Enum;

namespace GigaBnB.Business.DTOs;

public class LoginResponseDto
{
    public Guid Id { get; set; }

    public UserRole Role { get; set; }
}