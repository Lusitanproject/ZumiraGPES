using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Reflection;
using System;
using Lusitan.GPES.Core.Rest;
using RestSharp;
using System.Linq;

namespace Lusitan.GPES.Front.Blazor.Backend
{
    public abstract class _webApi
    {
        readonly IConfiguration _conf;

        public _webApi(IConfiguration conf)
           => _conf = conf;

        string _token;
        public string Token
        {
            set { _token = value; }
            get { return "Bearer " + _token; }
        }

        public int NumUsuario { get; set; }

        protected IConfiguration Conf
        {
            get { return _conf; }
        }


        protected void TrataErroAcessoAPI(string msgErro)
        {
            NLog.LogManager.GetCurrentClassLogger().Error(msgErro);

            throw new Exception(msgErro);
        }

        protected List<T> GetList<T>(string url)
        {
            try
            {
                var _r = new GPESRequisicao(url, Method.Get, this.Token);
                var _cliente = new RestClient(Conf.GetSection("WebApi").Value.ToString()).Execute<List<T>>(_r);

                return (_cliente.Data).ToList();
            }
            catch (Exception ex)
            {
                var _msgErro = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErroAcessoAPI(_msgErro);

                throw new Exception(_msgErro);
            }
        }

        protected T GetObj<T>(string url)
        {
            try
            {
                var _r = new GPESRequisicao(url, Method.Get, this.Token);
                var _cliente = new RestClient(Conf.GetSection("WebApi").Value.ToString()).Execute<T>(_r);

                return _cliente.Data;
            }
            catch (Exception ex)
            {
                var _msgErro = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErroAcessoAPI(_msgErro);

                throw new Exception(_msgErro);
            }
        }

        protected string Gravar<T>(string url, T obj, Method metodo)
        {
            try
            {
                var _msgValidacao = string.Empty;

                var _r = new GPESRequisicao(url, metodo, this.Token);
                _r.AddBody(obj);

                var _resultado = new RestClient(Conf.GetSection("WebApi").Value.ToString()).Execute(_r);

                return _resultado.IsSuccessful ? string.Empty : GPESUtil.RemovePrimeiroEUltimo(_resultado.Content);
            }
            catch (Exception ex)
            {
                var _msgErro = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErroAcessoAPI(_msgErro);

                throw new Exception(_msgErro);
            }
        }

        protected string Exclui(string url)
        {
            try
            {
                var _r = new GPESRequisicao(url, Method.Delete, this.Token);

                var _resultado = new RestClient(Conf.GetSection("WebApi").Value.ToString()).Execute(_r);

                return _resultado.IsSuccessful ? string.Empty : GPESUtil.RemovePrimeiroEUltimo(_resultado.Content);
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
