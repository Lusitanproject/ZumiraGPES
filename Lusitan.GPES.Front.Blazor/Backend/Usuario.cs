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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Lusitan.GPES.Front.Blazor.Backend
{
    [ExcludeFromCodeCoverage]
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

        public List<UsuarioDominio> GetList(string nomPerfil)
        {
            try
            {
                var _req = new GPESRequisicao($"api/GPES/Usuario/{nomPerfil}", Method.Get, this.Token);

                return new RestClient(Conf.GetSection("WebApi").Value.ToString()).Execute<List<UsuarioDominio>>(_req).Data;
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
                var _req = new GPESRequisicao("api/GPES/Usuario/altera-senha", Method.Put, this.Token);
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

        public string Add(UsuarioDominio obj, string nomPerfil)
        {
            var _result = string.Empty;
            try
            {
                var _req = new GPESRequisicao($"api/GPES/Usuario/{nomPerfil}", Method.Post, this.Token);
                _req.AddBody(obj);

                var _content = new RestClient(Conf.GetSection("WebApi").Value.ToString()).Execute(_req);

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

        public string Update(int idUsuario, string nomUsuario, string idcAtivo, string idcForcaAlteraSenha, int idUsuarioResp)
        {
            var _result = string.Empty;
            try
            {
                var _req = new GPESRequisicao("api/GPES/Usuario", Method.Put, this.Token);
                _req.AddParameter("idUsuario", idUsuario);
                _req.AddParameter("nomUsuario", nomUsuario);
                _req.AddParameter("idcAtivo", idcAtivo);
                _req.AddParameter("idcForcaAlteraSenha", idcForcaAlteraSenha);
                _req.AddParameter("idUsuarioResp", idUsuarioResp);

                var _content = new RestClient(Conf.GetSection("WebApi").Value.ToString()).Execute(_req);

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

        public string ReenviaSenha(int idUsuario, int idUsuarioResp)
        {
            var _result = string.Empty;
            try
            {
                var _req = new GPESRequisicao("api/GPES/Usuario/reenvia-senha-email", Method.Put, this.Token);
                _req.AddParameter("idUsuario", idUsuario);
                _req.AddParameter("idUsuarioResp", idUsuarioResp);

                var _content = new RestClient(Conf.GetSection("WebApi").Value.ToString()).Execute(_req);

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

        public List<UsuarioLogDominio> GetLog(int idUsuario)
        {
            try
            {
                var _req = new GPESRequisicao($"api/GPES/Usuario/log/{idUsuario}", Method.Get, this.Token);

                return new RestClient(Conf.GetSection("WebApi").Value.ToString()).Execute<List<UsuarioLogDominio>>(_req).Data;
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
