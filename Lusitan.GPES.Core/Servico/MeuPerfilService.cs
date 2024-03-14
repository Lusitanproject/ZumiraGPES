using Lusitan.GPES.Core.Base;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Repositorio;
using Lusitan.GPES.Core.Interface.Servico;
using System.Reflection;

namespace Lusitan.GPES.Core.Servico
{
    public class MeuPerfilService : BaseServico, IMeuPerfilService
    {
        public MeuPerfilService(IUnitOfWork repositorio)
            : base(repositorio) { }

        public MeuPerfilDominio BuscaPeloUsuario(int idUsuario)
            => _repositorio.MeuPerfil.BuscaPeloUsuario(idUsuario);

        public string Add(MeuPerfilDominio obj)
        {
            var _resultado = string.Empty;

            try
            {
                _repositorio.MeuPerfil.Add(obj);
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
                _repositorio.MeuPerfil.Remove(id);
            }
            catch (Exception ex)
            {
                _resultado = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;
            }

            return _resultado;
        }
    }
}
