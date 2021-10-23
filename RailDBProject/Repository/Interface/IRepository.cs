using System.Linq;

namespace RailDBProject.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        public void Create(T entity);
        public T Read(int id);
        public IQueryable<T> ReadAll();
        public T Update(T entity);
        public void Delete(T entity);
    }
}
