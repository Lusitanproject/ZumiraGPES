using Lusitan.GPES.Core.Base.Interface.CRUD;
using Lusitan.GPES.Core.Entidade;

namespace Lusitan.GPES.Core.Interface.Repositorio
{
    public interface IMeuPerfilRepositorio: IAdd<MeuPerfilDominio>, IRemove
    {
        MeuPerfilDominio BuscaPeloUsuario(int idUsuario);
    }
}
