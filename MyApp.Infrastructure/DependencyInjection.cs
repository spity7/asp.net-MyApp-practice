using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MyApp.Core.Interfaces;
using MyApp.Core.Options;
using MyApp.Infrastructure.Data;
using MyApp.Infrastructure.Repositories;

namespace MyApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>((provider, options) =>
            {
                ConnectionStringOptions connectionStringOptions = provider.GetRequiredService<IOptionsSnapshot<ConnectionStringOptions>>().Value;
                options.UseSqlServer(connectionStringOptions.DefaultConnection);
            });

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
