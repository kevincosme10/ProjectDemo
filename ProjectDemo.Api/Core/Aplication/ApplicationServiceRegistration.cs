using FluentValidation;
using MediatR;
using Microsoft.Extensions.Options;
using ProjectDemo.Api.Core.Aplication.Behaviours;
using ProjectDemo.Api.Core.Aplication.Features.Commands.Clients.CreateClient;
using System.Reflection;

namespace ProjectDemo.Api.Core.Aplication
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
           

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}
