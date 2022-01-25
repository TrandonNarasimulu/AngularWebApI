using EmployeeManagement.Application.Common.Behaviours;
using EmployeeManagement.Application.EmployeeManagement.Commands.CreateEmployee;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EmployeeManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddValidatorsFromAssembly(typeof(CreateEmployeeCommandValidator).Assembly);

            return services;
        }
    }
}
