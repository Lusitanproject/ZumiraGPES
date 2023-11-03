using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Aplicacao;
using Lusitan.GPES.Core.Interface.Servico;
using System.Reflection;

namespace Lusitan.GPES.Aplicacao
{
    public class PerfilAcessoAppService : BaseAplicacao, IPerfilAcessoAppService
    {
        readonly IPerfilAcessoServico _servico;

        public PerfilAcessoAppService(IPerfilAcessoServico servico)
           => _servico = servico;

        public PerfilAcessoDominio GetById(int id)
        {
            try
            {
                return _servico.GetById(id);
            }
            catch (Exception ex)
            {
                var _msgErro = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(_msgErro);

                throw new Exception(_msgErro);
            }
        }

        public List<PerfilAcessoDominio> GetList()
        {
            try
            {
                return _servico.GetList();
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
