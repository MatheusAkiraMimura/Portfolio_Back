using Microsoft.Extensions.DependencyInjection;
using Portfolio.Interfaces;
using Portfolio.Interfaces.Repository;
using Portfolio.Repository;
using Portfolio.Services;

namespace Portfolio.Dependency
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Registro de repositórios
            services.AddScoped<IUserRepository, UserRepository>();

            // Registro de serviços
            services.AddScoped<IUserService, UserService>();

            // Outros serviços e repositórios podem ser adicionados aqui

            return services;
        }
    }
}
