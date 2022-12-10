using GigaBnB.Model.Enum;

namespace GigaBnB.Business.DTOs;

public class ListingDto
{
    public string? Title { get; set; }

    public Guid Id { get; set; }

    public Guid OwnerId { get; set; }

    public ApartmentType ApartmentType { get; set; }

    public int RoomCount { get; set; }

    public int MaxOccupancy { get; set; }

    public int BathroomCount { get; set; }

    public int BedroomCount { get; set; }

    public string? Summary { get; set; }

    public string? Address { get; set; }

    public bool HasTelevision { get; set; }

    public string? City { get; set; }

    public bool HasKitchen { get; set; }

    public bool HasAirConditioner { get; set; }

    public bool HasHeating { get; set; }

    public bool HasInternet { get; set; }

    public int Price { get; set; }
}