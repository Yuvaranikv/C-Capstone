using BookStoreAPI.Controllers;
using BookStoreAPI.DTOs;
using BookStoreAPI.Models;
using BookStoreAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Dynamic;

namespace BookStoreAPI.Tests
{
    public class AuthorsControllerTests
    {
       
      
        private readonly AuthorsController _controller;
        private readonly Mock<IAuthorRepository> _mockRepository;

        public AuthorsControllerTests()
        {
            _mockRepository = new Mock<IAuthorRepository>();
            _controller = new AuthorsController(_mockRepository.Object);
        }






            [Fact]
        public async Task GetAuthorByIdAsync_ReturnsOkResult_WithAuthor()
        {
            // Arrange
            var author = new authors { author_id = 1, Name = "Author 1" };
            _mockRepository.Setup(repo => repo.GetAuthorByIdAsync(1))
                           .ReturnsAsync(author);

            // Act
            var result = await _controller.GetAuthorByIdAsync(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<authors>(okResult.Value);
            Assert.Equal("Author 1", returnValue.Name);
        }

        [Fact]
        public async Task AddAuthor_ReturnsCreatedResult_WithAuthor()
        {
            // Arrange
            var authorDto = new AuthorCreateDto
            {
                Name = "New Author",
                Biography = "Author biography"
            };

            var author = new authors
            {
                author_id = 1,
                Name = authorDto.Name,
                Biography = authorDto.Biography,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _mockRepository.Setup(repo => repo.AddAuthorAsync(It.IsAny<authors>()))
                           .ReturnsAsync(author);

            // Act
            var result = await _controller.AddAuthor(authorDto);

            // Assert
            var createdResult = Assert.IsType<ObjectResult>(result.Result);
            var createdAuthor = Assert.IsType<authors>(createdResult.Value);
            Assert.Equal(author.Name, createdAuthor.Name);
        }
            [Fact]
        public async Task UpdateAuthor_ReturnsOkResult_WithUpdatedAuthor()
        {
            // Arrange
            var authorDto = new AuthorCreateDto { Name = "Updated Author", Biography = "Updated Biography" };
            var updatedAuthor = new authors { author_id = 1, Name = "Updated Author" };
            _mockRepository.Setup(repo => repo.UpdateAuthorAsync(1, It.IsAny<authors>()))
                           .ReturnsAsync(updatedAuthor);

            // Act
            var result = await _controller.UpdateAuthor(1, authorDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<authors>(okResult.Value);
            Assert.Equal("Updated Author", returnValue.Name);
        }

        [Fact]
        public async Task DeleteAuthor_ReturnsNoContent_WhenAuthorIsDeleted()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.DeleteAuthorAsync(1))
                           .ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteAuthor(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}