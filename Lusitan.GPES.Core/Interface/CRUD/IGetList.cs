
namespace Lusitan.GPES.Core.Interface.CRUD
{
    public interface IGetList<T> where T : class
    {
        List<T> GetList();
    }
}
