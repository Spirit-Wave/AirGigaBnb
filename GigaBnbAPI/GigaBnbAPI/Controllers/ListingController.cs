using GigaBnB.Business.DTOs;
using GigaBnB.Business.Filters;
using GigaBnB.Business.Services.IServices;
using GigaBnB.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace GigaBnbAPI.Controllers;

public class ListingController : Controller
{
    private readonly IListingService _listingService;

    public ListingController(IListingService listingService)
    {
        this._listingService = listingService;
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<Listing>>> GetAllListings() => Ok(await _listingService.GetAllListings());

    [HttpGet("{id}")]
    public async Task<ActionResult<Listing>> GetListing(Guid id) => Ok(await _listingService.GetListing(id));

    [HttpPost("/create")]
    [ValidationExceptionFilter]
    public async Task<ActionResult<Listing>> CreateListing([FromBody] ListingDto listing)
    {
        Listing? createdListing = null;
        createdListing = await _listingService.CreateListing(listing);
        return createdListing ?? new Listing();
    }

    [HttpPost("/edit")]
    [ValidationExceptionFilter]
    public async Task<ActionResult<Listing>> EditListing([FromBody] ListingDto listing)
    {
        Listing? editedListing = null;
        editedListing = await _listingService.EditListing(listing);
        return editedListing ?? new Listing();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Listing>> DeleteListing(Guid id)
    {
        await _listingService.DeleteListing(id);
        return Ok("Listing deleted successfully");
    }
}
