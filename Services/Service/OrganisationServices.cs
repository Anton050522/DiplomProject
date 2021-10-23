using Project.BLL.Services.IServiceIntefaces;
using RailDBProject.Model;
using RailDBProject.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Project.BLL.Services
{
    public class OrganisationServices : IOrganisationServices
    {
        private readonly IUnitOfWork _uow;
        public OrganisationServices(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void CreateOrganisation(Organisation _organisation)
        {
            _uow.Organisations.Create(_organisation);
            _uow.SaveChanges();
        }

        public void DeleteOrganisation(Organisation _organisation)
        {
            _uow.Organisations.Delete(_organisation);
            _uow.SaveChanges();
        }

        public Organisation GetById(int _id)
        {
            return _uow.Organisations.Read(_id);
        }

        public List<Organisation> GetOrganisationList()
        {
            return _uow.Organisations.ReadAll().ToList();
        }

        public Organisation UpdateOrganisation(Organisation _organisation)
        {
            _uow.Organisations.Update(_organisation);
            _uow.SaveChanges();
            return _organisation;
        }

        public IQueryable<Organisation> GetQuarable()
        {
            return _uow.Organisations.ReadAll();
        }
    }
}
