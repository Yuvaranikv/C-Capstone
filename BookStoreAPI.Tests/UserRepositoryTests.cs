using BookStoreAPI.DbContexts;
using BookStoreAPI.Models;
using BookStoreAPI.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Tests
{
    public class UserRepositoryTests
    {
        private readonly UserRepository _repository;
        private readonly Mock<BookStoreContext> _mockContext;
        private readonly Mock<DbSet<userstest>> _mockDbSet;

        public UserRepositoryTests()
        {
            _mockDbSet = new Mock<DbSet<userstest>>();
            _mockContext = new Mock<BookStoreContext>();
            _mockContext.Setup(c => c.Userstest).Returns(_mockDbSet.Object);
            _repository = new UserRepository(_mockContext.Object);
        }

        [Fact]
        public async Task GetActiveUsersAsync_ReturnsOnlyActiveUsers()
        {
            // Arrange
            var activeUsers = new List<userstest>
    {
        new userstest { Id = 1, Username = "user1", IsActive = true },
        new userstest {Id = 2, Username = "user2", IsActive = true }
    }.AsQueryable();

            _mockDbSet.As<IQueryable<userstest>>().Setup(m => m.Provider).Returns(activeUsers.Provider);
            _mockDbSet.As<IQueryable<userstest>>().Setup(m => m.Expression).Returns(activeUsers.Expression);
            _mockDbSet.As<IQueryable<userstest>>().Setup(m => m.ElementType).Returns(activeUsers.ElementType);
            _mockDbSet.As<IQueryable<userstest>>().Setup(m => m.GetEnumerator()).Returns(activeUsers.GetEnumerator());

            // Act
            var result = await _repository.GetActiveUsersAsync();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.All(result, u => Assert.True(u.IsActive));
        }

        Fact]
public async Task GetUserByCredentialsAsync_ReturnsCorrectUser()
        {
            // Arrange
            var users = new List<userstest>
    {
        new userstest {Id = 1, Username = "user1", Password = "password1", IsActive = true },
        new userstest { Id = 2, Username = "user2", Password = "password2", IsActive = true }
    }.AsQueryable();

            _mockDbSet.As<IQueryable<userstest>>().Setup(m => m.Provider).Returns(users.Provider);
            _mockDbSet.As<IQueryable<userstest>>().Setup(m => m.Expression).Returns(users.Expression);
            _mockDbSet.As<IQueryable<userstest>>().Setup(m => m.ElementType).Returns(users.ElementType);
            _mockDbSet.As<IQueryable<userstest>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

            // Act
            var result = await _repository.GetUserByCredentialsAsync("user1", "password1");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("user1", result.Username);
            Assert.Equal("password1", result.Password);
        }

        [Fact]
        public async Task GetUserByCredentialsAsync_ReturnsNull_WhenCredentialsAreInvalid()
        {
            // Arrange
            var users = new List<userstest>
    {
        new userstest { Id = 1, Username = "user1", Password = "password1", IsActive = true }
    }.AsQueryable();

            _mockDbSet.As<IQueryable<userstest>>().Setup(m => m.Provider).Returns(users.Provider);
            _mockDbSet.As<IQueryable<userstest>>().Setup(m => m.Expression).Returns(users.Expression);
            _mockDbSet.As<IQueryable<userstest>>().Setup(m => m.ElementType).Returns(users.ElementType);
            _mockDbSet.As<IQueryable<userstest>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

            // Act
            var result = await _repository.GetUserByCredentialsAsync("invalidUser", "invalidPassword");

            // Assert
            Assert.Null(result);
        }
    }
}
