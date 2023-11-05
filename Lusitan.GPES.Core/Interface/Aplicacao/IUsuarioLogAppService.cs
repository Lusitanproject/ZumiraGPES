using Lusitan.GPES.Core.Base.Interface.CRUD;
using Lusitan.GPES.Core.Entidade;

namespace Lusitan.GPES.Core.Interface.Aplicacao
{
    public interface IUsuarioLogAppService : IAdd<UsuarioLogDominio>
    {
        List<UsuarioLogDominio> GetByUsuario(int idUsuario);
    }
}
