using Project.DAL.Models.Repository.Interfaces;
using Project.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Models.Repository.Repositories
{
    public class DefectAuditRepository : Repository<DefectAuditRepository>, IDefectAuditRepository  
    {
        public DefectAuditRepository(RailDBContext context) : base(context)
        {
        }
        public RailDBContext RailDBContext
        {
            get { return _context; }
        }
    }
}
