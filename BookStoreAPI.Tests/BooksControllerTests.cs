using AutoMapper;
using BookStoreAPI.Controllers;
using BookStoreAPI.Services;
using Moq;
using BookStoreAPI.DTOs;
    using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Tests
{
    public class BooksControllerTests
    {
        private readonly Mock<IBookRepository> _repositoryMock;
        private readonly IMapper _mapper;
        private readonly BooksController _controller;

        public BooksControllerTests()
        {
            _repositoryMock = new Mock<IBookRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<books, BookDto>();
                cfg.CreateMap<BookCreateDto, books>();
            });

            _mapper = config.CreateMapper();
            _controller = new BooksController(_repositoryMock.Object, _mapper);
        }

      
    }
}
