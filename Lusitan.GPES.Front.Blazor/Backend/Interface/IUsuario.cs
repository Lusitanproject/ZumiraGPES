using Lusitan.GPES.Core.Base.Interface.CRUD;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Request;
using Lusitan.GPES.Core.Response;
using System.Collections.Generic;

namespace Lusitan.GPES.Front.Blazor.Backend.Interface
{
    public interface IUsuario: IFrontEnd,
								IGetById<UsuarioDominio>
	{
        LoginResponse Login(string eMail, string pwd);

        UsuarioDominio BuscaPeloEMail(string eMail);

        List<UsuarioDominio> GetListAdmin();

        string AlteraSenha(AlteraSenhaRequest obj);

        string AddAdmin(UsuarioDominio obj);

        string Update(int idUsuario, string nomUsuario, string idcAtivo, string idcForcaAlteraSenha, int idUsuarioResp);

        string ReenviaSenha(int idUsuario, int idUsuarioResp);

        List<UsuarioLogDominio> GetLog(int idUsuario);

    }
}
