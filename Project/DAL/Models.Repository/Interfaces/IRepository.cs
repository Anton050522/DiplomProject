using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Linq;

namespace Project.RepositoryPattern
{
    public interface IRepository<T> where T : class
    {
        public void Create(T entity);
        public T Read(int id);
        public IQueryable<T> ReadAll();
        public T Update(T entity);
        void Delete(T entity);
    }
}
