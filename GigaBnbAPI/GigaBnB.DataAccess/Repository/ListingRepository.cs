using GigaBnB.DataAccess.Repository.IRepository;
using GigaBnB.Model.Models;

namespace GigaBnB.DataAccess.Repository;

public class ListingRepository : Repository<Listing>, IListingRepository
{
    private readonly ApplicationDbContext _db;

    public ListingRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        this._db = dbContext;
    }
}
