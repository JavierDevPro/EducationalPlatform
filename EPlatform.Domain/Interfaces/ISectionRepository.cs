namespace EPlatform.Domain.Interfaces;

public interface ISectionRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    Task<T> Create(T entity);
    Task<T> Update(int Id, T entity);
    Task<bool> Delete(int Id);   
}