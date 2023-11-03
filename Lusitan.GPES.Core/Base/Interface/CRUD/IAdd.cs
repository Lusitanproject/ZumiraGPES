
namespace Lusitan.GPES.Core.Base.Interface.CRUD
{
    public interface IAdd<T> where T : class
    {
        string Add(T obj);
    }
}
