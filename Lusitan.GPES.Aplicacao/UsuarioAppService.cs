using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Aplicacao;
using Lusitan.GPES.Core.Interface.Servico;
using System.Reflection;

namespace Lusitan.GPES.Aplicacao
{
    public class UsuarioAppService : BaseAplicacao, IUsuarioAppService
    {
        readonly IUsuarioServico _servico;
        readonly IPerfilAcessoAppService _perfilAcesso;
        readonly IUsuarioPerfilAppService _usuarioPerfil;
        readonly ConfigAmbiente _config;
        readonly ConfigXMS _configXMS;

        int _idPerfilAdmin;

        public UsuarioAppService(   ConfigAmbiente config,
                                    ConfigXMS configXMS,
                                    IUsuarioServico servico,
                                    IPerfilAcessoAppService perfilAcesso,
                                    IUsuarioPerfilAppService usuarioPerfil)
            :base(configXMS)
        {
            _config = config;
            _servico = servico;
            _perfilAcesso = perfilAcesso;
            _usuarioPerfil = usuarioPerfil;
            _configXMS = configXMS;            
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

                foreach (var item in _servico.GetList())
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
                    var _novoUsuarioCadastrado = _servico.GetUsuarioSemSenhaPorEmail(obj.eMail);

                    _msg = _usuarioPerfil.Add(new UsuarioPerfilDominio() {  IdPerfilAcesso = _idPerfilAdmin, 
                                                                            IdUsuario = _novoUsuarioCadastrado.Id});

                    if (string.IsNullOrEmpty(_msg))
                    {
                        var _msgEnvioEmail = this.EnviaEMail(new EMailDominio()
                                                                                {
                                                                                    NumRemetente = _configXMS.IdRemetenteMsgNovoUsuario,
                                                                                    DescAssunto = "Novo acesso",
                                                                                    NomDestino = obj.eMail,
                                                                                    DescMensagem = Constantes.GetTextoEMailNovoUsuario.Replace("[USUARIO]", obj.NomeUsuario).Replace("[LOGIN]", obj.eMail).Replace("[SENHA]", _config.SenhaPadraoNovoUsuario)
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
