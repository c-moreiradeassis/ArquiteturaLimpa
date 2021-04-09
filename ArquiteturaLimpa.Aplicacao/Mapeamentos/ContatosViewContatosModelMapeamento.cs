using ArquiteturaLimpa.Aplicacao.ViewModels;
using ArquiteturaLimpa.Dominio.Entidades;
using AutoMapper;

namespace ArquiteturaLimpa.Aplicacao.Mapeamentos
{
    public class ContatosViewContatosModelMapeamento : Profile
    {
        public ContatosViewContatosModelMapeamento()
        {
            CreateMap<ContatosViewModel, Contatos>();
        }
    }
}
