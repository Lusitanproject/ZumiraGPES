namespace Lusitan.GPES.Core.Base.Interface.CRUD
{
    public interface IGetList<T> where T : class
    {
        List<T> GetList();
    }
}
