namespace GigaBnB.DataAccess.Repository.IRepository;

public interface IUnitOfWork
{
    IUserRepository User { get; set; }
    IListingRepository Listing { get; set; }

    void Save();

    Task<int> SaveAsync();
}