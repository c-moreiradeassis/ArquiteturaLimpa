using ArquiteturaLimpa.Aplicacao.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace ArquiteturaLimpa.Aplicacao.Interfaces
{
    public interface IContatosServico
    {
        Task<ContatosViewModel[]> ListarContatos();
        Task<ContatosViewModel> ListarContato(string nome);
    }
}
