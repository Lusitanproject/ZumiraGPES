using Lusitan.GPES.WebApi.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Lusitan.GPES.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resource");
            services.Configure<RequestLocalizationOptions>(
                options =>
                {
                    var supportedCultures = new List<CultureInfo>
                    {
                        new CultureInfo("en-US"),
                        new CultureInfo("es-AR"),
                        new CultureInfo("pt-BR")
                    };

                    options.DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR");
                    options.SupportedCultures = supportedCultures;
                    options.SupportedUICultures = supportedCultures;
                    options.RequestCultureProviders = new[] { new RouteDataRequestCultureProvider { IndexOfCulture = 3, IndexofUICulture = 3 } };
                });

            services.Configure<RouteOptions>(options =>
            {
                options.ConstraintMap.Add("cultura", typeof(LanguageRouteConstraint));
            });




            services.ConfigureServices(Configuration);

            services.AddControllers();

            services.ConfigureJWT(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //
            app.ConfigureSwagger(env);
            var _opcoesLocalizacao = app.ApplicationServices.GetServices<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(_opcoesLocalizacao.FirstOrDefault().Value);
            //

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { 
                endpoints.MapControllers();
                endpoints.MapControllerRoute("default", "{cultura:cultura}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
