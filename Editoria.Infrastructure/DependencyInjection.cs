using Editoria.Application.Common.Interfaces;
using Editoria.Infrastructure.Cache;
using Editoria.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Editoria.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDatabase(configuration);
        services.AddRedisCache(configuration);

        return services;
    }
    private static IServiceCollection AddDatabase(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseNpgsql(connString));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
    private static IServiceCollection AddRedisCache(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("Redis");
            options.InstanceName = "Editoria_";
        });
        
        services.AddScoped<IRedisCacheService, RedisCacheService>();
        
        return services;
    }


}