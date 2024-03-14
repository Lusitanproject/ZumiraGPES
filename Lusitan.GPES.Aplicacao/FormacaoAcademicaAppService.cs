using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Aplicacao;
using Lusitan.GPES.Core.Interface.Servico;
using Lusitan.GPES.Core.Servico;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Lusitan.GPES.Aplicacao
{
    public class FormacaoAcademicaAppService: BaseAplicacao, IFormacaoAcademicaAppService
    {
        readonly IFormacaoAcademicaService _servico;

        public FormacaoAcademicaAppService(IFormacaoAcademicaService servico)
            => _servico = servico;

        [ExcludeFromCodeCoverage]
        public List<FormacaoAcademicaDominio> GetList()
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
        public FormacaoAcademicaDominio GetById(int id)
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

        public string Add(FormacaoAcademicaDominio obj)
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

        public string Update(FormacaoAcademicaDominio obj)
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
