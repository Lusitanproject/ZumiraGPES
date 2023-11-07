using Lusitan.GPES.Core.Entidade;
using RestSharp;
using System.Text.RegularExpressions;

namespace Lusitan.GPES.Aplicacao
{
    public abstract class BaseAplicacao
    {
        protected string RetiraAspas(string txt)
           => Regex.Replace(txt, @"[\u2018\u2019\u201a\u201b\u0022\u201c\u201d\u201e\u201f\u301d\u301e\u301f]", "");

        protected void TrataErro(string msgErro)
        {
            NLog.LogManager.GetCurrentClassLogger().Error(msgErro);
        }

        protected string EnviaEMail(ConfigXMS configXMS, EMailDominio eMail)
        {
            var _reqEnviaEmail = new RestRequest("/api/XMS/controle-mensagem", Method.POST);

            _reqEnviaEmail.AddJsonBody(eMail);

            var _resultado = new RestClient(configXMS.WebApi).Execute(_reqEnviaEmail);

            return _resultado.IsSuccessful? $"Id e-mail: {this.RetiraAspas(_resultado.Content)}": $"Erro ao enviar e-mail: {this.RetiraAspas(_resultado.Content)}";
        }
    }
}
