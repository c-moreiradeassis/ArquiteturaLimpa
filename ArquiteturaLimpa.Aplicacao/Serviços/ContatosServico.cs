using ArquiteturaLimpa.Aplicacao.Interfaces;
using ArquiteturaLimpa.Aplicacao.ViewModels;
using ArquiteturaLimpa.Dominio.Interfaces;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;

namespace ArquiteturaLimpa.Aplicacao.Serviços
{
    public class ContatosServico : IContatosServico
    {
        private readonly IContatosRepositorio _contatoRepositorio;
        private readonly IMapper _mapper;

        public ContatosServico(IContatosRepositorio contatoRepositorio, IMapper mapper)
        {
            _contatoRepositorio = contatoRepositorio;
            _mapper = mapper;
        }

        public async Task<ContatosViewModel> ListarContato(string nome)
        {
            var resultado = await _contatoRepositorio.ListarContato(nome);

            return _mapper.Map<ContatosViewModel>(resultado);
        }

        public async Task<ContatosViewModel[]> ListarContatos()
        {
            var resultado = await _contatoRepositorio.ListarContatos();

            return _mapper.Map<ContatosViewModel[]>(resultado);
        }
    }
}
