using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Rest;
using Lusitan.GPES.Front.Blazor.Backend.Interface;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Reflection;

namespace Lusitan.GPES.Front.Blazor.Backend
{
    [ExcludeFromCodeCoverage]
    public class UsuarioPerfil : _webApi, IUsuarioPerfil
    {
        public UsuarioPerfil(IConfiguration conf)
            : base(conf) { }

        public string ExcluiUsuarioPErfil(UsuarioPerfilDominio obj)
        {
            var _result = string.Empty;
            try
            {
                var _req = new GPESRequisicao("api/GPES/UsuarioPerfil/usuario-perfil", Method.Delete, this.Token);
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

        public List<PerfilAcessoDominio> GetListPerfil()
        {
            try
            {
                var _req = new GPESRequisicao("api/GPES/UsuarioPerfil/perfil-acesso", Method.Get, this.Token);

                return new RestClient(Conf.GetSection("WebApi").Value.ToString()).Execute<List<PerfilAcessoDominio>>(_req).Data;
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
