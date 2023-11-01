using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.CRUD;

namespace Lusitan.GPES.Core.Interface.Aplicacao
{
    public interface IUsuarioAppService :   IAppService,
                                            IGetList<UsuarioDominio>
    {
    }
}
