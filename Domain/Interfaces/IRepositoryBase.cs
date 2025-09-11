public interface IRepositoryBase<T>
{
    Task AddAsync(T entity);
    Task DeleteAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task SaveChangesAsync();
}