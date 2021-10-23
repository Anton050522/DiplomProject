using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Project;

namespace Project.RepositoryPattern
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly RailDBContext _context;
        public Repository(RailDBContext context)
        {
            _context = context;
        }
        public virtual void Create(T entity)
        {
            _context.Set<T>().Add(entity);            
        }
        public T Read(int id)
        {
           return _context.Find<T>(id);
        }
        public virtual IQueryable<T> ReadAll()
        {   
            return _context.Set<T>();
        }
        public virtual T Update(T entity)
        {
            return _context.Update<T>(entity).Entity;
        }
        public virtual void Delete(T entity)
        {
            _context.Remove<T>(entity);
        }
    }
}
