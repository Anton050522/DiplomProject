using RailDBProject.Model;
using RailDBProject.Repository.Interface;

namespace RailDBProject.Repository.Repository
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
