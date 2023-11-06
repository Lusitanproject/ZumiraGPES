using Lusitan.GPES.Core.Base.Interface.CRUD;
using Lusitan.GPES.Core.Entidade;

namespace Lusitan.GPES.Core.Interface.Repositorio
{
    public interface ILogAcessoErroRepositorio : IAdd<LogAcessoErroDominio>
    {
        List<LogAcessoErroDominio> GetByUsuario(int idUsuario);

        string Delete(int idUsuario);
    }
}
