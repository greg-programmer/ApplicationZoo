using ZooLibrary.Models;

namespace ApiZoo.Repository
{
    public interface IUserRepository
    {
        Task<bool> Create(User user);        
    }
}
