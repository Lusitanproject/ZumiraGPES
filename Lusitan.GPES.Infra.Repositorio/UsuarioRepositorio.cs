using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Repositorio;

namespace Lusitan.GPES.Infra.Repositorio
{
    public class UsuarioRepositorio : BaseRepositorio, IUsuarioRepositorio
    {
        public UsuarioRepositorio(string strConexao)
            : base(strConexao) { }

        public List<UsuarioDominio> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
