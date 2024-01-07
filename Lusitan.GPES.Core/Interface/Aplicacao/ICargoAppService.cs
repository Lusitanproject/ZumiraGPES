using Lusitan.GPES.Core.Base.Interface.CRUD;
using Lusitan.GPES.Core.Entidade;

namespace Lusitan.GPES.Core.Interface.Aplicacao
{
    public interface ICargoAppService : IGetList<CargoDominio>,
                                         IGetById<CargoDominio>,
                                         IAdd<CargoDominio>,
                                         IUpdate<CargoDominio>
    {
    }
}
