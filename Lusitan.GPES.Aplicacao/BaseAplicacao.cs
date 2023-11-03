
using Lusitan.GPES.Core.Entidade;
using RestSharp;
using System.Net.Http.Headers;

namespace Lusitan.GPES.Aplicacao
{
    public abstract class BaseAplicacao
    {
        readonly ConfigXMS _configXMS;

        public BaseAplicacao(ConfigXMS configXMS)
        {
            _configXMS = configXMS;
        }

        public BaseAplicacao() { }

        protected void TrataErro(string msgErro)
        {
            this.EnviaEMail(new EMailDominio()
            {
                NumRemetente = _configXMS.IdRemetenteMsgErro,
                DescAssunto = "Erro de Sistema",
                NomDestino = _configXMS.DestinoEMailErroSistema,
                DescMensagem = msgErro
            });

            NLog.LogManager.GetCurrentClassLogger().Error(msgErro);
        }

        protected string EnviaEMail(EMailDominio eMail)
        {
            var _reqEnviaEmail = new RestRequest("/api/XMS/controle-mensagem", Method.Post);

            _reqEnviaEmail.AddJsonBody(eMail);

            var _resultado = new RestClient(_configXMS.WebApi).Execute(_reqEnviaEmail);

            if (_resultado.IsSuccessful)
            {
                return _resultado.Content;
            }
            else
            {
                throw new Exception($"Erro ao enviar email: {_resultado.Content}");
            }
        }
    }
}
