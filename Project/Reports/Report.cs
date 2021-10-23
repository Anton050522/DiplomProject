using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports
{
    public class Report
    {
        public int ReportId { get; set; }
        public string ReportName { get; set; }
        public DateTime ReportDate { get; set; }
        public object ReportData { get; set; }
    }
}
