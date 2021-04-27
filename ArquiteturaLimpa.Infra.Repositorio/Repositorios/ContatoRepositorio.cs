using ArquiteturaLimpa.Dominio.Entidades;
using ArquiteturaLimpa.Dominio.Interfaces;
using ArquiteturaLimpa.Infra.Repositorio.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ArquiteturaLimpa.Infra.Repositorio.Repositorios
{
    public class ContatoRepositorio : IContatosRepositorio
    {
        private readonly ArquiteturaLimpaContexto _contexto;

        public ContatoRepositorio(ArquiteturaLimpaContexto contexto)
        {
            _contexto = contexto;

            _contexto.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public async Task<Contatos> ListarContato(string nome)
        {
            IQueryable<Contatos> contatos = _contexto.Contatos.Where(c => c.Nome.Trim().Contains(nome));

            return await contatos.FirstOrDefaultAsync();
        }

        public async Task<Contatos> ListarContato(int id)
        {
            IQueryable<Contatos> contatos = _contexto.Contatos.Where(c => c.Id == id);

            return await contatos.FirstOrDefaultAsync();
        }

        public async Task<Contatos[]> ListarContatos()
        {
            IQueryable<Contatos> contatos = _contexto.Contatos;

            return await contatos.ToArrayAsync();
        }
    }
}
