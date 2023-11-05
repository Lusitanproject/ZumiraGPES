using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Aplicacao;
using Lusitan.GPES.Core.Interface.Servico;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Lusitan.GPES.Aplicacao
{
    public class UsuarioAppService : BaseAplicacao, IUsuarioAppService
    {
        readonly IUsuarioServico _servico;
        readonly IPerfilAcessoAppService _perfilAcesso;
        readonly IUsuarioPerfilAppService _usuarioPerfil;
        readonly IUsuarioLogAppService _log;
        readonly ConfigAmbiente _config;
        readonly ConfigXMS _configXMS;

        int _idPerfilAdmin;

        public UsuarioAppService(   ConfigAmbiente config,
                                    ConfigXMS configXMS,
                                    IUsuarioServico servico,
                                    IPerfilAcessoAppService perfilAcesso,
                                    IUsuarioPerfilAppService usuarioPerfil,
                                    IUsuarioLogAppService log)
            : base(configXMS)
        {
            _config = config;
            _servico = servico;
            _perfilAcesso = perfilAcesso;
            _usuarioPerfil = usuarioPerfil;
            _configXMS = configXMS;
            _log = log;
        }

        void Init()
        {
            _idPerfilAdmin = (_perfilAcesso.GetList().Where(x => x.NomPerfil == "Admin").FirstOrDefault()).Id;
        }

        string AddUsuario(UsuarioDominio obj)
        {
            var _novoUsuario = _servico.GetUsuarioSemSenhaPorEmail(obj.eMail);

            if (_novoUsuario != null)
            {
                return "Já existe um Usuário cadastrado com este E-Mail!";
            }

            return _servico.Add(new UsuarioViewDominio()
            {
                NomeUsuario = obj.NomeUsuario,
                eMail = obj.eMail,
                DesSenha = CORE.CryptObj.Encripta(_config.SenhaPadraoNovoUsuario)
            });
        }

        public List<UsuarioDominio> GetListAdmin()
        {
            try
            {
                Init();

                var _result = new List<UsuarioDominio>();

                var _lstUsuarios = _servico.GetList("A");
                _lstUsuarios.AddRange(_servico.GetList("I"));
                _lstUsuarios.AddRange(_servico.GetList("B"));

                foreach (var item in _lstUsuarios)
                {
                    if (_usuarioPerfil.GetByUsuario(item.Id).Any(x => x.Id == _idPerfilAdmin))
                    {
                        _result.Add(item);
                    }
                }

                return _result;
            }
            catch (Exception ex)
            {
                var _msgErro = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(_msgErro);

                throw new Exception(_msgErro);
            }
        }

        public string AddAdmin(UsuarioDominio obj)
        {
            try
            {
                Init();

                var _msg = this.AddUsuario(obj);

                if (string.IsNullOrEmpty(_msg))
                {
                    var _novoUsuario = _servico.GetUsuarioSemSenhaPorEmail(obj.eMail);

                    _msg = _usuarioPerfil.Add(new UsuarioPerfilDominio() {  IdPerfilAcesso = _idPerfilAdmin, IdUsuario = _novoUsuario.Id});

                    if (string.IsNullOrEmpty(_msg))
                    {
                        var _msgEnvioEmail = this.EnviaEMail(new EMailDominio() {
                                                                                    NumRemetente = _configXMS.IdRemetenteMsgNovoUsuario,
                                                                                    DescAssunto = "Novo acesso",
                                                                                    NomDestino = _novoUsuario.eMail,
                                                                                    DescMensagem = Constantes.GetTextoEMailNovoUsuario.Replace("[USUARIO]", obj.NomeUsuario).Replace("[LOGIN]", obj.eMail).Replace("[SENHA]", _config.SenhaPadraoNovoUsuario)
                                                                                });

                        _log.Add(new UsuarioLogDominio()
                        {
                            IdUsuario = _novoUsuario.Id,
                            DescLog = $"Retorno envio e-mail: {_msgEnvioEmail}",
                            IdUsuarioResp = _novoUsuario.Id
                        });
                    }
                }

                return _msg;
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
