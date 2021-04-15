using System.Threading.Tasks;
using ArquiteturaLimpa.Dominio.Interfaces;
using ArquiteturaLimpa.Infra.Repositorio.Contexto;
using Microsoft.EntityFrameworkCore;

namespace ArquiteturaLimpa.Infra.Repositorio.Repositorios
{
    public class ArquiteturaLimpaRepositorio : IArquiteturaLimpaRepositorio
    {
        private readonly ArquiteturaLimpaContexto _contexto;
        public ArquiteturaLimpaRepositorio(ArquiteturaLimpaContexto contexto)
        {
            _contexto = contexto;
        }
        public void Adicionar<T>(T entidade) where T : class
        {
            _contexto.Add(entidade);
        }

        public void Atualizar<T>(T entidade) where T : class
        {
            _contexto.Update(entidade);
        }

        public void Excluir<T>(T entidade) where T : class
        {
            _contexto.Remove(entidade);
        }

        public async Task<bool> SalvarMudancas()
        {
            return (await _contexto.SaveChangesAsync()) > 0;
        }
    }
}