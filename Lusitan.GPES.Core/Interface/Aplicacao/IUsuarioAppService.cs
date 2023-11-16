using Lusitan.GPES.Core.Base.Interface.CRUD;
using Lusitan.GPES.Core.Entidade;

namespace Lusitan.GPES.Core.Interface.Aplicacao
{
    public interface IUsuarioAppService: IGetById<UsuarioDominio>
    {
        List<UsuarioDominio> GetListAdmin();

        string AddAdmin(UsuarioDominio obj);

        UsuarioDominio GetUsuarioSemSenhaPorEmail(string eMail);

        LoginResponse Login(LoginRequest login);
    }
}
