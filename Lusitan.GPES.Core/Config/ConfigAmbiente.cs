using System.Diagnostics.CodeAnalysis;

namespace Lusitan.GPES.Core.Config
{
    [ExcludeFromCodeCoverage]
    public class ConfigAmbiente
    {
        public string StrConexao { get; set; }

        public string SenhaPadraoNovoUsuario { get; set; }

        public int TempoSessaoMin { get; set; }
    }
}
