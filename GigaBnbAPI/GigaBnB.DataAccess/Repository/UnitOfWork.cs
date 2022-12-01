using GigaBnB.DataAccess.Repository.IRepository;

namespace GigaBnB.DataAccess.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _db;

    public UnitOfWork(ApplicationDbContext db)
    {
        this._db = db;
        User = new UserRepository(db);
        Listing = new ListingRepository(db);
    }

    public IUserRepository User { get; set; }

    public IListingRepository Listing { get; set;}

    public void Save()
    {
        this._db.SaveChanges();
    }

    public Task<int> SaveAsync()
    {
        return this._db.SaveChangesAsync();
    }
}