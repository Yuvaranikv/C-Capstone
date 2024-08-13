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