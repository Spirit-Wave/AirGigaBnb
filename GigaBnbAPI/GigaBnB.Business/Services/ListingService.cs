using GigaBnB.Business.DTOs;
using GigaBnB.Business.Services.IServices;
using GigaBnB.DataAccess.Repository.IRepository;
using GigaBnB.Model.Enum;
using GigaBnB.Model.Models;

namespace GigaBnB.Business.Services;

public class ListingService : IListingService
{
    private readonly IUnitOfWork _unitOfWork;

    public ListingService(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Listing>> GetAllListings()
    {
        return await _unitOfWork.Listing.GetAllAsync();
    }

    public async Task<Listing> GetListing(Guid listingId)
    {
        var listing = await _unitOfWork.Listing.GetAsync(listing => listing.Id == listingId, $"{nameof(Listing.Owner)}");
        if (listing is not null) return listing;
        return listing ?? new Listing();
    }

    public async Task<Listing> CreateListing(ListingDto listing)
    {
        var createdListing = new Listing()
        {
            Title = listing.Title,
            City = listing.City,
            ApartmentType = listing.ApartmentType,
            Id = Guid.NewGuid(),
            OwnerId = listing.OwnerId, //Change to CurrentUser when implemented
            Price = listing.Price,
            RoomCount = listing.RoomCount,
            Summary = listing.Summary,
            Address = listing.Address,
            MaxOccupancy = listing.MaxOccupancy,
            BathroomCount = listing.BathroomCount,
            BedroomCount = listing.BedroomCount,
            HasHeating = listing.HasHeating,
            HasInternet = listing.HasInternet,
            HasKitchen = listing.HasKitchen,
            HasAirConditioner = listing.HasAirConditioner,
            HasTelevision = listing.HasTelevision,
            DateCreated = DateTime.Now,
            DateUpdated = DateTime.Now,
            ListingState = ListingState.New
        };

        _unitOfWork.Listing.Add(createdListing);
        await _unitOfWork.SaveAsync();
        return createdListing;
    }

    public async Task<Listing> EditListing(ListingDto listing)
    {
        var listingToEdit = await _unitOfWork.Listing.GetAsync(list => list.Id == listing.Id);

        if (listingToEdit != null)
        {
            listingToEdit.Price = listing.Price;
            listingToEdit.RoomCount = listing.RoomCount;
            listingToEdit.Summary = listing.Summary;
            listingToEdit.Address = listing.Address;
            listingToEdit.MaxOccupancy = listing.MaxOccupancy;
            listingToEdit.BathroomCount = listing.BathroomCount;
            listingToEdit.BedroomCount = listing.BedroomCount;
            listingToEdit.HasHeating = listing.HasHeating;
            listingToEdit.HasInternet = listing.HasInternet;
            listingToEdit.HasKitchen = listing.HasKitchen;
            listingToEdit.HasAirConditioner = listing.HasAirConditioner;
            listingToEdit.HasTelevision = listing.HasTelevision;
            listingToEdit.DateUpdated = DateTime.Now;

            _unitOfWork.Listing.Update(listingToEdit);
            await _unitOfWork.SaveAsync();
        }

        return listingToEdit ?? new Listing();
    }

    public async Task<Listing> DeleteListing(Guid listingId)
    {
        var listingToDelete = await _unitOfWork.Listing.GetAsync(list => list.Id == listingId);
        if (listingToDelete is not null)
        {
            _unitOfWork.Listing.Remove(listingToDelete);
            await _unitOfWork.SaveAsync();
        }

        return listingToDelete ?? new Listing();
    }
}