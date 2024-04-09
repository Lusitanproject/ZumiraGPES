
using Lusitan.GPES.Core.Config;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Aplicacao;
using Lusitan.GPES.Core.Interface.Servico;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Lusitan.GPES.Aplicacao
{
    public class EmpresaAppService : BaseAplicacao, IEmpresaAppService
    {
        readonly IEmpresaServico _servico;

        public EmpresaAppService(ConfigXMS configXMS, IEmpresaServico servico)
            : base(configXMS)
            => _servico = servico;

        [ExcludeFromCodeCoverage]
        public List<EmpresaDominio> GetList()
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

        [ExcludeFromCodeCoverage]
        public EmpresaDominio GetById(int id)
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

        [ExcludeFromCodeCoverage]
        public EmpresaDominio BuscaPeloNome(string nomEmpresa)
        {
            try
            {
                return _servico.BuscaPeloNome(nomEmpresa);
            }
            catch (Exception ex)
            {
                var _msgErro = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(_msgErro);

                throw new Exception(_msgErro);
            }
        }

        public string Add(EmpresaDominio obj)
        {
            try
            {
                return _servico.BuscaPeloNome(obj.NomEmpresa) == null ? _servico.Add(obj) : string.Empty;
            }
            catch (Exception ex)
            {
                var _msgErro = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(_msgErro);

                throw new Exception(_msgErro);
            }
        }

        public string Update(EmpresaDominio obj)
        {
            try
            {
                return _servico.Update(obj);
            }
            catch (Exception ex)
            {
                var _msgErro = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(_msgErro);

                throw new Exception(_msgErro);
            }
        }

        public string Remove(int id)
        {
            try
            {
                return _servico.Remove(id);
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
