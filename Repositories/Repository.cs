using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using NoteTakerAPI.Data;

namespace NoteTakerAPI.Repositories;

public abstract class Repository<T> : IRepository<T> 
    where T : class
{
    protected readonly NotesDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(NotesDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public virtual async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default) 
        => await _dbSet.FindAsync([id], cancellationToken);

    public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default) 
        => await _dbSet.ToListAsync(cancellationToken);

    public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        => await _dbSet.Where(predicate).ToListAsync(cancellationToken);

    public virtual async Task AddAsync(T entity, CancellationToken cancellationToken = default) 
        => await _dbSet.AddAsync(entity, cancellationToken);

    public virtual void Remove(T entity) 
        => _dbSet.Remove(entity);

    public virtual async Task SaveChangesAsync(CancellationToken cancellationToken = default) 
        => await _context.SaveChangesAsync(cancellationToken);
}