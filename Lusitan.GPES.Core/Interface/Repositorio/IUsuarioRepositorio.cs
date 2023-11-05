using Lusitan.GPES.Core.Base.Interface.CRUD;
using Lusitan.GPES.Core.Entidade;

namespace Lusitan.GPES.Core.Interface.Repositorio
{
    public interface IUsuarioRepositorio: IAdd<UsuarioViewDominio>,
                                          IGetById<UsuarioDominio>
    {
        List<UsuarioDominio> GetList(string idcAtivo);

        UsuarioDominio GetUsuarioSemSenhaPorEmail(string eMail);
    }
}
