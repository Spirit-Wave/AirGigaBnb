using GigaBnB.Business.DTOs;
using GigaBnB.Business.Services.IServices;
using GigaBnB.Business.Validation;
using GigaBnB.DataAccess.Repository.IRepository;
using GigaBnB.Model.Enum;
using GigaBnB.Model.Models;

namespace GigaBnB.Business.Services;

public class ListingService : IListingService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidation _validationDictionary;

    public ListingService(IUnitOfWork unitOfWork, IValidation validationDictionary)
    {
        this._unitOfWork = unitOfWork;
        this._validationDictionary = validationDictionary;
    }

    public async Task<IEnumerable<Listing>> GetAllListings()
    {
        return await _unitOfWork.Listing.GetAllAsync();
    }

    public async Task<Listing> GetListing(Guid id)
    {
        return await _unitOfWork.Listing.GetByIdAsync(id);
    }

    public async Task<Listing> CreateListing(ListingDto listing)
    {
        var createdListing = new Listing()
        {
            Id = Guid.NewGuid(),
            OwnerId = Guid.NewGuid(), //Change to CurrentUser when implemented
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
        var listingToEdit = _unitOfWork.Listing.GetById(listing.Id);

        if (listingToEdit != null)
        {
            listingToEdit.Price = listing.Price;
            listingToEdit.RoomCount = listing.RoomCount;
            listingToEdit.Summary = listing.Summary;
            listingToEdit.Address = listing.Address;
            listingToEdit.MaxOccupancy = listing.MaxOccupancy;
            listingToEdit.BathroomCount = listing.BathroomCount;
            listingToEdit.BedroomCount = listing.BedroomCount;
            listingToEdit.HasHeating = listingToEdit.HasHeating;
            listingToEdit.HasInternet = listingToEdit.HasInternet;
            listingToEdit.HasKitchen = listingToEdit.HasKitchen;
            listingToEdit.HasAirConditioner = listingToEdit.HasAirConditioner;
            listingToEdit.HasTelevision = listingToEdit.HasTelevision;
            listingToEdit.DateUpdated = DateTime.Now;

            _unitOfWork.Listing.Update(listingToEdit);
            await _unitOfWork.SaveAsync();
        }
        else
        {
            _validationDictionary.AddError(listing.Id.ToString(), "Listing does not exist");
        }

        _validationDictionary.ThrowErrorsIfExists();

        return listingToEdit;
    }

    public async Task<Listing> DeleteListing(Guid id)
    {
        var listingToDelete = _unitOfWork.Listing.GetById(id);
        if (listingToDelete != null)
        {
            _unitOfWork.Listing.Remove(listingToDelete);
            await _unitOfWork.SaveAsync();
        }
        else
        {
            _validationDictionary.AddError(id.ToString(), "Listing does not exist");
        }

        _validationDictionary.ThrowErrorsIfExists();

        return listingToDelete;
    }
}