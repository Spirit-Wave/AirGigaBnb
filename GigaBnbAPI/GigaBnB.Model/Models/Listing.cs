using System.ComponentModel.DataAnnotations;
using GigaBnB.Model.Enum;

namespace GigaBnB.Model.Models;

public class Listing : EntityBase
{
    [Required]
    public string Title { get; set; }

    [Required]
    public ApartmentType ApartmentType { get; set; }

    public Guid OwnerId { get; set; }

    [Required]
    public int RoomCount { get; set; }

    [Required]
    public int MaxOccupancy { get; set; }

    [Required]
    public int BathroomCount { get; set; }

    [Required]
    public int BedroomCount { get; set; }

    public string City { get; set; } = null!;

    public string? Summary { get; set; }

    [Required]
    public string? Address { get; set; }

    public bool HasTelevision { get; set; }

    public bool HasKitchen { get; set; }

    public bool HasAirConditioner { get; set; }

    public bool HasHeating { get; set; }

    public bool HasInternet { get; set; }

    [Required]
    public int Price { get; set; }

    public DateTime? DatePublished { get; set; }

    public ListingState ListingState { get; set; }

    public User? Owner { get; set; }
}
