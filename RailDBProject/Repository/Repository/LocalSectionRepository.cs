using RailDBProject.Model;
using RailDBProject.Repository.Interface;

namespace RailDBProject.Repository.Repository
{
    public class LocalSectionRepository : Repository<LocalSection>, ILocalSectionRepository
    {
        public LocalSectionRepository(RailDBContext context) : base(context)
        {
        }
        public RailDBContext RailDBContext
        {
            get { return _context; }
        }
    }
}
