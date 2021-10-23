using Project.BLL.Services.IServiceIntefaces;
using RailDBProject.Model;
using RailDBProject.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Project.BLL.Services
{
    public class DefectServices : IDefectServices
    {
        private readonly IUnitOfWork _uow;
        public DefectServices(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public List<Defect> GetAll()
        {
            return _uow.Defects
                  .ReadAll().Where(d => d.IsDeleted == false).ToList();
        }

        public void CreateDefect(Defect defect)
        {
            _uow.Defects.Create(defect);
            _uow.SaveChanges();
        }

        public void DeleteDefect(Defect defect)
        {
            _uow.Defects.Delete(defect);
            _uow.SaveChanges();
        }

        public Defect GetById(int id)
        {
            return _uow.Defects.Read(id);
        }

        public List<Defect> GetDefectList()
        {
            return _uow.Defects.ReadAll().ToList();
        }

        public IQueryable<Defect> GetQuarable()
        {
            return _uow.Defects.ReadAll();
        }

        public Defect UpdateDefect(Defect defect)
        {
            _uow.Defects.Update(defect);
            _uow.SaveChanges();
            return defect;
        }
    }
}