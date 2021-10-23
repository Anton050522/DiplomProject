using Reports.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports.BLL
{
    class ReportService<T> : IReportService<T> where T : class
    {
        private readonly UnitOfWork<T> _uow;
        public ReportService(UnitOfWork<T> _unitOfWork)
        {
            _uow = _unitOfWork;
        }

      




    }
}
