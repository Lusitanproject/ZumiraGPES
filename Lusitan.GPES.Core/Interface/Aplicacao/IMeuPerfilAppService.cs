using Lusitan.GPES.Core.Base.Interface.CRUD;
using Lusitan.GPES.Core.Entidade;

namespace Lusitan.GPES.Core.Interface.Aplicacao
{
    public interface IMeuPerfilAppService : IAdd<MeuPerfilRequest>, IRemove
    {
        MeuPerfilResponse BuscaPeloUsuario(int idUsuario);
    }
}
