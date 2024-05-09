namespace TestApp.Services.Interfaces
{
    public interface IGenericReporistory<T>
    {
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task SaveAsync();
    }
}
