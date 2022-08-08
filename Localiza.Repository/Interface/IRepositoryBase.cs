namespace Localiza.Repository.Interface
{
    public interface IRepositoryBase<T> where T : class
    {
        List<T> GetAllDatas();

        T GetByPK(params object[] value);

        bool Include(T obj);

        bool Edit(T obj);

        bool Delete(T obj);

        bool Delete(params object[] value);

        bool Save();
    }
}
