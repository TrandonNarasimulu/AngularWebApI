using EmployeeManagement.Application.Common.Interfaces;
using EmployeeManagement.Infrastructure.Persistence;
using EmployeeManagement.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IMath, MathService>();

            string dbName = configuration.GetValue<string>("Infrastructure:DatabaseName");
            services.AddDbContext<EmployeeManagementDbContext>(options => options.UseInMemoryDatabase(dbName));

            services.AddScoped<IEmployeeManagementDbContext>(provider => provider.GetService<EmployeeManagementDbContext>());

            return services;
        }
    }
}
