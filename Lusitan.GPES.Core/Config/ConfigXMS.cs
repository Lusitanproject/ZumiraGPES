using System.Diagnostics.CodeAnalysis;

namespace Lusitan.GPES.Core.Config
{
    [ExcludeFromCodeCoverage]
    public class ConfigXMS
    {
        public string WebApi { get; set; }

        public int IdRemetenteMsgSistema { get; set; }

        public string DestinoEMailErroSistema { get; set; }
    }
}
