using Lusitan.GPES.Core.Base.Interface.CRUD;
using Lusitan.GPES.Core.Entidade;

namespace Lusitan.GPES.Core.Interface.Aplicacao
{
    public interface IEmpresaAppService : IGetList<EmpresaDominio>,
                                         IGetById<EmpresaDominio>,
                                         IAdd<EmpresaDominio>,
                                         IUpdate<EmpresaDominio>,
                                         IRemove
    {
        EmpresaDominio BuscaPeloNome(string nomEmpresa);
    }
}
