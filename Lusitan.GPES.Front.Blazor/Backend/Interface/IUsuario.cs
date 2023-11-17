using Lusitan.GPES.Core.Base.Interface.CRUD;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Response;

namespace Lusitan.GPES.Front.Blazor.Backend.Interface
{
    public interface IUsuario: IFrontEnd,
								IGetById<UsuarioDominio>
	{
        LoginResponse Login(string eMail, string pwd);

        UsuarioDominio BuscaPeloEMail(string eMail);
    }
}
