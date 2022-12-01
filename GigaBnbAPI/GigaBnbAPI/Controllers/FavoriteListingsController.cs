using GigaBnB.Business.DTOs;
using GigaBnB.Business.Exceptions;
using GigaBnB.Business.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GigaBnbAPI.Controllers;

[ApiController]
[Route(template: "listing-favorite")]
public class FavoriteListingsController : ControllerBase
{
    private readonly IFavoriteListingsService _favoriteListingsService;

    public FavoriteListingsController(IFavoriteListingsService favoriteListingsService)
    {
        this._favoriteListingsService = favoriteListingsService;
    }

    [HttpPost("toggle-favorite")]
    public async Task<ActionResult> ToggleFavorites([FromBody] FavoriteListingDto favoriteListing)
    {
        var result = await _favoriteListingsService.ToggleFavorite(favoriteListing);
        if (result.Exception is ValidationException exception)
        {
            return BadRequest(exception.Messages);
        }
        return NoContent();
    }
}