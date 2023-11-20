using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Aplicacao;
using Lusitan.GPES.Core.Interface.Servico;
using System.Reflection;

namespace Lusitan.GPES.Aplicacao
{
    public class UsuarioPerfilAppService : BaseAplicacao, IUsuarioPerfilAppService
    {
        readonly IUsuarioPerfilServico _servico;
        readonly IPerfilAcessoAppService _perfilAcesso;
        readonly IUsuarioServico _usuario;

        public UsuarioPerfilAppService(IUsuarioPerfilServico servico,
                                       IPerfilAcessoAppService perfilAcesso,
                                       IUsuarioServico usuario)
        {
            _servico = servico;
            _perfilAcesso = perfilAcesso;
            _usuario = usuario;
        }

        public List<UsuarioDominio> GetByPerfil(int idPerfil)
        {
            try
            {
                return (from u in _servico.GetByPerfil(idPerfil)
                       select _usuario.GetById(u.IdUsuario)).ToList();
            }
            catch (Exception ex)
            {
                var _msgErro = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(_msgErro);

                throw new Exception(_msgErro);
            }
        }

        public List<PerfilAcessoDominio> GetByUsuario(int idUsuario)
        {
            try
            {
                return (from u in _servico.GetByUsuario(idUsuario)
                       select _perfilAcesso.GetById(u.IdPerfilAcesso)).ToList();
            }
            catch (Exception ex)
            {
                var _msgErro = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(_msgErro);

                throw new Exception(_msgErro);
            }
        }

        public string Add(UsuarioPerfilDominio obj)
        {
            try
            {
                if (_servico.GetByPerfil(obj.IdPerfilAcesso).Any(x => x.IdUsuario == obj.IdUsuario))
                {
                    return "Este Usuário já esta associado a este Perfil!";
                }

                return _servico.Add(obj);
            }
            catch (Exception ex)
            {
                var _msgErro = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(_msgErro);

                throw new Exception(_msgErro);
            }
        }

        public string Remove(UsuarioPerfilDominio obj)
        {
            try
            {
                return _servico.Remove(obj);
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
