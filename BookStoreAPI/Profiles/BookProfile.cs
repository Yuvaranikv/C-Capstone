using BookStoreAPI.Models;
using BookStoreAPI.DTOs;
using AutoMapper;

namespace BookStoreAPI.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookCreateDto, Book>();
        }
    }
}
