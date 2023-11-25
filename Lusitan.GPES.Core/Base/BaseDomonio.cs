using System.Diagnostics.CodeAnalysis;

namespace Lusitan.GPES.Core.Base
{
    [ExcludeFromCodeCoverage]
    public abstract class BaseDomonio
    {
        public int Id { get; set; }

        public string IdcAtivo { get; set; }

        public int IdUsuarioResp { get; set; }
    }
}
