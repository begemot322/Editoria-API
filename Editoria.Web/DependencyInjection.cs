using Editoria.Web.Filters;

namespace Editoria.Web;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddControllers(options=>
            options.Filters.Add(new ApiExceptionFilter()));
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}