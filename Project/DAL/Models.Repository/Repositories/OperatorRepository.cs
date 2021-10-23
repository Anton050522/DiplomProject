using Project.DAL.Models.Repository.Interfaces;
using Project.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Models.Repository.Repositories
{
    public class OperatorRepository : Repository<Operator>, IOperatorRepository
    {
        public OperatorRepository(RailDBContext context) : base(context)
        {
        }
        public RailDBContext RailDBContext
        {
            get { return _context; }
        }
    }
}
