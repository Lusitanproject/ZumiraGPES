﻿using Lusitan.GPES.Core.Config;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Aplicacao;
using Lusitan.GPES.Core.Interface.Servico;
using Microsoft.Extensions.Localization;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Lusitan.GPES.Aplicacao
{
    public class UsuarioPerfilAppService : BaseAplicacao, IUsuarioPerfilAppService
    {
        readonly IUsuarioPerfilServico _servico;
        readonly IPerfilAcessoAppService _perfilAcesso;
        readonly IUsuarioServico _usuario;
        readonly IUsuarioLogAppService _logUsuario;

        public UsuarioPerfilAppService(ConfigXMS configXMS,
                                       IUsuarioPerfilServico servico,
                                       IPerfilAcessoAppService perfilAcesso,
                                       IUsuarioServico usuario,
                                       IUsuarioLogAppService logUsuario)
            : base(configXMS)
        {
            _servico = servico;
            _perfilAcesso = perfilAcesso;
            _usuario = usuario;
            _logUsuario = logUsuario;
        }

		[ExcludeFromCodeCoverage]
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

		[ExcludeFromCodeCoverage]
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
                    return "Este Usuário já esta associado a este Perfil!"; // _localizador.GetString("msgUsuarioJaInclusoPerfil");
                }

                _logUsuario.Add(new UsuarioLogDominio()
                {
                    IdUsuario = obj.IdUsuario,
                    //DescLog = string.Format(_localizador.GetString("msgUsuarioIncluidoPerfil"), _perfilAcesso.GetById(obj.IdPerfilAcesso).NomPerfil),
                    DescLog = string.Format("Usuário incluído no Perfil {0}", _perfilAcesso.GetById(obj.IdPerfilAcesso).NomPerfil),
                    IdUsuarioResp = obj.IdUsuarioResp
                });

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
                _logUsuario.Add(new UsuarioLogDominio()
                {
                    IdUsuario = obj.IdUsuario,
                    DescLog = string.Format("Usuário excluído do Perfil {0}", _perfilAcesso.GetById(obj.IdPerfilAcesso).NomPerfil),
                    //DescLog = string.Format(_localizador.GetString("msgUsuarioExcluidoPerfil"), _perfilAcesso.GetById(obj.IdPerfilAcesso).NomPerfil),
                    IdUsuarioResp = obj.IdUsuarioResp
                });

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
