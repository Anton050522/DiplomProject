using RailDBProject.Model;
using RailDBProject.Repository;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Service
{
    public class DangerousDefectServices : IDangerousDefectServices
    {
        private readonly IUnitOfWork _uow;
        public DangerousDefectServices(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public List<DangerousDefect> GetAll()
        {
            return _uow.DangerousDefects
                  .ReadAll().Where(d => d.IsDeleted == false).ToList();
        }

        public void CreateDangerousDefect(DangerousDefect defect)
        {
            _uow.DangerousDefects.Create(defect);
            _uow.SaveChanges();
        }

        public void DeleteDangerousDefect(DangerousDefect defect)
        {
            _uow.DangerousDefects.Delete(defect);
            _uow.SaveChanges();
        }

        public DangerousDefect GetById(int id)
        {
            return _uow.DangerousDefects.Read(id);
        }

        public List<DangerousDefect> GetDangerousDefectList()
        {
            return _uow.DangerousDefects.ReadAll().ToList();
        }

        public IQueryable<DangerousDefect> GetQuarable()
        {
            return _uow.DangerousDefects.ReadAll();
        }

        public DangerousDefect UpdateDangerousDefect(DangerousDefect defect)
        {
            _uow.DangerousDefects.Update(defect);
            _uow.SaveChanges();
            return defect;
        }

    }
}