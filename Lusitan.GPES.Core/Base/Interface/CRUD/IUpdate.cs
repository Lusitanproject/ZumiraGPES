
namespace Lusitan.GPES.Core.Base.Interface.CRUD
{
    public interface IUpdate<T> where T : class
    {
        string Update(T obj);
    }
}
