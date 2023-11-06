using Lusitan.GPES.Core.Base.Interface.CRUD;
using Lusitan.GPES.Core.Entidade;

namespace Lusitan.GPES.Core.Interface.Aplicacao
{
    public interface ILogAcessoErroAppService : IAdd<LogAcessoErroDominio>
    {
        List<LogAcessoErroDominio> GetByUsuario(int idUsuario);

        string Delete(int idUsuario);
    }
}
