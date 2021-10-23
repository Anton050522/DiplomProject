
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports.Repository
{
    public interface IUnitOfWork<T> : IDisposable where T : class
    {
        IReportRepository<T> Reports { get; }
        public int SaveChanges();
    }
}
