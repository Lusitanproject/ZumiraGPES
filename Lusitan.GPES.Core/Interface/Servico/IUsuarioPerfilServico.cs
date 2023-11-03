using Lusitan.GPES.Core.Base.Interface.CRUD;
using Lusitan.GPES.Core.Entidade;

namespace Lusitan.GPES.Core.Interface.Servico
{
    public interface IUsuarioPerfilServico : IAdd<UsuarioPerfilDominio>
    {
        List<UsuarioPerfilDominio> GetByUsuario(int idUsuario);

        List<UsuarioPerfilDominio> GetByPerfil(int idPerfil);
    }
}
