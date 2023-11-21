using Lusitan.GPES.Core.Base.Interface.CRUD;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Request;
using Lusitan.GPES.Core.Response;

namespace Lusitan.GPES.Core.Interface.Aplicacao
{
    public interface IUsuarioAppService: IGetById<UsuarioDominio>
    {
        List<UsuarioDominio> GetList(string nomPerfil);

        string AddUsuarioPerfil(UsuarioDominio obj, string nomPerfil);

        UsuarioDominio GetUsuarioSemSenhaPorEmail(string eMail);

        LoginResponse Login(LoginRequest login);

        string AlteraSenha(AlteraSenhaRequest obj);

        string Update(int idUsuario, string nomUsuario, string idcAtivo, string idcForcaAlteraSenha, int idUsuarioResp);

        string ReenviaSenha(int idUsuario, int idUsuarioResp);
    }
}
