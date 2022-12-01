using System.ComponentModel.DataAnnotations;

namespace GigaBnB.Business.DTOs;

public class FavoriteListingDto
{
    [Required] public Guid UserId { get; set; }

    [Required] public Guid ListingId { get; set; }
}