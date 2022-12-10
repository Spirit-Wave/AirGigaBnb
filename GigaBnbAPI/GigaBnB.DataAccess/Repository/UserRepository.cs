using GigaBnB.DataAccess.Repository.IRepository;
using GigaBnB.Model.Models;

namespace GigaBnB.DataAccess.Repository;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly ApplicationDbContext _db;

    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        this._db = dbContext;
    }
}