
namespace Lusitan.GPES.Core.Entidade
{
    public class LoginResponse
    {
        public bool LoginEhValido { get; set; }

        public DateTime? UltimoAcesso { get; set; }

        public string Token { get; set; }
    }
}
