using BookStoreAPI.DbContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;
using BookStoreAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStoreAPI.Controllers
{
    /// <summary>
    /// Controller for managing user operations.
    /// </summary>
   
    [Route("userstest")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {


        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// List all active users
        /// </summary>
        /// <returns>All active users</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<userstest>>> GetUsers()
        {
            var users = await _userRepository.GetActiveUsersAsync();
            return Ok(users);
        }

        /// <summary>
        /// Check username and password
        /// </summary>
        /// <param name="user">User credentials</param>
        /// <returns>Status of the login attempt</returns>
        [HttpPost]
        public async Task<ActionResult> CheckUser([FromBody] userstest user)
        {
            if (user == null || string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                return BadRequest("Username and password are required");
            }

            var existingUser = await _userRepository.GetUserByCredentialsAsync(user.Username, user.Password);

            if (existingUser != null)
            {
                return Ok(new { message = "User exists" });
            }
            else
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }
        }

        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="user">User credentials</param>
        /// <returns>Status of the login attempt</returns>
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] userstest user)
        {
            if (user == null || string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                return BadRequest("Username and password are required");
            }

            var existingUser = await _userRepository.GetUserByCredentialsAsync(user.Username, user.Password);

            if (existingUser != null)
            {
                return Ok(new { message = "User exists" });
            }
            else
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }
        }

    }
}

