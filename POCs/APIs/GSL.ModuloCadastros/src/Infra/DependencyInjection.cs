using Domain.Interfaces.Contextos;
using Domain.Interfaces.Mensageria;
using Domain.Interfaces.Repositories;
using Infra.Contexts;
using Infra.Mensageria;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.EntityFrameworkCore.Extensions;

namespace Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkMySQL()
              .AddDbContext<CadastroDbContext>(options => options.UseMySQL(configuration.GetConnectionString("DefaultDatabase")));
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IUnitOfWork, CadastroDbContext>();

            services.AddScoped<IClienteProducer, ClienteProducer>();

            return services;
        }
    }
}