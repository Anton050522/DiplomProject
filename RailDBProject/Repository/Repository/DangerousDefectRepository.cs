using RailDBProject.Model;
using RailDBProject.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RailDBProject.Repository.Repository
{
    public class DangerousDefectRepository : Repository<DangerousDefect>, IDangerousDefectRepository
    {
        public DangerousDefectRepository(RailDBContext context) : base(context)
        {
        }
        public RailDBContext RailDBContext
        {
            get { return _context; }
        }

        public override void Create(DangerousDefect defect)
        {
            defect.IsDeleted = false;
            defect.DateOfDetection = DateTime.Now;
            _context.Update(defect);
        }
    }
}