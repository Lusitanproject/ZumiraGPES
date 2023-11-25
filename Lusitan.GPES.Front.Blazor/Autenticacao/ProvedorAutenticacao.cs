using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Blazored.SessionStorage;
using Lusitan.GPES.Core.Entidade;
using System.Diagnostics.CodeAnalysis;

namespace Lusitan.GPES.Front.Blazor.Autenticacao
{
    [ExcludeFromCodeCoverage]
    public class ProvedorAutenticacao : AuthenticationStateProvider
    {
        readonly ISessionStorageService _sessionStorage;

        public ProvedorAutenticacao(ISessionStorageService sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        ClaimsIdentity GetClaimsIdentity(UsuarioDominio usuario)
        {
            var _lstClaim = new List<Claim>() { new Claim(ClaimTypes.Sid, usuario.Id.ToString()),
                                                new Claim(ClaimTypes.Name, usuario.NomeUsuario),
                                                new Claim(ClaimTypes.Email, usuario.eMail) };

            foreach (var item in (((JwtSecurityToken)CORE.Util.JwtToken.GetDecodeToken(usuario.Token)).Claims).Where(x => x.Type.ToLower() == "role"))
            {
                _lstClaim.Add(new Claim(ClaimTypes.Role, item.Value));
            }

            return new ClaimsIdentity(_lstClaim, "apiauth_type");
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            ClaimsIdentity claimsIdentity;

            string _token = await _sessionStorage.GetItemAsync<string>("token");

            if (!string.IsNullOrEmpty(_token))
            {
                var _usuarioLogado = await _sessionStorage.GetItemAsync<UsuarioDominio>("Usuario");

                claimsIdentity = GetClaimsIdentity(new UsuarioDominio()
                {
                    Token = _token,
                    Id = _usuarioLogado.Id,
                    NomeUsuario = _usuarioLogado.NomeUsuario,
                    eMail = _usuarioLogado.eMail
                });
            }
            else
            {
                claimsIdentity = new ClaimsIdentity();
            }

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(claimsIdentity)));
        }

        public void MarcaUsuarioComoAutenticado(UsuarioDominio usuario)
        {

            base.NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(GetClaimsIdentity(usuario)))));
        }

        public async void Logout()
        {
            await _sessionStorage.ClearAsync();

            base.NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()))));
        }
    }
}
