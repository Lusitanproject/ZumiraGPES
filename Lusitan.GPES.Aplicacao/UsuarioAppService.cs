using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Aplicacao;
using Lusitan.GPES.Core.Interface.Servico;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace Lusitan.GPES.Aplicacao
{
    public class UsuarioAppService : BaseAplicacao, IUsuarioAppService
    {
        readonly IUsuarioServico _servico;
        readonly IPerfilAcessoAppService _perfilAcesso;
        readonly IUsuarioPerfilAppService _usuarioPerfil;
        readonly IUsuarioLogAppService _log;
        readonly ILogAcessoErroAppService _logAcessoErro;
        readonly ConfigAmbiente _config;
        readonly ConfigXMS _configXMS;

        int _idPerfilAdmin;

        public UsuarioAppService(   ConfigAmbiente config,
                                    ConfigXMS configXMS,
                                    IUsuarioServico servico,
                                    IPerfilAcessoAppService perfilAcesso,
                                    IUsuarioPerfilAppService usuarioPerfil,
                                    IUsuarioLogAppService log,
                                    ILogAcessoErroAppService logAcessoErro)
        {
            _config = config;
            _servico = servico;
            _perfilAcesso = perfilAcesso;
            _usuarioPerfil = usuarioPerfil;
            _configXMS = configXMS;
            _log = log;
            _logAcessoErro = logAcessoErro;
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

            return _servico.Add(new UsuarioViewDominio() {
                                                            NomeUsuario = obj.NomeUsuario,
                                                            eMail = obj.eMail,
                                                            DesSenha = CORE.CryptObj.Encripta(_config.SenhaPadraoNovoUsuario)
                                                         });
        }

        void EnviaEMailParaUsuario(UsuarioDominio obj, string descAssunto, string msg)
        {
            var _msgEnvioEmail = this.EnviaEMail(   _configXMS, 
                                                    new EMailDominio() {
                                                                            NumRemetente = _configXMS.IdRemetenteMsgNovoUsuario,
                                                                            DescAssunto = descAssunto,
                                                                            NomDestino = obj.eMail,
                                                                            DescMensagem = msg
                                                                        });

            _log.Add(new UsuarioLogDominio() {
                                                IdUsuario = obj.Id,
                                                DescLog = $"Retorno envio e-mail: {_msgEnvioEmail}",
                                                IdUsuarioResp = obj.Id
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

                    _msg = _usuarioPerfil.Add( new UsuarioPerfilDominio() {  IdPerfilAcesso = _idPerfilAdmin, IdUsuario = _novoUsuario.Id} );

                    this.EnviaEMailParaUsuario( _novoUsuario,
                                                "Novo acesso",
                                                Constantes.GetTextoEMailNovoUsuario.Replace("[USUARIO]", _novoUsuario.NomeUsuario).Replace("[LOGIN]", _novoUsuario.eMail).Replace("[SENHA]", _config.SenhaPadraoNovoUsuario));
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

        public LoginResponse Login(LoginRequest login)
        {
            try
            {
                var _idcValidaLogin = true;
                var _msgErroLogin = string.Empty;

                var _usuarioLogado = _servico.GetUsuarioComSenhaPorEmail(login.EMail);

                if (_usuarioLogado == null)
                {
                    _idcValidaLogin = false;
                    _msgErroLogin = "Usuário não encontrado!";
                }

                if ((_usuarioLogado.IdcAtivo != "A") && _idcValidaLogin)
                {
                    _idcValidaLogin = false;
                    _msgErroLogin = $"Não é possivel efetuar o Login. Usuário se encontra {_usuarioLogado.DescSituacao}. Contacte o Admin do Sistema!" ;
                }

                if ((CORE.CryptObj.Decripta(_usuarioLogado.DesSenha) != login.Pwd) && (_usuarioLogado.IdcAtivo == "A") && _idcValidaLogin)
                {
                    _idcValidaLogin = false;
                    _msgErroLogin = "Senha incorreta!";
                }

                if (!_idcValidaLogin)
                {
                    var _qteTentativaAcesso = _logAcessoErro.GetByUsuario(_usuarioLogado.Id).Count();

                    if (_usuarioLogado.IdcAtivo == "A")
                    {
                        if (_qteTentativaAcesso < 3)
                        {
                            _logAcessoErro.Add(new LogAcessoErroDominio()
                            {
                                IdUsuario = _usuarioLogado.Id,
                                DescLogErro = _msgErroLogin
                            });
                        }
                        else
                        {
                            _servico.AlteraSituacao("B", _usuarioLogado.Id);

                            _log.Add(new UsuarioLogDominio()
                            {
                                IdUsuario = _usuarioLogado.Id,
                                DescLog = "Usuário Bloqueado por exceder a quantidade de tentativas de login!",
                                IdUsuarioResp = _usuarioLogado.Id
                            });
                        }
                    }

                    return new LoginResponse() { LoginEhValido = _idcValidaLogin, UltimoAcesso = null, Token = _msgErroLogin };
                }

                _logAcessoErro.Delete(_usuarioLogado.Id);

                _servico.RegistraLogAcesso(_usuarioLogado.Id);

                #region Gera o Token de acesso

                var _lstCalims = new List<Claim>() {
                                                     new Claim(ClaimTypes.Sid, _usuarioLogado.Id.ToString()),
                                                     new Claim(ClaimTypes.Name, _usuarioLogado.NomeUsuario.ToString()),
                                                     new Claim(ClaimTypes.Email, _usuarioLogado.eMail.ToString())
                                                    };

                foreach (var item in _usuarioPerfil.GetByUsuario(_usuarioLogado.Id))
                {
                    _lstCalims.Add(new Claim(ClaimTypes.Role, item.NomPerfil));
                }

                var _handler = new JwtSecurityTokenHandler();

                var _dataRef = DateTime.UtcNow;

                var _token = _handler.CreateToken(new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(_lstCalims),
                    NotBefore = _dataRef,
                    Expires = _dataRef.AddMinutes(_config.TempoSessaoMin),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JWT.Chave)), SecurityAlgorithms.HmacSha256Signature)
                });

                var _strToken = _handler.WriteToken(_token);

                #endregion

                return new LoginResponse() { LoginEhValido = true, UltimoAcesso = _usuarioLogado.UltimoAcesso, Token = _strToken };
            }
            catch(Exception ex)
            {
                var _msgErro = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(_msgErro);

                throw new Exception(_msgErro);
            }
        }
    }
}
