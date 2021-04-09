using ArquiteturaLimpa.Aplicacao.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace ArquiteturaLimpa.Aplicacao.Interfaces
{
    public interface IContatosServico
    {
        Task<IQueryable<ContatosViewModel>> ListarContatos();

        Task<IQueryable<ContatosViewModel>> ListarContato(string nome);
    }
}
