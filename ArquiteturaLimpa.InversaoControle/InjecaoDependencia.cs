using ArquiteturaLimpa.Aplicacao.Interfaces;
using ArquiteturaLimpa.Aplicacao.Mapeamentos;
using ArquiteturaLimpa.Aplicacao.Serviços;
using ArquiteturaLimpa.Dominio.Interfaces;
using ArquiteturaLimpa.Infra.Repositorio.Contexto;
using ArquiteturaLimpa.Infra.Repositorio.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ArquiteturaLimpa.InversaoControle
{
    public static class InjecaoDependencia
    {
        public static IServiceCollection AdicionarInfraRepositorio(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ArquiteturaLimpaContexto>(x => x.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IContatosRepositorio, ContatoRepositorio>();
            services.AddScoped<IContatosServico, ContatosServico>();

            return services;
        }

        public static void AdicionarConfiguracaoAutoMapper(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(ContatosContatosViewModelMapeamento),
                typeof(ContatosViewContatosModelMapeamento));
        }
    }
}
