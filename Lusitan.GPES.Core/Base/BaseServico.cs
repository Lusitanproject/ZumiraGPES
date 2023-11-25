using Lusitan.GPES.Core.Interface.Repositorio;
using System.Diagnostics.CodeAnalysis;

namespace Lusitan.GPES.Core.Base
{
    [ExcludeFromCodeCoverage]
    public class BaseServico
    {
        protected IUnitOfWork _repositorio;

        public BaseServico(IUnitOfWork repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
