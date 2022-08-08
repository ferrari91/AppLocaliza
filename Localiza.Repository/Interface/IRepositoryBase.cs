namespace Localiza.Repository.Interface
{
    public interface IRepositoryBase<T> where T : class
    {
        List<T> GetAllDatas();

        T GetByPK(params object[] value);

        T Include(T obj);

        T Edit(T obj);

        void Delete(T obj);

        void Delete(params object[] value);

        void Save();
    }
}
