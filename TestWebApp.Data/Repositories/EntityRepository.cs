using Microsoft.EntityFrameworkCore;
using TestWebApp.Data.Contexts;
using TestWebApp.Data.Repositories.Interfaces;

namespace TestWebApp.Data.Repositories;

public class EntityRepository<T> : IEntityRepository<T> where T : class
{
    
    private readonly PostgresContext _context;

    public EntityRepository(PostgresContext context)
    {
        _context = context;
    }

    public async Task<ICollection<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> InsertAsync(T entity, CancellationToken cancellationToken)
    {
        var dbSet = _context.Set<T>();
        await dbSet.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task<IEnumerable<T>> InsertRangeAsync(ICollection<T> entities, CancellationToken cancellationToken)
    {
        var dbSet = _context.Set<T>();
        await dbSet.AddRangeAsync(entities, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return entities;
    }

    public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        var dbSet = _context.Set<T>();
        dbSet.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task<IEnumerable<T>> UpdateRangeAsync(ICollection<T> entities, CancellationToken cancellationToken)
    {
        var dbSet = _context.Set<T>();
        dbSet.UpdateRange(entities);
        await _context.SaveChangesAsync(cancellationToken);

        return entities;
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
    {
        var dbDet = _context.Set<T>();
        dbDet.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteRangeAsync(ICollection<T> entities, CancellationToken cancellationToken)
    {
        var dbDet = _context.Set<T>();
        dbDet.RemoveRange(entities);
        await _context.SaveChangesAsync(cancellationToken);
    }
}