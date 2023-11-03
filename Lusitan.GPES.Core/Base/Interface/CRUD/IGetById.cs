namespace Lusitan.GPES.Core.Base.Interface.CRUD
{
    public interface IGetById<T> where T : class
    {
        T GetById(int id);
    }
}
