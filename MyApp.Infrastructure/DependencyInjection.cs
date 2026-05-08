using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MyApp.Core.Interfaces;
using MyApp.Core.Options;
using MyApp.Infrastructure.Data;
using MyApp.Infrastructure.Repositories;
using MyApp.Infrastructure.Services;

namespace MyApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>((provider, options) =>
            {
                ConnectionStringOptions connectionStringOptions =
                    provider.GetRequiredService<IOptionsSnapshot<ConnectionStringOptions>>().Value;
                options.UseSqlServer(connectionStringOptions.DefaultConnection);
            });

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IExternalVendorGateway, ExternalVendorGateway>();

            services.AddHttpClient<IMockiHttpClientService, MockiHttpClientService>((sp, httpClient) =>
            {
                IOptionsMonitor<MockiApiOptions> mockiOptionsMonitor = sp.GetRequiredService<IOptionsMonitor<MockiApiOptions>>();
                httpClient.BaseAddress = new Uri(mockiOptionsMonitor.CurrentValue.BaseAddress);
            });

            services.AddHttpClient<IJokeHttpClientService, JokeHttpClientService>((sp, httpClient) =>
            {
                IOptionsMonitor<JokeApiOptions> jokeOptionsMonitor = sp.GetRequiredService<IOptionsMonitor<JokeApiOptions>>();
                httpClient.BaseAddress = new Uri(jokeOptionsMonitor.CurrentValue.BaseAddress);
            });

            return services;
        }
    }
}
