using Lusitan.GPES.Core.Interface.Repositorio;

namespace Lusitan.GPES.Infra.Repositorio
{
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
    }
}
