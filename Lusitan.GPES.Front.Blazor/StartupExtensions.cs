using Blazored.SessionStorage;
using Lusitan.GPES.Front.Blazor.Autenticacao;
using Lusitan.GPES.Front.Blazor.Backend;
using Lusitan.GPES.Front.Blazor.Backend.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using Radzen;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Lusitan.GPES.Front.Blazor
{
    public static class StartupExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            

            services.AddControllers();
            services.AddLocalization(options => options.ResourcesPath = "Resource");
            //
            services.AddScoped<IUsuario, Usuario>();
            services.AddScoped<IUsuarioPerfil, UsuarioPerfil>();

            //
            services.AddScoped<AuthenticationStateProvider, ProvedorAutenticacao>();

            services.AddScoped<DialogService>();
            services.AddScoped<NotificationService>();
            services.AddScoped<TooltipService>();
            services.AddScoped<ContextMenuService>();

            services.AddMudServices();
            services.AddBlazoredSessionStorage();
        }

        public static RequestLocalizationOptions OpcoesLocalizacao(this IServiceCollection services, IConfiguration configuration)
        {
            var _culturasSuportadas = (configuration.GetSection("Cultura").GetChildren().ToDictionary(x => x.Key, x => x.Value)).Keys.ToArray();

            var _opcoesLocalizacao = new RequestLocalizationOptions()
                .AddSupportedCultures(_culturasSuportadas)
                .AddSupportedUICultures(_culturasSuportadas);

            return _opcoesLocalizacao;
        }
    }
}
