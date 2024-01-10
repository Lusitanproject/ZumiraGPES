using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Front.Blazor.Backend.Interface;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Collections.Generic;
using System.Reflection;
using System;

namespace Lusitan.GPES.Front.Blazor.Backend
{
    public class Empresa : _webApi, IEmpresa
    {
        public Empresa(IConfiguration conf)
            : base(conf) { }

        public List<EmpresaDominio> GetList()
           => GetList<EmpresaDominio>("api/GPES/Empresa");

        public EmpresaDominio GetById(int id)
        {
            try
            {
                var _req = new RestRequest(string.Format("api/GPES/Empresa/{0}", id), Method.Get);

                return new RestClient(Conf.GetSection("WebApi").Value.ToString()).Execute<EmpresaDominio>(_req).Data;
            }
            catch (Exception ex)
            {
                var _msgErro = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErroAcessoAPI(_msgErro);

                throw new Exception(_msgErro);
            }
        }

        public string Add(EmpresaDominio obj)
            => Gravar<EmpresaDominio>("api/GPES/Empresa", obj, Method.Post);

        public string Update(EmpresaDominio obj)
           => Gravar<EmpresaDominio>("api/GPES/Empresa", obj, Method.Put);

        public string Remove(int id)
           => Exclui(string.Format("api/GPES/Empresa/{0}", id));
    }
}
