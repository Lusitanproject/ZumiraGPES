using Lusitan.GPES.Core.Base.Interface.CRUD;
using Lusitan.GPES.Core.Entidade;

namespace Lusitan.GPES.Core.Interface.Aplicacao
{
    public interface IUsuarioPerfilAppService : IAdd<UsuarioPerfilDominio>
    {
        List<PerfilAcessoDominio> GetByUsuario(int idUsuario);

        List<UsuarioDominio> GetByPerfil(int idPerfil);
    }
}
