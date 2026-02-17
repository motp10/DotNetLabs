using Application.Abstraction;
using Application.Abstraction.Repositories;
using Infrastracture.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastracture.Persistence;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection collection)
    {
        collection.AddSingleton<IAccountRepository, AccountRepository>();
        collection.AddSingleton<ISessionsRepository, SessionsRepository>();
        collection.AddSingleton<IHistoryRepository, HistoryRepository>();
        collection.AddSingleton<IAdminPasswordRepository, AdminPasswordRepository>();
        collection.AddScoped<IPersistenceContext, PersistenceContext>();
        return collection;
    }
}