using Lusitan.GPES.Aplicacao;
using Lusitan.GPES.Core.Interface.Aplicacao;
using Lusitan.GPES.Core.Interface.Repositorio;
using Lusitan.GPES.Infra.Repositorio;
using Microsoft.Extensions.DependencyInjection;

namespace Lusitan.GPES.Infra.IOC
{
    public class Dependencia
    {
        public static void RegistrarDependencias(IServiceCollection servico)
        {
            servico.AddScoped<IUsuarioAppService, UsuarioAppService>();
            servico.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
        }
    }
}
