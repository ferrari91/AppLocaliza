using Localiza.Base.Models;
using Localiza.Repository.Interface;

namespace Localiza.Repository.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T>, IDisposable where T : class
    {
        protected readonly DataBaseContext _context;

        public RepositoryBase()
        {
            _context = new DataBaseContext();
        }

        public bool Delete(T obj)
        {
            _context.Set<T>().Remove(obj);
            return Save();
        }

        public bool Delete(params object[] value)
        {
            var obj = GetByPK(value);
            return Delete(obj);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public bool Edit(T obj)
        {
            _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return Save();
        }

        public List<T> GetAllDatas()
        {
            return _context.Set<T>().ToList();
        }

        public T GetByPK(params object[] value)
        {
            return _context.Set<T>().Find(value);
        }

        public bool Include(T obj)
        {
            _context.Set<T>().Add(obj);
            return Save();
        }

        public bool Save()
        {
            bool result = Convert.ToBoolean(_context.SaveChanges());
            return result;
        }
    }
}
