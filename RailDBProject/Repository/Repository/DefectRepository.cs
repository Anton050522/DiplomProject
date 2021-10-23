using RailDBProject.Model;
using RailDBProject.Repository.Interface;
using System;

namespace RailDBProject.Repository.Repository
{
    public class DefectRepository : Repository<Defect>, IDefectRepository
    {
        public DefectRepository(RailDBContext context) : base(context)
        {
        }
        public RailDBContext RailDBContext
        {
            get { return _context; }
        }

        public override void Create(Defect defect)
        {
            defect.IsDeleted = false;
            defect.DateOfDetection = DateTime.Now;
            _context.Update(defect);
        }
    }
}
