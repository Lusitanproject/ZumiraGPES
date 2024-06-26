﻿using Lusitan.GPES.Core.Config;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Aplicacao;
using Lusitan.GPES.Core.Interface.Servico;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Lusitan.GPES.Aplicacao
{
	[ExcludeFromCodeCoverage]
	public class PerfilAcessoAppService : BaseAplicacao, IPerfilAcessoAppService
    {
        readonly IPerfilAcessoServico _servico;

        public PerfilAcessoAppService(ConfigXMS configXMS, IPerfilAcessoServico servico)
            : base(configXMS)
           => _servico = servico;

		public PerfilAcessoDominio GetById(int id)
        {
            try
            {
                return _servico.GetById(id);
            }
            catch (Exception ex)
            {
                var _msgErro = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(_msgErro);

                throw new Exception(_msgErro);
            }
        }

        public List<PerfilAcessoDominio> GetList()
        {
            try
            {
                return _servico.GetList();
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
