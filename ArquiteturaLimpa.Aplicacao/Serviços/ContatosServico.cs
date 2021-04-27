using ArquiteturaLimpa.Aplicacao.Interfaces;
using ArquiteturaLimpa.Aplicacao.ViewModels;
using ArquiteturaLimpa.Dominio.Entidades;
using ArquiteturaLimpa.Dominio.Interfaces;
using AutoMapper;
using System.Threading.Tasks;

namespace ArquiteturaLimpa.Aplicacao.Serviços
{
    public class ContatosServico : IContatosServico
    {
        private readonly IContatosRepositorio _contatoRepositorio;
        private readonly IArquiteturaLimpaRepositorio _arquiteturaLimpaRepositorio;
        private readonly IMapper _mapper;

        public ContatosServico(IContatosRepositorio contatoRepositorio,
        IArquiteturaLimpaRepositorio arquiteturaLimpaRepositorio,
        IMapper mapper)
        {
            _contatoRepositorio = contatoRepositorio;
            _arquiteturaLimpaRepositorio = arquiteturaLimpaRepositorio;
            _mapper = mapper;
        }

        public void AdicionarContatos(ContatosViewModel contatosViewModel)
        {
            var contato = _mapper.Map<Contatos>(contatosViewModel);

            _arquiteturaLimpaRepositorio.Adicionar(contato);
        }

        public void AtualizarContatos(ContatosViewModel contatosViewModel)
        {
            var contatoExistente = _contatoRepositorio.ListarContato(contatosViewModel.Id);

            if (contatoExistente != null)
            {
                var contato = _mapper.Map<Contatos>(contatosViewModel);

                _arquiteturaLimpaRepositorio.Atualizar(contato);
            }
        }

        public void ExcluirContatos(int id)
        {
            var resultado = _contatoRepositorio.ListarContato(id).Result;

            var contato = _mapper.Map<Contatos>(resultado);

            _arquiteturaLimpaRepositorio.Excluir(contato);
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

        public Task<bool> SalvarMudancas()
        {
            return _arquiteturaLimpaRepositorio.SalvarMudancas();
        } 
    }
}
