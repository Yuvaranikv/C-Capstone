using BookStoreAPI.Controllers;
using BookStoreAPI.DTOs;
using BookStoreAPI.Models;
using BookStoreAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Tests
{
    public class GenresControllerTests
    {
        private readonly GenresController _controller;
        private readonly Mock<IGenreRepository> _mockRepo;

        public GenresControllerTests()
        {
            _mockRepo = new Mock<IGenreRepository>();
            _controller = new GenresController(_mockRepo.Object);
        }

        [Fact]
        public async Task GetGenres_ValidRequest_ReturnsOkResult_WithGenres()
        {
            // Arrange
            var genres = new List<Genres>
            {
                new Genres { genre_id = 1, genre_name = "Fiction" },
                new Genres { genre_id = 2, genre_name = "Non-Fiction" }
            };
            var totalCount = genres.Count;
            _mockRepo.Setup(repo => repo.GetGenresAsync(1, 10)).ReturnsAsync(genres);
           // _mockRepo.Setup(repo => repo.GetAllGenresAsync()).ReturnsAsync(totalCount);

            // Act
            var result = await _controller.GetGenres();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<dynamic>(okResult.Value);
            Assert.Equal(totalCount, response.totalCount);
            Assert.Equal(genres.Count, ((IEnumerable<Genres>)response.genres).Count());
        }

        [Fact]
        public async Task GetAllGenres_ReturnsOkResult_WithAllGenres()
        {
            // Arrange
            var genres = new List<Genres>
            {
                new Genres { genre_id = 1, genre_name = "Fiction" },
                new Genres { genre_id = 2, genre_name = "Non-Fiction" }
            };
            _mockRepo.Setup(repo => repo.GetAllGenresAsync()).ReturnsAsync(genres);

            // Act
            var result = await _controller.GetAllGenres();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnGenres = Assert.IsAssignableFrom<IEnumerable<Genres>>(okResult.Value);
            Assert.Equal(genres.Count, returnGenres.Count());
        }

        [Fact]
        public async Task GetGenreByIdAsync_ValidId_ReturnsOkResult_WithGenre()
        {
            // Arrange
            var genre = new Genres { genre_id = 1, genre_name = "Fiction" };
            _mockRepo.Setup(repo => repo.GetGenreByIdAsync(1)).ReturnsAsync(genre);

            // Act
            var result = await _controller.GetGenreByIdAsync(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnGenre = Assert.IsType<Genres>(okResult.Value);
            Assert.Equal(genre.genre_id, returnGenre.genre_id);
            Assert.Equal(genre.genre_name, returnGenre.genre_name);
        }

        [Fact]
        public async Task GetGenreByIdAsync_InvalidId_ReturnsNotFound()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetGenreByIdAsync(1)).ReturnsAsync((Genres)null);

            // Act
            var result = await _controller.GetGenreByIdAsync(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task AddGenre_ValidGenre_ReturnsCreatedResult()
        {
            // Arrange
            var genreDto = new GenreCreateDto { genre_name = "Science Fiction" };
            var genre = new Genres { genre_id = 1, genre_name = "Science Fiction", createdAt = DateTime.UtcNow, updatedAt = DateTime.UtcNow };
            _mockRepo.Setup(repo => repo.AddGenreAsync(It.IsAny<Genres>())).ReturnsAsync(genre);

            // Act
            var result = await _controller.AddGenre(genreDto);

            // Assert
            var createdResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(StatusCodes.Status201Created, createdResult.StatusCode);
        }

        [Fact]
        public async Task AddGenre_InvalidGenre_ReturnsBadRequest()
        {
            // Arrange
            var genreDto = new GenreCreateDto { genre_name = "" };

            // Act
            var result = await _controller.AddGenre(genreDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Genre name is required", badRequestResult.Value);
        }

        [Fact]
        public async Task UpdateGenre_ValidIdAndGenre_ReturnsOkResult_WithUpdatedGenre()
        {
            // Arrange
            var genreDto = new GenreCreateDto { genre_name = "Updated Genre" };
            var updatedGenre = new Genres { genre_id = 1, genre_name = "Updated Genre" };
            _mockRepo.Setup(repo => repo.UpdateGenreAsync(1, genreDto)).ReturnsAsync(updatedGenre);

            // Act
            var result = await _controller.UpdateGenre(1, genreDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnGenre = Assert.IsType<Genres>(okResult.Value);
            Assert.Equal(updatedGenre.genre_name, returnGenre.genre_name);
        }

        [Fact]
        public async Task UpdateGenre_InvalidId_ReturnsNotFound()
        {
            // Arrange
            var genreDto = new GenreCreateDto { genre_name = "Updated Genre" };
            _mockRepo.Setup(repo => repo.UpdateGenreAsync(1, genreDto)).ReturnsAsync((Genres)null);

            // Act
            var result = await _controller.UpdateGenre(1, genreDto);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task UpdateGenre_InvalidGenre_ReturnsBadRequest()
        {
            // Arrange
            var genreDto = new GenreCreateDto { genre_name = "" };

            // Act
            var result = await _controller.UpdateGenre(1, genreDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Genre name is required", badRequestResult.Value);
        }

        [Fact]
        public async Task DeleteGenre_ValidId_ReturnsNoContent()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.DeleteGenreAsync(1)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteGenre(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteGenre_InvalidId_ReturnsNotFound()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.DeleteGenreAsync(1)).ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteGenre(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}