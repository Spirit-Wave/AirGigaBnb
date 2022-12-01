using GigaBnB.Business.DTOs;
using GigaBnB.Business.Services;
using GigaBnB.Business.Services.IServices;
using GigaBnB.Business.Validation;
using GigaBnB.DataAccess.Repository;
using GigaBnB.DataAccess.Repository.IRepository;

namespace GigaBnbAPI.Extensions;

public static class AddServiceExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IListingService, ListingService>();
        services.AddScoped<IFavoriteListingsService, FavoriteListingsService>();
    }

    public static void AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static void AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<LoginDto>, LoginUserValidator>();
        services.AddScoped<IValidator<RegisterDto>, RegisterUserValidator>();
    }
}