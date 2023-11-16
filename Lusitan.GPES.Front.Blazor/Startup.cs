using Blazored.SessionStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MudBlazor.Services;
using System.Globalization;

namespace Lusitan.GPES.Front.Blazor
{
    public class Startup
    {
        RequestLocalizationOptions _lstCulturasSuportadas;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");

            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.ConfigureServices(Configuration);
            _lstCulturasSuportadas = services.OpcoesLocalizacao(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles(); //

            app.UseRequestLocalization(_lstCulturasSuportadas); //

            app.UseRouting();

            app.UseAuthentication(); //
            app.UseAuthorization(); //

            app.UseEndpoints(endpoints =>
            {
				endpoints.MapControllers(); //
				endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
