using Project.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Text;
using Project.Models.Repository.Interfaces;
using System.Collections;
using System.Linq;

namespace Project.Models.Repository.Repositories
{
    public class GlobalSectionRepository : Repository<GlobalSection>, IGlobalSectionRepository
    {
        public GlobalSectionRepository(RailDBContext context) : base(context)
        {
        }
        public RailDBContext RailDBContext
        {
            get { return _context; }
        }


    }
}
