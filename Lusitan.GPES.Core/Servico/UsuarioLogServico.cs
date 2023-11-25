using Lusitan.GPES.Core.Base;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Repositorio;
using Lusitan.GPES.Core.Interface.Servico;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Lusitan.GPES.Core.Servico
{
    [ExcludeFromCodeCoverage]
    public class UsuarioLogServico : BaseServico, IUsuarioLogServico
    {
        public UsuarioLogServico(IUnitOfWork repositorio)
            : base(repositorio) { }

        public List<UsuarioLogDominio> GetByUsuario(int idUsuario)
           => _repositorio.UsuarioLog.GetByUsuario(idUsuario);

        public string Add(UsuarioLogDominio obj)
        {
            var _resultado = string.Empty;

            try
            {
                _repositorio.UsuarioLog.Add(obj);
            }
            catch (Exception ex)
            {
                _resultado = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;
            }

            return _resultado;
        }

    }
}
