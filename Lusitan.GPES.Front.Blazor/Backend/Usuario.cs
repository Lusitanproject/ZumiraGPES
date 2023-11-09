using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Front.Blazor.Backend.Interface;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Reflection;
using System;

namespace Lusitan.GPES.Front.Blazor.Backend
{
    public class Usuario : _webApi, IUsuario
    {
        public Usuario(IConfiguration conf)
            : base(conf) { }

        public LoginResponse Login(string eMail, string pwd)
        {
            try
            {
                var _req = new RestRequest("api/GPES/Usuario/login", Method.Post);
                _req.AddBody( new LoginRequest() { EMail = eMail, Pwd = pwd } );

                return new RestClient(Conf.GetSection("WebApi").Value.ToString()).Execute<LoginResponse>(_req).Data;
            }
            catch (Exception ex)
            {
                var _msgErro = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErroAcessoAPI(_msgErro);

                throw new Exception(_msgErro);
            }
        }

        public UsuarioDominio BuscaPeloEMail(string eMail)
        {
            throw new System.NotImplementedException();
        }

        public UsuarioDominio GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
