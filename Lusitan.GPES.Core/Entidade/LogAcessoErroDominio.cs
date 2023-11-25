using System.Diagnostics.CodeAnalysis;

namespace Lusitan.GPES.Core.Entidade
{
    [ExcludeFromCodeCoverage]
    public class LogAcessoErroDominio
    {
        public int IdUsuario { get; set; }

        public DateTime DthLogErro { get; set; }

        public string DescLogErro { get; set; }
    }
}
