using Project.BLL.Services.IServiceIntefaces;
using RailDBProject.Model;
using RailDBProject.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Project.BLL.Services
{
    public class GlobalSectionServices : IGlobalSectionServices
    {
        private readonly IUnitOfWork _uow;
        public GlobalSectionServices(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void CreateGlobalSection(GlobalSection globalSection)
        {
            _uow.GlobalSections.Create(globalSection);
            _uow.SaveChanges();
        }

        public void DeleteGlobalSection(GlobalSection globalSection)
        {
            _uow.GlobalSections.Delete(globalSection);
            _uow.SaveChanges();
        }

        public GlobalSection GetById(int id)
        {
            return _uow.GlobalSections.Read(id);
        }

        public List<GlobalSection> GetGlobalSectionList()
        {
            return _uow.GlobalSections.ReadAll().ToList();
        }

        public IQueryable<GlobalSection> GetQuarable()
        {
            return _uow.GlobalSections.ReadAll();
        }

        public GlobalSection UpdateGlobalSection(GlobalSection globalSection)
        {
            _uow.GlobalSections.Update(globalSection);
            _uow.SaveChanges();
            return globalSection;
        }
    }
}
