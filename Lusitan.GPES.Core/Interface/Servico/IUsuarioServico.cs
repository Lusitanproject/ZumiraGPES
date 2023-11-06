using Lusitan.GPES.Core.Base.Interface.CRUD;
using Lusitan.GPES.Core.Entidade;

namespace Lusitan.GPES.Core.Interface.Servico
{
    public interface IUsuarioServico :  IAdd<UsuarioViewDominio>,
                                        IGetById<UsuarioDominio>
    {
        List<UsuarioDominio> GetList(string idcAtivo);

        UsuarioDominio GetUsuarioSemSenhaPorEmail(string eMail);

        UsuarioViewDominio GetUsuarioComSenhaPorEmail(string eMail);

        string AlteraSituacao(string idcSituacao, int idUsuario);

        string RegistraLogAcesso(int idUsuario);
    }
}
