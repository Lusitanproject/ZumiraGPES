using Lusitan.GPES.Aplicacao;
using Lusitan.GPES.Core.Interface.Aplicacao;
using Lusitan.GPES.Core.Interface.Repositorio;
using Lusitan.GPES.Core.Interface.Servico;
using Lusitan.GPES.Core.Servico;
using Lusitan.GPES.Infra.Repositorio;
using Microsoft.Extensions.DependencyInjection;

namespace Lusitan.GPES.Infra.IOC
{
    public class Dependencia
    {
        public static void RegistrarDependencias(IServiceCollection servico)
        {
            servico.AddSingleton<IUnitOfWork, UnitOfWork>();

            servico.AddSingleton<IUsuarioAppService, UsuarioAppService>();
            servico.AddSingleton<IUsuarioServico, UsuarioServico>();
            servico.AddSingleton<IUsuarioRepositorio>(s => new UsuarioRepositorio(string.Empty));

            servico.AddSingleton<IPerfilAcessoAppService, PerfilAcessoAppService>();
            servico.AddSingleton<IPerfilAcessoServico, PerfilAcessoServico>();
            servico.AddSingleton<IPerfilAcessoRepositorio>(s => new PerfilAcessoRepositorio(string.Empty));

            servico.AddSingleton<IUsuarioPerfilAppService, UsuarioPerfilAppService>();
            servico.AddSingleton<IUsuarioPerfilServico, UsuarioPerfilServico>();
            servico.AddSingleton<IUsuarioPerfilRepositorio>(s => new UsuarioPerfilRepositorio(string.Empty));
        }
    }
}
