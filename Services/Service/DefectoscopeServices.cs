using RailDBProject.Model;
using RailDBProject.Repository;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Service
{
    public class DefectoscopeServices : IDefectoscopeServices
    {
        private readonly IUnitOfWork _uow;
        public DefectoscopeServices(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Defectoscope GetById(int id)
        {
            return _uow.DefectoScopes.Read(id);
        }

        public List<Defectoscope> GetDefectoscope()
        {
            return _uow.DefectoScopes
                .ReadAll()
                .ToList();
        }

        public Defectoscope UpdateDefectoscope(Defectoscope defectoscope)
        {
            _uow.DefectoScopes.Update(defectoscope);
            _uow.SaveChanges();
            return defectoscope;
        }
        public void DeleteDefectoscope(Defectoscope defectoscope)
        {
            _uow.DefectoScopes.Delete(defectoscope);
            _uow.SaveChanges();
        }

        public void CreateDefectoscope(Defectoscope defectoscope)
        {
            _uow.DefectoScopes.Create(defectoscope);
            _uow.SaveChanges();
        }

        public List<Defectoscope> GetDefectoscopeList()
        {
            return _uow.DefectoScopes.ReadAll().ToList();
        }

        public IQueryable<Defectoscope> GetQuarable()
        {
            return _uow.DefectoScopes.ReadAll();
        }
    }
}
