using Application.Contracts.ServicesInterfaces;
using Application.Servises;

namespace Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IAdminServise, AdminService>();
        collection.AddScoped<IUserServise, UserService>();
        collection.AddScoped<ISessionService, SessionService>();

        return collection;
    }
}