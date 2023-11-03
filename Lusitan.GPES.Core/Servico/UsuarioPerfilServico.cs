using Lusitan.GPES.Core.Base;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Repositorio;
using Lusitan.GPES.Core.Interface.Servico;
using System.Reflection;

namespace Lusitan.GPES.Core.Servico
{
    public class UsuarioPerfilServico : BaseServico, IUsuarioPerfilServico
    {
        public UsuarioPerfilServico(IUnitOfWork repositorio)
            : base(repositorio) { }

        public List<UsuarioPerfilDominio> GetByPerfil(int idPerfil)
           => _repositorio.UsuarioPerfil.GetByPerfil(idPerfil);

        public List<UsuarioPerfilDominio> GetByUsuario(int idUsuario)
           => _repositorio.UsuarioPerfil.GetByUsuario(idUsuario);

        public string Add(UsuarioPerfilDominio obj)
        {
            var _resultado = string.Empty;

            try
            {
                _repositorio.UsuarioPerfil.Add(obj);
            }
            catch (Exception ex)
            {
                _resultado = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;
            }

            return _resultado;
        }
    }
}
