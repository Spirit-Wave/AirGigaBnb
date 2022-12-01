using System.ComponentModel.DataAnnotations;
using GigaBnB.Model.Enum;

namespace GigaBnB.Model.Models;

public class User : EntityBase
{
    [Required] 
    [StringLength(30)] 
    public string? Name { get; set; }

    [Required] 
    public string? Email { get; set; }

    [Required] 
    public string? Password { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public string? PhoneNumber { get; set; }

    [StringLength(250)] 
    public string? Description { get; set; }

    public UserRole Role { get; set; }
}