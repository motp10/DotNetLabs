using Microsoft.Extensions.DependencyInjection;

namespace PresentationHttp;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddPresentationHttp(this IServiceCollection collection)
    {
        collection.AddControllers();
        return collection;
    }
}
