using ArquiteturaLimpa.Aplicacao.Mapeamentos;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ArquiteturaLimpa.Servico.ConfiguracaoAutoMapper
{
    public static class AutoMapperConfiguracao
    {
        public static void AdicionarConfiguracaoAutoMapper(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(ContatosContatosViewModelMapeamento),
                typeof(ContatosViewContatosModelMapeamento));
        }
    }
}
