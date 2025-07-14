using System.Linq.Expressions;

namespace NoteTakerAPI.Repositories;

public interface IRepository<T> 
    where T : class
{
    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    void Remove(T entity);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}