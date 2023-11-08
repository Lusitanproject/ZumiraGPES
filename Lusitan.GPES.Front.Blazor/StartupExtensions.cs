using Blazored.SessionStorage;
using Lusitan.GPES.Front.Blazor.Autenticacao;
using Lusitan.GPES.Front.Blazor.Backend;
using Lusitan.GPES.Front.Blazor.Backend.Interface;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using Radzen;
using System.Globalization;

namespace Lusitan.GPES.Front.Blazor
{
    public static class StartupExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
			CultureInfo.CurrentCulture = new CultureInfo("pt-BR");

			services.AddControllers();
            //
			services.AddScoped<IUsuario, Usuario>();

            //
            services.AddScoped<AuthenticationStateProvider, ProvedorAutenticacao>();

            services.AddScoped<DialogService>();
            services.AddScoped<NotificationService>();
            services.AddScoped<TooltipService>();
            services.AddScoped<ContextMenuService>();

            services.AddMudServices();
            services.AddBlazoredSessionStorage();
        }
    }
}
