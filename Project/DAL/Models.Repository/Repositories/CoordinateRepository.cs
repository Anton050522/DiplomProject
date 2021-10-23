using Project.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Text;
using Project.Models.Repository.Interfaces;

namespace Project.Models.Repository.Repositories
{
    public class CoordinateRepository : Repository<Coordinate>, ICoordinateRepository
    {
        public CoordinateRepository(RailDBContext context) : base(context)
        {
        }
        public RailDBContext RailDBContext
        {
            get { return _context; }
        }
    }
}
