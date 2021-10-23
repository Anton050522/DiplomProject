using RailDBProject.Model;
using RailDBProject.Repository.Interface;

namespace RailDBProject.Repository.Repository
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
