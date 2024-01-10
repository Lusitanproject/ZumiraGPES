using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Rest;
using Lusitan.GPES.Front.Blazor.Backend.Interface;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;

namespace Lusitan.GPES.Front.Blazor.Backend
{
	public class Cargo : _webApi, ICargo
	{
		public Cargo(IConfiguration conf)
			: base(conf) { }


		public List<CargoDominio> GetList()
		   => GetList<CargoDominio>("api/GPES/Cargo");

		public CargoDominio GetById(int id)
		{
			try
			{
				var _req = new RestRequest(string.Format("api/GPES/Cargo/{0}", id), Method.Get);

				return new RestClient(Conf.GetSection("WebApi").Value.ToString()).Execute<CargoDominio>(_req).Data;
			}
			catch (Exception ex)
			{
				var _msgErro = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

				TrataErroAcessoAPI(_msgErro);

				throw new Exception(_msgErro);
			}
		}

		public string Add(CargoDominio obj)
			=> Gravar<CargoDominio>("api/GPES/Cargo", obj, Method.Post);

        public string Update(CargoDominio obj)
           => Gravar<CargoDominio>("api/GPES/Cargo", obj, Method.Put);

        public string Remove(int id)
		   => Exclui(string.Format("api/GPES/Cargo/{0}", id));
	}
}
