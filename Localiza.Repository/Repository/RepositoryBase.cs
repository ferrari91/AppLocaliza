using Localiza.Base.Models;
using Localiza.Repository.Interface;

namespace Localiza.Repository.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T>, IDisposable where T : class
    {
        protected readonly CUsersferraOneDriveÁreadeTrabalhodatabasedbContext _context;

        public RepositoryBase()
        {
            _context = new CUsersferraOneDriveÁreadeTrabalhodatabasedbContext();
        }

        public void Delete(T obj)
        {
            _context.Set<T>().Remove(obj);
            Save();
        }

        public void Delete(params object[] value)
        {
            var obj = GetByPK(value);
            Delete(obj);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public T Edit(T obj)
        {
            _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
            return obj;
        }

        public List<T> GetAllDatas()
        {
            return _context.Set<T>().ToList();
        }

        public T GetByPK(params object[] value)
        {
            return _context.Set<T>().Find(value);
        }

        public T Include(T obj)
        {
            _context.Set<T>().Add(obj);
            Save();
            return obj;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
