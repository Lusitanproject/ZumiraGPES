using Lusitan.GPES.Core.Base.Interface.CRUD;
using Lusitan.GPES.Core.Entidade;

namespace Lusitan.GPES.Core.Interface.Repositorio
{
    public interface IUsuarioLogRepositorio: IAdd<UsuarioLogDominio>
    {
        List<UsuarioLogDominio> GetByUsuario(int idUsuario);
    }
}
