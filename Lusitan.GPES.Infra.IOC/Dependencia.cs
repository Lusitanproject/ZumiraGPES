using Lusitan.GPES.Aplicacao;
using Lusitan.GPES.Core.Interface.Aplicacao;
using Lusitan.GPES.Core.Interface.Repositorio;
using Lusitan.GPES.Core.Interface.Servico;
using Lusitan.GPES.Core.Servico;
using Lusitan.GPES.Infra.Repositorio;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Lusitan.GPES.Infra.IOC
{
    [ExcludeFromCodeCoverage]
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

            servico.AddSingleton<IUsuarioLogAppService, UsuarioLogAppService>();
            servico.AddSingleton<IUsuarioLogServico, UsuarioLogServico>();
            servico.AddSingleton<IUsuarioLogRepositorio>(s => new UsuarioLogRepositorio(string.Empty));

            servico.AddSingleton<ILogAcessoErroAppService, LogAcessoErroAppService>();
            servico.AddSingleton<ILogAcessoErroServico, LogAcessoErroServico>();
            servico.AddSingleton<ILogAcessoErroRepositorio>(s => new LogAcessoErroRepositorio(string.Empty));

            servico.AddSingleton<ICargoAppService, CargoAppService>();
            servico.AddSingleton<ICargoServico, CargoServico>();
            servico.AddSingleton<ICargoRepositorio>(s => new CargoRepositorio(string.Empty));

            servico.AddSingleton<IEmpresaAppService, EmpresaAppService>();
            servico.AddSingleton<IEmpresaServico, EmpresaServico>();
            servico.AddSingleton<IEmpresaRepositorio>(s => new EmpresaRepositorio(string.Empty));

            servico.AddSingleton<IFormacaoAcademicaAppService, FormacaoAcademicaAppService>();
            servico.AddSingleton<IFormacaoAcademicaService, FormacaoAcademicaService>();
            servico.AddSingleton<IFormacaoAcademicaRepositorio>(s => new FormacaoAcademicaRepositorio(string.Empty));

            servico.AddSingleton<IMinhaFormacaoAppService, MinhaFormacaoAppService>();
            servico.AddSingleton<IMinhaFormacaoService, MinhaFormacaoService>();
            servico.AddSingleton<IMinhaFormacaoRepositorio>(s => new MinhaFormacaoRepositorio(string.Empty));

            servico.AddSingleton<IMeuPerfilAppService, MeuPerfilAppService>();
            servico.AddSingleton<IMeuPerfilService, MeuPerfilService>();
            servico.AddSingleton<IMeuPerfilRepositorio>(s => new MeuPerfilRepositorio(string.Empty));
        }
    }
}
