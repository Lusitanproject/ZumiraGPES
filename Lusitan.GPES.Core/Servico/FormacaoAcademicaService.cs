using Lusitan.GPES.Core.Base;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Repositorio;
using Lusitan.GPES.Core.Interface.Servico;
using System.Reflection;

namespace Lusitan.GPES.Core.Servico
{
    public class FormacaoAcademicaService : BaseServico, IFormacaoAcademicaService
    {
        public FormacaoAcademicaService(IUnitOfWork repositorio)
            : base(repositorio) { }

        public List<FormacaoAcademicaDominio> GetList()
           => _repositorio.Formacao.GetList();

        public FormacaoAcademicaDominio GetById(int id)
           => _repositorio.Formacao.GetById(id);

        public string Add(FormacaoAcademicaDominio obj)
        {
            var _resultado = string.Empty;

            try
            {
                _repositorio.Formacao.Add(obj);
            }
            catch (Exception ex)
            {
                _resultado = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;
            }

            return _resultado;
        }

        public string Update(FormacaoAcademicaDominio obj)
        {
            var _resultado = string.Empty;

            try
            {
                _repositorio.Formacao.Update(obj);
            }
            catch (Exception ex)
            {
                _resultado = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;
            }

            return _resultado;
        }

        public string Remove(int id)
        {
            var _resultado = string.Empty;

            try
            {
                _repositorio.Formacao.Remove(id);
            }
            catch (Exception ex)
            {
                _resultado = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;
            }

            return _resultado;
        }
    }
}
