using Lusitan.GPES.Core.Entidade;
using System.Collections.Generic;

namespace Lusitan.GPES.Front.Blazor.Backend.Interface
{
    public interface IUsuarioPerfil : IFrontEnd
    {
        List<PerfilAcessoDominio> GetListPerfil();

        string ExcluiUsuarioPErfil(UsuarioPerfilDominio obj);
    }
}
