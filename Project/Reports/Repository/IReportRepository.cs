using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports.Repository
{
    public interface IReportRepository<T> where T : class
    {
        public void Create(T report);
        public T Read(int id);
        public void Delete(T report);
        public IQueryable<T> ReadAll();
    }
}
