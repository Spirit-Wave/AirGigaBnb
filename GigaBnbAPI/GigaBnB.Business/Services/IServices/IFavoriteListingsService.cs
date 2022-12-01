using GigaBnB.Business.DTOs;
using GigaBnB.Business.Utility;

namespace GigaBnB.Business.Services.IServices;

public interface IFavoriteListingsService
{
    public Task<Result<bool>> ToggleFavorite(FavoriteListingDto favoriteListing);
}