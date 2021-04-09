using System.Threading.Tasks;
using ArquiteturaLimpa.Dominio.Entidades;

namespace ArquiteturaLimpa.Dominio.Interfaces
{
    public interface IContatosRepositorio
    {
        Task<Contatos[]> ListarContatos();
        Task<Contatos> ListarContato(string nome);
    }
}