public interface IRepositoryBase<T>
{
    void Add(T entity);
    void Delete(T entity);
    IEnumerable<T> GetAll();
    T? Get(int id);
}