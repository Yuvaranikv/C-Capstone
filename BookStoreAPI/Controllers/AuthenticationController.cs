using BookStoreAPI.Models;
using BookStoreAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookStoreAPI.DTOs;

namespace BookStoreAPI.Controllers
{
    /// <summary>
    /// Controller for handling authentication and JWT token generation.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        /// <summary>
        /// Authenticates a user and returns a JWT token.
        /// </summary>
        /// <param name="user">User credentials.</param>
        /// <returns>JWT token if credentials are valid.</returns>
        /// <response code="200">Returns a JWT token.</response>
        /// <response code="400">If the credentials are invalid.</response>
        /// <response code="401">If the user is not authorized.</response>
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserLoginDto user)
        {
            if (user == null || string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                return BadRequest("Username and password are required");
            }

            var existingUser = await _userRepository.GetUserByCredentialsAsync(user.Username, user.Password);

            if (existingUser != null)
            {
                var token = GenerateJwtToken(existingUser);
                return Ok(new { token });
            }
            else
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }
        }

        private string GenerateJwtToken(userstest user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

   
}