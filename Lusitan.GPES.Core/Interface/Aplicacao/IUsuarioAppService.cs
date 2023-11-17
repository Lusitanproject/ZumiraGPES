using Lusitan.GPES.Core.Base.Interface.CRUD;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Request;
using Lusitan.GPES.Core.Response;

namespace Lusitan.GPES.Core.Interface.Aplicacao
{
    public interface IUsuarioAppService: IGetById<UsuarioDominio>
    {
        List<UsuarioDominio> GetListAdmin();

        string AddAdmin(UsuarioDominio obj);

        UsuarioDominio GetUsuarioSemSenhaPorEmail(string eMail);

        LoginResponse Login(LoginRequest login);

        string AlteraSenha(AlteraSenhaRequest obj);
    }
}
