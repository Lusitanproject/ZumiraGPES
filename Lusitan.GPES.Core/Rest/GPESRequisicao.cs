using RestSharp;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Lusitan.GPES.Core.Rest
{
    [ExcludeFromCodeCoverage]
    public class GPESRequisicao: RestRequest
    {
        public GPESRequisicao(string url, Method metodo)
            : base(url, metodo)
        {
            this.RequestFormat = DataFormat.Json;
        }

        public GPESRequisicao(string url, Method metodo, string token)
            : base(url, metodo)
        {
            this.RequestFormat = DataFormat.Json;
            this.AddHeader("Authorization", token);
            this.AddHeader("Accept-Language", CultureInfo.CurrentCulture.Name);
        }
    }
}
