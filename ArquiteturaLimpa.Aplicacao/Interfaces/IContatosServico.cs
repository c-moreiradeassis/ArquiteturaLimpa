using ArquiteturaLimpa.Aplicacao.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace ArquiteturaLimpa.Aplicacao.Interfaces
{
    public interface IContatosServico
    {
        Task<ContatosViewModel[]> ListarContatos();
        Task<ContatosViewModel> ListarContato(string nome);
        void AdicionarContatos(ContatosViewModel contatos);
        void AtualizarContatos(ContatosViewModel contatos);
        void ExcluirContatos(int id);
        Task<bool> SalvarMudancas();
    }
}
