using System;
using Reports.Repository;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports.Repository
{
    public class UnitOfWork<T> : IUnitOfWork<T>, IDisposable where T : class
    {
        private readonly ReportDBContext _context;
        public UnitOfWork(ReportDBContext _context)
        {
            this._context = _context;
        }

        public IReportRepository<T> _reports;
        public IReportRepository<T> Reports
        {
            get => _reports == null ? _reports = new ReportRepository<T>(_context) : _reports;
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
