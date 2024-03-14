using Lusitan.GPES.Core.Base.Interface.CRUD;
using Lusitan.GPES.Core.Entidade;

namespace Lusitan.GPES.Core.Interface.Aplicacao
{
    public interface IMinhaFormacaoAppService : IAdd<MinhaFormacaoDominio>,
                                                IRemove
    {
        List<MinhaFormacaoViewDominio> BuscaPeloUsuario(int idUsuario);
    }
}
