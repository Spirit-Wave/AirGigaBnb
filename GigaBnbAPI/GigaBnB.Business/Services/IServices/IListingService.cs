using GigaBnB.Business.DTOs;
using GigaBnB.Model.Models;

namespace GigaBnB.Business.Services.IServices;

public interface IListingService
{
    Task<IEnumerable<Listing>> GetAllListings();

    Task<Listing> GetListing(Guid listingId);

    Task<Listing> CreateListing(ListingDto listing);

    Task<Listing> EditListing(ListingDto listing);

    Task<Listing> DeleteListing(Guid listingId);
}