namespace ApiZoo.Services
{
    public interface IUserService
    {
        Task<object> Login(string email, string password);
    }
}
