using Isthmus.Application;
using Isthmus.Infrastructure;

namespace Isthmus.Api;

public static class DependencyInjection
{
    public static void ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureApplication();
        services.ConfigureInfrastructure(configuration);
    }
}