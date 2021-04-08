using System.Threading.Tasks;
using ArquiteturaLimpa.Dominio.Entidades;

namespace ArquiteturaLimpa.Dominio.Interfaces
{
    public interface IContatoRepositorio
    {
        Task<Contatos[]> ListarContatos();
        Task<Contatos> ListarContato();
    }
}