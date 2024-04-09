using Lusitan.GPES.Core.Config;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Aplicacao;
using Lusitan.GPES.Core.Interface.Servico;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Lusitan.GPES.Aplicacao
{
    public class UsuarioLogAppService : BaseAplicacao, IUsuarioLogAppService
    {
        readonly IUsuarioLogServico _servico;

        public UsuarioLogAppService(ConfigXMS configXMS, IUsuarioLogServico servico)
            : base(configXMS)
           => _servico = servico;

		[ExcludeFromCodeCoverage]
		public List<UsuarioLogDominio> GetByUsuario(int idUsuario)
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

        public string Add(UsuarioLogDominio obj)
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
    }
}
