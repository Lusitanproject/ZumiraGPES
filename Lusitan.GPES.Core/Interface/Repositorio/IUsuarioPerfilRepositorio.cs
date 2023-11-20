using Lusitan.GPES.Core.Base.Interface.CRUD;
using Lusitan.GPES.Core.Entidade;

namespace Lusitan.GPES.Core.Interface.Repositorio
{
    public interface IUsuarioPerfilRepositorio: IAdd<UsuarioPerfilDominio>
    {
        List<UsuarioPerfilDominio> GetByUsuario(int idUsuario);

        List<UsuarioPerfilDominio> GetByPerfil(int idPerfil);

        string Remove(UsuarioPerfilDominio obj);
    }
}
