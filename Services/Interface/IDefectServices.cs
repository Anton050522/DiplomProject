using RailDBProject.Model;
using System.Collections.Generic;
using System.Linq;

namespace Project.BLL.Services.IServiceIntefaces
{
    public interface IDefectServices
    {
        public List<Defect> GetAll();
        public void CreateDefect(Defect defect);
        public void DeleteDefect(Defect defect);
        public Defect GetById(int id);
        public List<Defect> GetDefectList();
        public IQueryable<Defect> GetQuarable();
        public Defect UpdateDefect(Defect defect);
    }
}
