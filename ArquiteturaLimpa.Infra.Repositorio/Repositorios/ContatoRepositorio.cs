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
        private readonly ArquiteturaLimpaContexto _arquiteturaLimpaContexto;

        public ContatoRepositorio(ArquiteturaLimpaContexto arquiteturaLimpaContexto)
        {
            _arquiteturaLimpaContexto = arquiteturaLimpaContexto;
        }
        public async Task<Contatos> ListarContato(string nome)
        {
            IQueryable<Contatos> contatos = _arquiteturaLimpaContexto.Contatos.Where(c => c.Nome.Trim().Contains(nome));

            return await contatos.FirstOrDefaultAsync();
        }

        public async Task<Contatos[]> ListarContatos()
        {
            IQueryable<Contatos> contatos = _arquiteturaLimpaContexto.Contatos;

            return await contatos.ToArrayAsync();
        }
    }
}
