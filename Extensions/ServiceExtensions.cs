using BookLibraryApi.Services.Implementations;
using BookLibraryApi.Services.Interfaces;

namespace BookLibraryApi.Extensions;

public static class ServiceExtensions
{
    public static void AddServiceExtensions(this IServiceCollection services)
    {
        //services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        //services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
        services.AddScoped<IBookService, BookService>();

        //services.AddScoped<IBlogService, BlogManager>();
    }
}