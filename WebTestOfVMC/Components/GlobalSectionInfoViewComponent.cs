using Common.ListExtentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.BLL.Services.IServiceIntefaces;
using RailDBProject.Model;
using System.Linq;
using WebTestOfVMC.Models;

namespace WebTestOfVMC.Components
{
    public class GlobalSectionInfoViewComponent : ViewComponent
    {
        private readonly IOrganisationServices _organisationServices;
        public GlobalSectionInfoViewComponent(IOrganisationServices _organisationServices)
        {
            this._organisationServices = _organisationServices;
        }
        public IViewComponentResult Invoke()
        {
            GlobalSectionInfo _info = new GlobalSectionInfo();
            _info.OrganisationCollection = _organisationServices.GetOrganisationList().Where(o => o.OrganisationRole == OrganisationRole.NOD).ToList();
            _info.SelectList = _info.OrganisationCollection.GetOrganisationSelectList();
            _info.MultiSelectList = new MultiSelectList(_info.OrganisationCollection,
                "OrganisationId", "OrgName");

            return View(_info);
        }
    }
}
