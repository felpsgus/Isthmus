using Isthmus.Domain.Repositories;
using Isthmus.Infrastructure.Persistence;
using Isthmus.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Isthmus.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddPersistence(configuration);
        services.AddRepositories();

        return services;
    }

    private static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        var environmentConnectionString = Environment.GetEnvironmentVariable("ENVIRONMENT_CONNECTION");
        services.AddDbContext<IsthmusDbContext>(options =>
            options.UseSqlServer(string.IsNullOrEmpty(environmentConnectionString)
                ? connectionString
                : environmentConnectionString));
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
    }
}