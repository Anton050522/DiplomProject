using Project.BLL.Services.IServiceIntefaces;
using RailDBProject.Model;
using RailDBProject.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Project.BLL.Services
{
    public class LocalSectionServices : ILocalSectionServices
    {
        private readonly IUnitOfWork _uow;
        public LocalSectionServices(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void CreateLocalSection(LocalSection localSection)
        {
            _uow.LocalSections.Create(localSection);
            _uow.SaveChanges();
        }

        public void DeleteLocalSection(LocalSection localSection)
        {
            _uow.LocalSections.Delete(localSection);
            _uow.SaveChanges();
        }

        public LocalSection GetById(int id)
        {
            return _uow.LocalSections.Read(id);
        }

        public List<LocalSection> GetLocalSectionList()
        {
            return _uow.LocalSections.ReadAll().ToList();
        }

        public IQueryable<LocalSection> GetQuarable()
        {
            return _uow.LocalSections.ReadAll();
        }

        public LocalSection UpdateLocalSection(LocalSection localSection)
        {
            _uow.LocalSections.Update(localSection);
            _uow.SaveChanges();
            return localSection;
        }
    }
}
