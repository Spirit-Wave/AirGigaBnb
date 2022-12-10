using GigaBnB.Business.DTOs;
using GigaBnB.Business.Services.IServices;
using GigaBnB.Business.Utility;
using GigaBnB.DataAccess.Repository.IRepository;
using GigaBnB.Model.Models;

namespace GigaBnB.Business.Services;

public class FavoriteListingsService : IFavoriteListingsService
{
    private readonly IUnitOfWork _unitOfWork;

    public FavoriteListingsService(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public bool AddToFavorites(Guid listing, User user)
    {
        user.FavoriteListings.Add(new FavoriteListings()
        {
            UserId = user.Id,
            ListingId = listing,
        });
        _unitOfWork.User.Update(user);
        return true;
    }

    public bool DeleteFromFavorites(Guid listing, User user)
    {
        var listingToDelete = user.FavoriteListings.First(f => f.ListingId == listing);
        user.FavoriteListings.Remove(listingToDelete!);
        _unitOfWork.User.Update(user);
        return true;
    }

    private static bool IsFavorite(FavoriteListingDto favoriteListing, User user)
    {
        return user!.FavoriteListings.Any(f => f.ListingId == favoriteListing.ListingId);
    }

    public async Task<Result<bool>> ToggleFavorite(FavoriteListingDto favoriteListing)
    {
        var user = await _unitOfWork.User.GetAsync(u => u.Id == favoriteListing.UserId, nameof(User.FavoriteListings));
        var result = IsFavorite(favoriteListing, user!)
            ? AddToFavorites(favoriteListing.ListingId, user!)
            : DeleteFromFavorites(favoriteListing.ListingId, user!);
        await _unitOfWork.SaveAsync();
        return result;
    }
}