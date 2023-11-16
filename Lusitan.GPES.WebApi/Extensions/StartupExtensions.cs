using Lusitan.GPES.Aplicacao;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Infra.IOC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Globalization;
using System.Text;

namespace Lusitan.GPES.WebApi.Extensions
{
    public static class StartupExtensions
    {
        public static void ConfigureServices(this IServiceCollection service, IConfiguration configuration)
        {
            CultureInfo.CurrentCulture = new CultureInfo("pt-BR");

            var _confAmbiente = new ConfigAmbiente();
            configuration.Bind("ConfigAmbiente", _confAmbiente);
            service.AddSingleton(_confAmbiente);

            var _confXMS = new ConfigXMS();
            configuration.Bind("ConfigXMS", _confXMS);
            service.AddSingleton(_confXMS);

            Dependencia.RegistrarDependencias(service);

            service.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                             new OpenApiInfo()
                             {
                                 Title = "Back-end - Sistema de Gestão de Pessoas",
                                 Version = "v1",
                             });
            });
        }

        public static void ConfigureJWT(this IServiceCollection service, IConfiguration configuration)
        {
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
        }

        public static void ConfigureSwagger(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Back-end - Sistema de Gestão de Pessoas");
                c.RoutePrefix = "docs";
            });
        }
    }
}
