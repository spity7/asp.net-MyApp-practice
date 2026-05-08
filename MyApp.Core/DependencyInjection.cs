using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Core.Options;

namespace MyApp.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStringOptions>(configuration.GetSection(ConnectionStringOptions.SectionName));
            services.Configure<MockiApiOptions>(configuration.GetSection(MockiApiOptions.SectionName));
            services.Configure<JokeApiOptions>(configuration.GetSection(JokeApiOptions.SectionName));

            return services;
        }
    }
}
