using Microsoft.EntityFrameworkCore;
using ProjectDemo.Api.Core.Aplication.Interfaces;
using ProjectDemo.Api.Infrastructure.Persistence;
using ProjectDemo.Api.Infrastructure.Repositories;

namespace ProjectDemo.Api.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApiContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ClientConnection"))
            );
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IClientRepository, ClientRepository>();
            //services.AddScoped<IStreamerRepository, StreamerRepository>();

            //services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            //services.AddTransient<IEmailService, EmailService>();

            return services;
        }

    }
}

