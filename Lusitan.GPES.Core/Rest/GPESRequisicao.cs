using RestSharp;
using System.Globalization;

namespace Lusitan.GPES.Core.Rest
{
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
