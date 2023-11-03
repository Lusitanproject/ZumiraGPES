using Lusitan.GPES.Core.Base;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Repositorio;
using Lusitan.GPES.Core.Interface.Servico;

namespace Lusitan.GPES.Core.Servico
{
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
