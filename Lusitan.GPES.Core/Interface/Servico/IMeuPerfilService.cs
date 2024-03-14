using Lusitan.GPES.Core.Base.Interface.CRUD;
using Lusitan.GPES.Core.Entidade;

namespace Lusitan.GPES.Core.Interface.Servico
{
    public interface IMeuPerfilService : IAdd<MeuPerfilDominio>, IRemove
    {
        MeuPerfilDominio BuscaPeloUsuario(int idUsuario);
    }
}
