using ArquiteturaLimpa.Aplicacao.ViewModels;
using ArquiteturaLimpa.Dominio.Entidades;
using AutoMapper;

namespace ArquiteturaLimpa.Aplicacao.Mapeamentos
{
    public class ContatosContatosViewModelMapeamento : Profile
    {
        public ContatosContatosViewModelMapeamento()
        {
            CreateMap<Contatos, ContatosViewModel>();
        }
    }
}
