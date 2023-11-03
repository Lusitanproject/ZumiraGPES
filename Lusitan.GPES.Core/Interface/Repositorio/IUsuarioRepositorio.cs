using Lusitan.GPES.Core.Base.Interface.CRUD;
using Lusitan.GPES.Core.Entidade;

namespace Lusitan.GPES.Core.Interface.Repositorio
{
    public interface IUsuarioRepositorio: IGetList<UsuarioDominio>,
                                          IAdd<UsuarioViewDominio>,
                                          IGetById<UsuarioDominio>
    {
        UsuarioDominio GetUsuarioSemSenhaPorEmail(string eMail);

    }
}
