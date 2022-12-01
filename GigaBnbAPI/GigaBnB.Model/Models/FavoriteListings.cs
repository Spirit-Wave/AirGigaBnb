using System.ComponentModel.DataAnnotations;

namespace GigaBnB.Model.Models;

public class FavoriteListings : EntityBase
{
    [Required]
    public Guid UserId { get; set; }

    [Required]
    public Guid ListingId { get; set; }

    public User? User { get; set; }

    public Listing? Listing { get; set; }
}