using Common.ListExtentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.BLL.Services.IServiceIntefaces;
using WebTestOfVMC.Models;

namespace WebTestOfVMC.Components
{
    public class OrganisationInfoViewComponent : ViewComponent
    {
        private readonly IOrganisationServices _organisationServices;
        public OrganisationInfoViewComponent(IOrganisationServices _organisationServices)
        {
            this._organisationServices = _organisationServices;
        }
        public IViewComponentResult Invoke()
        {

            OrganisationInfo _info = new OrganisationInfo();
            _info.SelectList = _organisationServices.GetOrganisationList().GetOrganisationSelectList();
            _info.OrganisationCollection = _organisationServices.GetOrganisationList();
            _info.MultiSelectList = new MultiSelectList(_info.OrganisationCollection,
                "OrganisationId", "OrgName");

            return View(_info);
        }
    }

}


