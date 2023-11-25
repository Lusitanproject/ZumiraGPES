using System.Diagnostics.CodeAnalysis;

namespace Lusitan.GPES.Core.Config
{
    [ExcludeFromCodeCoverage]
    public class ConfigXMS
    {
        public string WebApi { get; set; }

        public int IdRemetenteMsgNovoUsuario { get; set; }

        public int IdRemetenteMsgErro { get; set; }

        public string DestinoEMailErroSistema { get; set; }
    }
}
