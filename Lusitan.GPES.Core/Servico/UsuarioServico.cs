using Lusitan.GPES.Core.Base;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Repositorio;
using Lusitan.GPES.Core.Interface.Servico;
using System.Reflection;

namespace Lusitan.GPES.Core.Servico
{
    public class UsuarioServico: BaseServico, IUsuarioServico
    {
        public UsuarioServico(IUnitOfWork repositorio)
            : base(repositorio) { }

        public List<UsuarioDominio> GetList(string idcAtivo)
            => _repositorio.Usuario.GetList(idcAtivo);

        public UsuarioDominio GetUsuarioSemSenhaPorEmail(string eMail)
           => _repositorio.Usuario.GetUsuarioSemSenhaPorEmail(eMail);

        public UsuarioDominio GetById(int id)
           => _repositorio.Usuario.GetById(id);

        public string Add(UsuarioViewDominio obj)
        {
            var _resultado = string.Empty;

            try
            {
                _repositorio.Usuario.Add(obj);
            }
            catch (Exception ex)
            {
                _resultado = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;
            }

            return _resultado;
        }
    }
}
