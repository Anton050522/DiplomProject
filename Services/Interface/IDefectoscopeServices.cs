using RailDBProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Interface
{
    public interface IDefectoscopeServices
    {
        public Defectoscope UpdateDefectoscope(Defectoscope defectoscope);
        public List<Defectoscope> GetDefectoscope();
        public IQueryable<Defectoscope> GetQuarable();
        public Defectoscope GetById(int id);
        public void DeleteDefectoscope(Defectoscope defectoscope);
        public void CreateDefectoscope(Defectoscope defectoscope);
        public List<Defectoscope> GetDefectoscopeList();
    }
}
