using GigaBnB.DataAccess.Repository.IRepository;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace GigaBnB.DataAccess.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _db;
    private readonly DbSet<T> _dbSet;

    public Repository(ApplicationDbContext dbContext)
    {
        _db = dbContext;
        _dbSet = _db.Set<T>();
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public T? Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
    {
        IQueryable<T> query = _dbSet;
        query = query.Where(filter);
        query = IncludePropertiesIfExists(includeProperties, query);
        return query.FirstOrDefault();
    }

    public ICollection<T> GetAll(string? includeProperties = null)
    {
        IQueryable<T> query = _dbSet;
        query = IncludePropertiesIfExists(includeProperties, query);
        return query.ToList();
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> filter, string? includeProperties = null)
    {
        IQueryable<T> query = _dbSet;
        query = query.Where(filter);
        query = IncludePropertiesIfExists(includeProperties, query);
        return await query.FirstOrDefaultAsync();
    }

    public async Task<ICollection<T>> GetAllAsync(string? includeProperties = null)
    {
        IQueryable<T> query = _dbSet;
        query = IncludePropertiesIfExists(includeProperties, query);
        return await query.ToListAsync();
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    private IQueryable<T> IncludePropertiesIfExists(string? includeProperties, IQueryable<T> query)
    {
        if (includeProperties != null)
        {
            query = IncludeProperties(includeProperties, query);
        }

        return query;
    }

    private IQueryable<T> IncludeProperties(string includeProperties, IQueryable<T> query)
    {
        foreach (var includeProp in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProp);
        }

        return query;
    }
}