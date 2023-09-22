using ApiZoo.Repository;
using ApiZoo.Services;
using Microsoft.AspNetCore.Mvc;
using ZooAPI.Models;

namespace ApiZoo.Controllers
{
    [ApiController]
    [Route("Api/")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public UserController(IUserRepository userRepository, IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        [HttpPost("User")]
        public async Task<IActionResult> Create(User user)
        {
            if( await _userRepository.Create(user))
            {
                return Ok("User Created !");
            }
            return BadRequest("This email has already use !");
        }

        [HttpPost("User/login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var token = await _userService.Login(email, password);
            if (token == null)
            {
                return BadRequest("unauthorized");
            }
            return Ok(token);
        }
    }
}
