using Lusitan.GPES.Core.Base.Interface.CRUD;
using Lusitan.GPES.Core.Entidade;

namespace Lusitan.GPES.Core.Interface.Repositorio
{
    public interface IMinhaFormacaoRepositorio : IAdd<MinhaFormacaoDominio>,
                                                 IRemove
    {
        List<MinhaFormacaoDominio> BuscaPeloUsuario(int idUsuario);
    }
}
