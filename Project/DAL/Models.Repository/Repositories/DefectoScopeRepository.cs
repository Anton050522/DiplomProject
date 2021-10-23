using Project.DAL.Models.Repository.Interfaces;
using Project.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Models.Repository.Repositories
{
    public class DefectoScopeRepository : Repository<Defectoscope>, IDefectoScopeRepository
    {
        public DefectoScopeRepository(RailDBContext context) : base(context)
        {
        }
        public RailDBContext RailDBContext
        {
            get { return _context; }
        }
    }
}
