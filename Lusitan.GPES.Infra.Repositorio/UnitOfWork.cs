using Lusitan.GPES.Core.Interface.Repositorio;
using System.Diagnostics.CodeAnalysis;

namespace Lusitan.GPES.Infra.Repositorio
{
    [ExcludeFromCodeCoverage]
    public class UnitOfWork: IUnitOfWork
    {
        public string StrConexao { set; get; }


        IUsuarioRepositorio _usuario;
        public IUsuarioRepositorio Usuario
        {
            get
            {
                if (_usuario == null)
                {
                    _usuario = new UsuarioRepositorio(this.StrConexao);
                }

                return _usuario;
            }
        }

        IPerfilAcessoRepositorio _perfilAcesso;
        public IPerfilAcessoRepositorio PerfilAcesso
        {
            get
            {
                if (_perfilAcesso == null)
                {
                    _perfilAcesso = new PerfilAcessoRepositorio(this.StrConexao);
                }

                return _perfilAcesso;
            }
        }

        IUsuarioPerfilRepositorio _usuarioPerfil;
        public IUsuarioPerfilRepositorio UsuarioPerfil
        {
            get
            {
                if (_usuarioPerfil == null)
                {
                    _usuarioPerfil = new UsuarioPerfilRepositorio(this.StrConexao);
                }

                return _usuarioPerfil;
            }
        }

        IUsuarioLogRepositorio _usuarioLog;
        public IUsuarioLogRepositorio UsuarioLog
        {
            get
            {
                if (_usuarioLog == null)
                {
                    _usuarioLog = new UsuarioLogRepositorio(this.StrConexao);
                }

                return _usuarioLog;
            }
        }

        ILogAcessoErroRepositorio _logAcessoErro;
        public ILogAcessoErroRepositorio LogAcessoErro
        {
            get
            {
                if (_logAcessoErro == null)
                {
                    _logAcessoErro = new LogAcessoErroRepositorio(this.StrConexao);
                }

                return _logAcessoErro;
            }
        }

    }
}
