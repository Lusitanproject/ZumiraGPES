using Lusitan.GPES.Core.Config;
using Lusitan.GPES.Core.Entidade;
using RestSharp;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Lusitan.GPES.Aplicacao
{
    [ExcludeFromCodeCoverage]
    public abstract class BaseAplicacao
    {
        readonly ConfigXMS _configXMS;

        public BaseAplicacao(ConfigXMS configXMS)
            => _configXMS = configXMS;

        protected string RetiraAspas(string txt)
           => Regex.Replace(txt, @"[\u2018\u2019\u201a\u201b\u0022\u201c\u201d\u201e\u201f\u301d\u301e\u301f]", "");

        protected string RemovePrimeiroEUltimo(string txt)
            => txt.Substring(1, txt.Length - 2);

        protected void TrataErro(string msgErro)
        {
            NLog.LogManager.GetLogger("fileTarget").Error(msgErro);

            this.EnviaEMail( new EMailDominio()
            {
                NumRemetente = _configXMS.IdRemetenteMsgSistema,
                NomDestino = _configXMS.DestinoEMailErroSistema,
                DescAssunto = "Erro GPES",
                DescMensagem = msgErro
            });
        }

        protected string EnviaEMail(EMailDominio eMail)
        {
            var _reqEnviaEmail = new RestRequest("/api/XMS/controle-mensagem", Method.Post);
            _reqEnviaEmail.RequestFormat = DataFormat.Json;

            _reqEnviaEmail.AddBody(eMail);

            var _resultado = new RestClient(_configXMS.WebApi).Execute(_reqEnviaEmail);

            if (_resultado.IsSuccessful)
            {
                return $"Id e-mail: {this.RetiraAspas(_resultado.Content)}";
            }
            else
            {
                var _msg = $"Erro ao enviar e-mail: {_resultado.Content}";

                TrataErro(_msg);

                return _msg;
            }
        }
    }
}
