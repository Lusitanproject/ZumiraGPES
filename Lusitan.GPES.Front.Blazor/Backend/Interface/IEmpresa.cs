using Lusitan.GPES.Core.Base.Interface.CRUD;
using Lusitan.GPES.Core.Entidade;

namespace Lusitan.GPES.Front.Blazor.Backend.Interface
{
    public interface IEmpresa : IFrontEnd,
                                IGetList<EmpresaDominio>,
                                IGetById<EmpresaDominio>,
                                IAdd<EmpresaDominio>,
                                IUpdate<EmpresaDominio>,
                                IRemove
    {
    }
}
