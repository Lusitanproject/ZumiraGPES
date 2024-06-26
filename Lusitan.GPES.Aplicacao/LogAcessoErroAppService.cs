﻿using Lusitan.GPES.Core.Config;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Aplicacao;
using Lusitan.GPES.Core.Interface.Servico;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Lusitan.GPES.Aplicacao
{
    public class LogAcessoErroAppService : BaseAplicacao, ILogAcessoErroAppService
    {
        readonly ILogAcessoErroServico _servico;

        public LogAcessoErroAppService(ConfigXMS configXMS, ILogAcessoErroServico servico)
            : base(configXMS)
            => _servico = servico;

		[ExcludeFromCodeCoverage]
		public List<LogAcessoErroDominio> GetByUsuario(int idUsuario)
        {
            try
            {
                return _servico.GetByUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                var _msgErro = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(_msgErro);

                throw new Exception(_msgErro);
            }
        }

        public string Add(LogAcessoErroDominio obj)
        {
            try
            {
                return _servico.Add(obj);
            }
            catch (Exception ex)
            {
                var _msgErro = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(_msgErro);

                throw new Exception(_msgErro);
            }
        }

        public string Delete(int idUsuario)
        {
            try
            {
                return _servico.Delete(idUsuario);
            }
            catch (Exception ex)
            {
                var _msgErro = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(_msgErro);

                throw new Exception(_msgErro);
            }
        }
    }
}
