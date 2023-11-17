using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Front.Blazor.Backend.Interface;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Reflection;
using System;
using System.Globalization;
using Lusitan.GPES.Core.Response;
using Lusitan.GPES.Core.Request;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Lusitan.GPES.Core.Rest;

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
                var _req = new RestRequest($"api/GPES/Usuario/login", Method.Post);
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
            try
            {
                var _req = new RestRequest(string.Format("api/GPES/Usuario/busca-por-email/{0}", eMail.Trim()), Method.Get);

                return new RestClient(Conf.GetSection("WebApi").Value.ToString()).Execute<UsuarioDominio>(_req).Data;
            }
            catch (Exception ex)
            {
                var _msgErro = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErroAcessoAPI(_msgErro);

                throw new Exception(_msgErro);
            }
        }

        public UsuarioDominio GetById(int id)
        {
            try
            {
                var _req = new RestRequest(string.Format("api/GPES/Usuario/busca-por-id/{0}", id), Method.Get);

                return new RestClient(Conf.GetSection("WebApi").Value.ToString()).Execute<UsuarioDominio>(_req).Data;
            }
            catch (Exception ex)
            {
                var _msgErro = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErroAcessoAPI(_msgErro);

                throw new Exception(_msgErro);
            }
        }

        public string AlteraSenha(AlteraSenhaRequest obj)
        {
            var _result = string.Empty;
            try
            {
                var _req = new GPESRequisicao("api/GPES/Usuario/altera-senha", Method.Post, this.Token);
                _req.AddBody(obj);

                var _content =  new RestClient(Conf.GetSection("WebApi").Value.ToString()).Execute(_req);

                switch (_content.StatusCode)
                {
                    case HttpStatusCode.Unauthorized:
                        _result = "Acesso Negado!";
                        break;

                    case HttpStatusCode.OK:
                    case HttpStatusCode.BadRequest:
                        _result = _content.Content.Replace("\"", "");
                        break;
                }

                return _result;
            }
            catch (Exception ex)
            {
                var _msgErro = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErroAcessoAPI(_msgErro);

                throw new Exception(_msgErro);
            }
        }
    }
}
