using System.Threading.Tasks;

namespace ArquiteturaLimpa.Dominio.Interfaces
{
    public interface IArquiteturaLimpaRepositorio
    {
         void Adicionar<T>(T entidade) where T : class;
         void Atualizar<T>(T entidade) where T : class;
         void Excluir<T>(T entidade) where T : class;
         Task<bool> SalvarMudancas();
    }
}