using System.Diagnostics.CodeAnalysis;

namespace Lusitan.GPES.Core.Entidade
{
    [ExcludeFromCodeCoverage]
    public class UsuarioPerfilDominio
    {
        public int IdPerfilAcesso { get; set; }

        public int IdUsuario { get; set; }

        public int IdUsuarioResp { get; set; }
    }
}
