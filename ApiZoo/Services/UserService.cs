using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ZooAPI.Data;
using ZooAPI.Models;

namespace ApiZoo.Services
{
    public class UserService : IUserService
    {
        ApplicationDbContext _db;
        private readonly PasswordHasher<User> _hash = new PasswordHasher<User>();

        public UserService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<object> Login(string email, string password)
        {
            var userConnected = await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (userConnected == null)
            {
                return null;
            }
            var passwordControl = _hash.VerifyHashedPassword(userConnected, userConnected.Password, password);
            if (passwordControl != PasswordVerificationResult.Success)
            {
                return null;
            }
            List<Claim> claims = new List<Claim>()
            {
              new Claim("UserId", userConnected.Id.ToString())// on peut ajouter l'Id de l'utilisateur en Claim
            };

            SigningCredentials signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes("this is my custom Secret key for authentication")),
                SecurityAlgorithms.HmacSha256
            );

            JwtSecurityToken jwt = new JwtSecurityToken(
            issuer: "zoo",
                audience: "http",
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddDays(7)
                );

            string token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return (new
            {
                Token = token,
                Message = "Authentication Successfull !!!",
                User = userConnected.Id,                
            });
        }
    }
}
