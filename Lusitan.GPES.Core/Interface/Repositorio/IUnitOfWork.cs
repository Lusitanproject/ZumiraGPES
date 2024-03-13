
namespace Lusitan.GPES.Core.Interface.Repositorio
{
    public interface IUnitOfWork
    {
        string StrConexao { set; get; }

        IUsuarioRepositorio Usuario { get; }

        IPerfilAcessoRepositorio PerfilAcesso { get; }

        IUsuarioPerfilRepositorio UsuarioPerfil { get; }

        IUsuarioLogRepositorio UsuarioLog { get; }

        ILogAcessoErroRepositorio LogAcessoErro { get; }

        ICargoRepositorio Cargo { get; }

        IEmpresaRepositorio Empresa { get; }

        IFormacaoAcademicaRepositorio Formacao { get; }
    }
}
