using Lusitan.GPES.Core.Base.Interface.CRUD;
using Lusitan.GPES.Core.Entidade;

namespace Lusitan.GPES.Front.Blazor.Backend.Interface
{
	public interface ICargo :	IFrontEnd, 
								IGetList<CargoDominio>,
								IGetById<CargoDominio>,
								IAdd<CargoDominio>,
								IUpdate<CargoDominio>,
								IRemove
	{
	}
}
