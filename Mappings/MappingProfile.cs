using AutoMapper;
using BookLibraryApi.DTOs;
using BookLibraryApi.Models;

namespace BookLibraryApi.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateBookDto, Book>();
        CreateMap<UpdateBookDto, Book>();
        CreateMap<BookResultDto, Book>().ReverseMap();
    }
}