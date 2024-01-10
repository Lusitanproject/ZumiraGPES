using Lusitan.GPES.Core.Base;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Repositorio;
using Lusitan.GPES.Core.Interface.Servico;
using System.Reflection;

namespace Lusitan.GPES.Core.Servico
{
    public class EmpresaServico : BaseServico, IEmpresaServico
    {
        public EmpresaServico(IUnitOfWork repositorio)
            : base(repositorio) { }

        public List<EmpresaDominio> GetList()
           => _repositorio.Empresa.GetList();

        public EmpresaDominio GetById(int id)
           => _repositorio.Empresa.GetById(id);

        public EmpresaDominio BuscaPeloNome(string nomEmpresa)
           => _repositorio.Empresa.BuscaPeloNome(nomEmpresa);

        public string Add(EmpresaDominio obj)
        {
            var _resultado = string.Empty;

            try
            {
                _repositorio.Empresa.Add(obj);
            }
            catch (Exception ex)
            {
                _resultado = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;
            }

            return _resultado;
        }

        public string Update(EmpresaDominio obj)
        {
            var _resultado = string.Empty;

            try
            {
                _repositorio.Empresa.Update(obj);
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
                _repositorio.Empresa.Remove(id);
            }
            catch (Exception ex)
            {
                _resultado = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;
            }

            return _resultado;
        }
    }
}
