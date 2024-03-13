using Lusitan.GPES.Core.Base.Interface.CRUD;
using Lusitan.GPES.Core.Entidade;

namespace Lusitan.GPES.Core.Interface.Servico
{
    public interface IFormacaoAcademicaService : IGetList<FormacaoAcademicaDominio>,
                                                 IGetById<FormacaoAcademicaDominio>,
                                                 IAdd<FormacaoAcademicaDominio>,
                                                 IUpdate<FormacaoAcademicaDominio>,
                                                 IRemove
    {
    }
}
