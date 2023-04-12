using EmployeeManagement.Application.Contracts;
using EmployeeManagement.Application.Services;
using EmployeeManagement.DataAccess.Contracts;
using EmployeeManagement.DataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            return services;
        }
    }
}
