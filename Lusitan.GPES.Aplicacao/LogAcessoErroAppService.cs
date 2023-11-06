using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Aplicacao;
using Lusitan.GPES.Core.Interface.Servico;
using System.Reflection;

namespace Lusitan.GPES.Aplicacao
{
    public class LogAcessoErroAppService : BaseAplicacao, ILogAcessoErroAppService
    {
        readonly ILogAcessoErroServico _servico;

        public LogAcessoErroAppService(ILogAcessoErroServico servico)
            => _servico = servico;

        public List<LogAcessoErroDominio> GetByUsuario(int idUsuario)
        {
            try
            {
                return _servico.GetByUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                var _msgErro = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(_msgErro);

                throw new Exception(_msgErro);
            }
        }

        public string Add(LogAcessoErroDominio obj)
        {
            try
            {
                return _servico.Add(obj);
            }
            catch (Exception ex)
            {
                var _msgErro = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(_msgErro);

                throw new Exception(_msgErro);
            }
        }

        public string Delete(int idUsuario)
        {
            try
            {
                return _servico.Delete(idUsuario);
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
