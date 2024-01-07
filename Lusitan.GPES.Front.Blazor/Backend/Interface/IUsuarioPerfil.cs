using Lusitan.GPES.Core.Entidade;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Lusitan.GPES.Front.Blazor.Backend.Interface
{
    public interface IUsuarioPerfil : IFrontEnd
    {
        List<PerfilAcessoDominio> GetListPerfil();

        List<PerfilAcessoDominio> ListaPerfilPorUsuario(int idUsuario);

        string ExcluiUsuarioPErfil(UsuarioPerfilDominio obj);
    }
}
