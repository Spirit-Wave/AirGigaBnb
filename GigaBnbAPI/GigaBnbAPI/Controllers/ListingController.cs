using GigaBnB.Business.DTOs;
using GigaBnB.Business.Services.IServices;
using GigaBnB.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace GigaBnbAPI.Controllers;

[ApiController]
[Route(template: "listing")]
public class ListingController : ControllerBase
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

    [HttpPost("create")]
    public async Task<ActionResult<Listing>> CreateListing([FromBody] ListingDto listing)
    {
        var createdListing = await _listingService.CreateListing(listing);
        return Ok(createdListing);
    }

    [HttpPost("edit")]
    public async Task<ActionResult<Listing>> EditListing([FromBody] ListingDto listing)
    {
        var editedListing = await _listingService.EditListing(listing);
        return Ok(editedListing);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Listing>> DeleteListing(Guid id)
    {
        await _listingService.DeleteListing(id);
        return Ok("Listing deleted successfully");
    }
}
