using RailDBProject.Model;
using System.Collections.Generic;
using System.Linq;

namespace Project.BLL.Services.IServiceIntefaces
{
    public interface IOrganisationServices
    {
        public Organisation UpdateOrganisation(Organisation organisation);
        public IQueryable<Organisation> GetQuarable();
        public List<Organisation> GetOrganisationList();
        public Organisation GetById(int id);
        public void DeleteOrganisation(Organisation organisation);
        public void CreateOrganisation(Organisation organisation);
    }
}
