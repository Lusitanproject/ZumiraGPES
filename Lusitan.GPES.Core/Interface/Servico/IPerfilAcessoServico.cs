using Lusitan.GPES.Core.Base.Interface.CRUD;
using Lusitan.GPES.Core.Entidade;

namespace Lusitan.GPES.Core.Interface.Servico
{
    public interface IPerfilAcessoServico : IGetList<PerfilAcessoDominio>,
                                            IGetById<PerfilAcessoDominio>
    {
    }
}
