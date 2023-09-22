namespace FrontZoo.Services;

public interface IRepository<TEntity>
{
    public TEntity? Get(int id);
    public List<TEntity> GetAll();
    public bool Post(TEntity TEntity);
    public bool Put(TEntity TEntity);
    public bool Delete(int id);
}