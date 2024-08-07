using BookStoreAPI.Models;
using BookStoreAPI.DTOs;
using AutoMapper;

namespace BookStoreAPI.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<books, BookDto>()
                 .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                 .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genres));

            CreateMap<authors, AuthorCreateDto>();
            CreateMap<Genres, GenreCreateDto>();

            CreateMap<BookCreateDto, books>();
        }
    }
}
