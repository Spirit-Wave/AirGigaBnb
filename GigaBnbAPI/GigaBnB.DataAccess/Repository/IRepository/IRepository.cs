using System.Linq.Expressions;

namespace GigaBnB.DataAccess.Repository.IRepository;

public interface IRepository<T> where T : class
{
    T? Get(Expression<Func<T, bool>> filter, string? includeProperties = null);

    ICollection<T> GetAll(string? includeProperties = null);

    void Add(T entity);

    void Update(T entity);

    void Remove(T entity);

    void RemoveRange(IEnumerable<T> entities);

    Task<T?> GetAsync(Expression<Func<T, bool>> filter, string? includeProperties = null);

    Task<ICollection<T>> GetAllAsync(string? includeProperties = null);
}