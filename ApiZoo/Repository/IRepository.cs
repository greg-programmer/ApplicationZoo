namespace ApiZoo.Repository
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();        
        Task<T> Get(int id);
        Task<bool> Create(T entity);
        Task<T> Update(int id, T entity);
        Task<bool> Delete(int id);       
    }
}
