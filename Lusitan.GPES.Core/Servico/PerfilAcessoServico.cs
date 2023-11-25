using Lusitan.GPES.Core.Base;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Repositorio;
using Lusitan.GPES.Core.Interface.Servico;
using System.Diagnostics.CodeAnalysis;

namespace Lusitan.GPES.Core.Servico
{
    [ExcludeFromCodeCoverage]
    public class PerfilAcessoServico : BaseServico, IPerfilAcessoServico
    {
        public PerfilAcessoServico(IUnitOfWork repositorio)
            : base(repositorio) { }

        public List<PerfilAcessoDominio> GetList()
           => _repositorio.PerfilAcesso.GetList();

        public PerfilAcessoDominio GetById(int id)
           => _repositorio.PerfilAcesso.GetById(id);
    }
}
