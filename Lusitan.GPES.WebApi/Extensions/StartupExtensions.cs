using Lusitan.GPES.Aplicacao;
using Lusitan.GPES.Core.Config;
using Lusitan.GPES.Infra.IOC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace Lusitan.GPES.WebApi.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class StartupExtensions
    {
        public static void ConfigureServices(this IServiceCollection service, IConfiguration configuration)
        {
            #region Multi-idiomas
            service.AddLocalization();
            service.AddSingleton<LocalizationMiddleware>();
            service.AddDistributedMemoryCache();
            service.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();
            #endregion

            var _confAmbiente = new ConfigAmbiente();
            configuration.Bind("ConfigAmbiente", _confAmbiente);
            service.AddSingleton(_confAmbiente);

            var _confXMS = new ConfigXMS();
            configuration.Bind("ConfigXMS", _confXMS);
            service.AddSingleton(_confXMS);

            var _confGED = new ConfigGED();
            configuration.Bind("ConfigGED", _confGED);
            service.AddSingleton(_confGED);

            Dependencia.RegistrarDependencias(service);

            service.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                             new OpenApiInfo()
                             {
                                 Title = "GPES - API de Integração",
                                 Version = "v1",
                             });
            });
        }

        public static void ConfigureJWT(this IServiceCollection service, IConfiguration configuration)
        {
            #region JWT
            service.AddCors();
            service.AddEndpointsApiExplorer();
            service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                            .AddJwtBearer(opt =>
                            {
                                opt.RequireHttpsMetadata = false;
                                opt.TokenValidationParameters = new TokenValidationParameters
                                {
                                    ValidateIssuer = false,
                                    ValidateAudience = false,
                                    ValidateLifetime = true,
                                    RequireExpirationTime = true,
                                    ClockSkew = TimeSpan.FromSeconds(10),
                                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWT.Chave))
                                };
                            });
            #endregion
        }

        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "GPES - API de Integração");
                c.RoutePrefix = "docs";
            });
        }

        public static void ConfigureMultiIdiomas(this IApplicationBuilder app)
        {
            app.UseRequestLocalization(new RequestLocalizationOptions { DefaultRequestCulture = new RequestCulture(new CultureInfo("pt-BR")) });
            app.UseStaticFiles();
            app.UseMiddleware<LocalizationMiddleware>();
        }
    }
}
