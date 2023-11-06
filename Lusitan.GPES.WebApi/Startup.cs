using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lusitan.GPES.Aplicacao;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Infra.IOC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

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

            #region Configurações

            CultureInfo.CurrentCulture = new CultureInfo("pt-BR");

            var _confAmbiente = new ConfigAmbiente();
            Configuration.Bind("ConfigAmbiente", _confAmbiente);
            services.AddSingleton(_confAmbiente);

            var _confXMS = new ConfigXMS();
            Configuration.Bind("ConfigXMS", _confXMS);
            services.AddSingleton(_confXMS);

            Dependencia.RegistrarDependencias(services);

            services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo()
                    {
                        Title = "Back-end - Sistema de Gestão de Pessoas",
                        Version = "v1",
                    });
                });

            #endregion

            services.AddControllers();

            #region JWT

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => {
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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Back-end - Sistema de Gestão de Pessoas");
                c.RoutePrefix = "docs";
            });
            //

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
