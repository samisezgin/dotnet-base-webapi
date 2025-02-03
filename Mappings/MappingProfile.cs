using AutoMapper;
using BookLibraryApi.Models;

namespace BookLibraryApi.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book,Book>().ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}