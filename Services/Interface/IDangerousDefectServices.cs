using RailDBProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Interface
{
    public interface IDangerousDefectServices
    {
        public List<DangerousDefect> GetAll();
        public void CreateDangerousDefect(DangerousDefect defect);
        public void DeleteDangerousDefect(DangerousDefect defect);
        public DangerousDefect GetById(int id);
        public List<DangerousDefect> GetDangerousDefectList();
        public IQueryable<DangerousDefect> GetQuarable();
        public DangerousDefect UpdateDangerousDefect(DangerousDefect defect);
    }
}