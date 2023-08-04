namespace TestWebApp.Data.Repositories.Interfaces;

public interface IEntityRepository<T> where T : class
{
    Task<ICollection<T>> GetAll();
    
    Task<T> InsertAsync(T entity, CancellationToken cancellationToken);
    
    Task<IEnumerable<T>> InsertRangeAsync(ICollection<T> entities, CancellationToken cancellationToken);

    Task<T> UpdateAsync(T entity, CancellationToken cancellationToken);
    
    Task<IEnumerable<T>> UpdateRangeAsync(ICollection<T> entities, CancellationToken cancellationToken);

    Task DeleteAsync(T entity, CancellationToken cancellationToken);
    
    Task DeleteRangeAsync(ICollection<T> entities, CancellationToken cancellationToken);
}