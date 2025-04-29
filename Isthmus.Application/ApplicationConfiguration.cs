using System.Reflection;
using FluentValidation;
using Isthmus.Application.Products;
using Isthmus.Application.Products.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Isthmus.Application;

public static class ApplicationConfiguration
{
    public static void ConfigureApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddScoped<IProductService, ProductService>();
    }
}