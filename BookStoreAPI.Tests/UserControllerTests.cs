using BookStoreAPI.Controllers;
using BookStoreAPI.Models;
using BookStoreAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Moq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Tests
{
    public class UserControllerTests
    {
        private readonly UserController _controller;
        private readonly Mock<IUserRepository> _mockRepo;
        private readonly Mock<IHttpContextAccessor> _mockHttpContextAccessor;


        public UserControllerTests()
        {
            _mockRepo = new Mock<IUserRepository>();
            _mockHttpContextAccessor = new Mock<IHttpContextAccessor>();

            // Create a HttpContext and setup default headers
            var context = new DefaultHttpContext();
            _mockHttpContextAccessor.Setup(x => x.HttpContext).Returns(context);

            // Inject IHttpContextAccessor into the controller
            _controller = new UserController(_mockRepo.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = context
                }
            };
        }

        [Fact]
        public async Task GetUsers_ReturnsOkResult_WithListOfUsers()
        {
            // Arrange
            var users = new List<userstest>
        {
            new userstest { Username = "user1", Password = "password1" },
            new userstest { Username = "user2", Password = "password2" }
        };
            _mockRepo.Setup(repo => repo.GetActiveUsersAsync()).ReturnsAsync(users);

            // Act
            var result = await _controller.GetUsers();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnUsers = Assert.IsType<List<userstest>>(okResult.Value);
            Assert.Equal(2, returnUsers.Count);
        }

        [Fact]
        public async Task CheckUser_InvalidUser_ReturnsUnauthorized()
        {
            // Arrange
            var user = new userstest { Username = "shreena", Password = "admin123" };
            _mockRepo.Setup(repo => repo.GetUserByCredentialsAsync(user.Username, user.Password)).ReturnsAsync((userstest)null);

            // Create a JWT token
            var token = GenerateJwtToken();
            _controller.HttpContext.Request.Headers["Authorization"] = $"Bearer {token}";

            // Act
            var result = await _controller.CheckUser(user);

            // Assert
            var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result);
            Assert.Equal("Invalid username or password", ((dynamic)unauthorizedResult.Value).message);
        }

        [Fact]
        public async Task Login_ValidUser_ReturnsOk()
        {
            // Arrange
            var user = new userstest { Username = "shreena", Password = "admin123" };
            _mockRepo.Setup(repo => repo.GetUserByCredentialsAsync(user.Username, user.Password)).ReturnsAsync(user);

            // Create a JWT token
            var token = GenerateJwtToken();
            _controller.HttpContext.Request.Headers["Authorization"] = $"Bearer {token}";

            // Act
            var result = await _controller.Login(user);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("User exists", ((dynamic)okResult.Value).message);
        }

        private string GenerateJwtToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("ThisIsASecretKeyThatIsAtLeast32CharactersLongForJWTAuthentication"); // Use the same key as in your startup configuration
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, "shreena")
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = "BookStoreAPI",
                Audience = "BookStoreAPIUsers"
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}