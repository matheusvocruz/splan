using CalculoJuros.Application.Interfaces.Queries;
using CalculoJuros.Application.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace CalculoJuros.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //Queries
            services.AddScoped<ICalculoJurosQueries, CalculoJurosQueries>();
        }
    }
}
