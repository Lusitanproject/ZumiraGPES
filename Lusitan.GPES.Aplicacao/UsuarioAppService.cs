using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Aplicacao;
using Lusitan.GPES.Core.Interface.Repositorio;
using System.Reflection;

namespace Lusitan.GPES.Aplicacao
{
    public class UsuarioAppService : BaseAplicacao, IUsuarioAppService
    {
        readonly IUsuarioRepositorio _repositorio;

        public UsuarioAppService(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public List<UsuarioDominio> GetList()
        {
            try
            {
                return _repositorio.GetList();
            }
            catch (Exception ex)
            {
                var _msgErro = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(_msgErro);

                throw new Exception(_msgErro);
            }
        }
    }
}
