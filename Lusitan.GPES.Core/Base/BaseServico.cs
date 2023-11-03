using Lusitan.GPES.Core.Interface.Repositorio;

namespace Lusitan.GPES.Core.Base
{
    public class BaseServico
    {
        protected IUnitOfWork _repositorio;

        public BaseServico(IUnitOfWork repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
