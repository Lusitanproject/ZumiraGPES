using Lusitan.GPES.Core.Base.Interface.CRUD;
using Lusitan.GPES.Core.Entidade;

namespace Lusitan.GPES.Core.Interface.Servico
{
    public interface IUsuarioLogServico : IAdd<UsuarioLogDominio>
    {
        List<UsuarioLogDominio> GetByUsuario(int idUsuario);
    }
}
