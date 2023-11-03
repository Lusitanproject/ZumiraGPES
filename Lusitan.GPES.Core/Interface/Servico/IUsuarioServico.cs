using Lusitan.GPES.Core.Base.Interface.CRUD;
using Lusitan.GPES.Core.Entidade;

namespace Lusitan.GPES.Core.Interface.Servico
{
    public interface IUsuarioServico :  IGetList<UsuarioDominio>,
                                        IAdd<UsuarioViewDominio>,
                                        IGetById<UsuarioDominio>
    {
        UsuarioDominio GetUsuarioSemSenhaPorEmail(string eMail);
    }
}
