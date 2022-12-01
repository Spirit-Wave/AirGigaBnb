using System.ComponentModel.DataAnnotations;
using GigaBnB.Model.Enum;

namespace GigaBnB.Model.Models;

public class User : EntityBase
{
    [Required]
    [StringLength(30)] 
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Email { get; set; } = string.Empty;

    [Required] 
    public string Password { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }

    [StringLength(250)] 
    public string? Description { get; set; }

    public UserRole Role { get; set; }

    public ICollection<FavoriteListings> FavoriteListings { get; set; } = null!;
}