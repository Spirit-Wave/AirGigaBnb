using GigaBnB.Business.Services;
using GigaBnB.Business.Services.IServices;
using GigaBnB.DataAccess.Repository;
using GigaBnB.DataAccess.Repository.IRepository;

namespace GigaBnbAPI.Extensions;

public static class AddServiceExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IListingService, ListingService>();
    }

    public static void AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}