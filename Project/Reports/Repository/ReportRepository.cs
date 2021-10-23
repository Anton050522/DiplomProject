using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports.Repository
{
    class ReportRepository<T> : IReportRepository<T> where T : class
    {
        protected readonly ReportDBContext _context;
        public ReportRepository(ReportDBContext _context)
        {
            this._context = _context;
        }

        public void Create(T report)
        {
            _context.Set<T>().Add(report);
        }
        public T Read(int id)
        {
            return _context.Find<T>(id);
        }
        public virtual IQueryable<T> ReadAll()
        {
            return _context.Set<T>();
        }
        public virtual void Delete(T report)
        {
            _context.Remove<T>(report);
        }
    }
}
