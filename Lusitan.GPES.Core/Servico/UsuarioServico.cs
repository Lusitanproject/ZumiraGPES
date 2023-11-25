using Lusitan.GPES.Core.Base;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Repositorio;
using Lusitan.GPES.Core.Interface.Servico;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Lusitan.GPES.Core.Servico
{
    [ExcludeFromCodeCoverage]
    public class UsuarioServico: BaseServico, IUsuarioServico
    {
        public UsuarioServico(IUnitOfWork repositorio)
            : base(repositorio) { }

        public List<UsuarioDominio> GetList(string idcAtivo)
            => _repositorio.Usuario.GetList(idcAtivo);

        public UsuarioDominio GetUsuarioSemSenhaPorEmail(string eMail)
           => _repositorio.Usuario.GetUsuarioSemSenhaPorEmail(eMail);

        public UsuarioViewDominio GetUsuarioComSenhaPorEmail(string eMail)
            => _repositorio.Usuario.GetUsuarioComSenhaPorEmail(eMail);

        public UsuarioDominio GetById(int id)
           => _repositorio.Usuario.GetById(id);

        public UsuarioViewDominio GetByIdComSenha(int id)
            => _repositorio.Usuario.GetByIdComSenha(id);

        public string AlteraSituacao(string idcSituacao, int idUsuario)
            => _repositorio.Usuario.AlteraSituacao(idcSituacao, idUsuario);

        public string RegistraLogAcesso(int idUsuario)
           => _repositorio.Usuario.RegistraLogAcesso(idUsuario);

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

        public string Update(UsuarioViewDominio obj)
        {
            var _resultado = string.Empty;

            try
            {
                _repositorio.Usuario.Update(obj);
            }
            catch (Exception ex)
            {
                _resultado = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;
            }

            return _resultado;
        }
    }
}
