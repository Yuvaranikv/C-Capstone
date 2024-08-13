using BookStoreAPI.DbContexts;
using BookStoreAPI.Models;
using BookStoreAPI.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Tests
{
    public class AuthorRepositoryTests
    {
        private readonly AuthorRepository _repository;
        private readonly DbContextOptions<BookStoreContext> _dbContextOptions;

        public AuthorRepositoryTests()
        {
            // Setup an in-memory database
            _dbContextOptions = new DbContextOptionsBuilder<BookStoreContext>()
                .UseInMemoryDatabase("BookStoreTestDB")
                .Options;

            var context = new BookStoreContext(_dbContextOptions);
            _repository = new AuthorRepository(context);

            // Seed some initial data
            SeedDatabase(context);
        }

        private void SeedDatabase(BookStoreContext context)
        {
            context.Authors.AddRange(
                new authors { author_id = 1, Name = "Author One", Biography = "Biography One", IsActive = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new authors { author_id = 2, Name = "Author Two", Biography = "Biography Two", IsActive = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
            );
            context.SaveChanges();
        }

        [Fact]
        public async Task GetAuthorsAsync_ShouldReturnPaginatedAuthors()
        {
            // Arrange
            int page = 1;
            int limit = 1;

            // Act
            var result = await _repository.GetAuthorsAsync(page, limit);

            // Assert
            Assert.Single(result);
            Assert.Equal("Author Two", result.First().Name);
        }

      

       
       
       

       
    }
}