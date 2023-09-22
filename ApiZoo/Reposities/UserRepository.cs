using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ZooAPI.Data;
using ZooAPI.Models;

namespace ApiZoo.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly PasswordHasher<User> _hash = new PasswordHasher<User>();

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(User user)
        {
            var email = await _db.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

            if (email == null)
            {
                string hashPassword = _hash.HashPassword(user, user.Password);
                user.Password = hashPassword;
                await _db.Users.AddAsync(user);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
