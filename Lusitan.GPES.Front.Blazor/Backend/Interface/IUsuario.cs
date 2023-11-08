using Lusitan.GPES.Core.Base.Interface.CRUD;
using Lusitan.GPES.Core.Entidade;

namespace Lusitan.GPES.Front.Blazor.Backend.Interface
{
    public interface IUsuario: IFrontEnd,
								IGetById<UsuarioDominio>
	{
        LoginResponse Login(string eMail, string pwd);

        UsuarioDominio BuscaPeloEMail(string eMail);
    }
}
