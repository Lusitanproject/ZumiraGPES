using Lusitan.GPES.Core.Base;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Repositorio;
using Lusitan.GPES.Core.Interface.Servico;
using System.Reflection;

namespace Lusitan.GPES.Core.Servico
{
    public class LogAcessoErroServico : BaseServico, ILogAcessoErroServico
    {
        public LogAcessoErroServico(IUnitOfWork repositorio)
            : base(repositorio) { }

        public List<LogAcessoErroDominio> GetByUsuario(int idUsuario)
           => _repositorio.LogAcessoErro.GetByUsuario(idUsuario);

        public string Add(LogAcessoErroDominio obj)
        {
            var _resultado = string.Empty;

            try
            {
                _repositorio.LogAcessoErro.Add(obj);
            }
            catch (Exception ex)
            {
                _resultado = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;
            }

            return _resultado;
        }

        public string Delete(int idUsuario)
        {
            var _resultado = string.Empty;

            try
            {
                _repositorio.LogAcessoErro.Delete(idUsuario);
            }
            catch (Exception ex)
            {
                _resultado = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;
            }

            return _resultado;
        }
    }
}
