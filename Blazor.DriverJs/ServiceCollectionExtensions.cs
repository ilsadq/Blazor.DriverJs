using Microsoft.Extensions.DependencyInjection;

namespace Blazor.DriverJs;
public static class ServiceCollectionExtensions
{
    public static void RegisterDriverJs(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IDriverJs, DriverJs>();
    }
}