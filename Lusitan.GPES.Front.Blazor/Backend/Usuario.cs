using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Front.Blazor.Backend.Interface;
using Microsoft.Extensions.Configuration;

namespace Lusitan.GPES.Front.Blazor.Backend
{
    public class Usuario : _webApi, IUsuario
    {
        public Usuario(IConfiguration conf)
            : base(conf) { }

        public UsuarioDominio BuscaPeloEMail(string eMail)
        {
            throw new System.NotImplementedException();
        }

		public UsuarioDominio GetById(int id)
		{
			throw new System.NotImplementedException();
		}

		public LoginResponse Login(string eMail, string pwd)
        {
            throw new System.NotImplementedException();
        }
    }
}
