using Common.ListExtentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.BLL.Services.IServiceIntefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTestOfVMC.Models;

namespace WebTestOfVMC.Components
{
    public class LocalSectionInfoViewComponent : ViewComponent
    {
        private readonly IGlobalSectionServices _globalSectionServices;
        private readonly IOrganisationServices _organisationServices;
        public LocalSectionInfoViewComponent(IGlobalSectionServices _globalSectionServices, IOrganisationServices _organisationServices)
        {
            this._globalSectionServices = _globalSectionServices;
            this._organisationServices = _organisationServices;
        }
        public IViewComponentResult Invoke()
        {

            LocalSectionInfo _info = new LocalSectionInfo();
            _info.OrganisationCollection = _organisationServices.GetOrganisationList().Where(o => o.OrganisationRole == RailDBProject.Model.OrganisationRole.PCH).ToList();
            _info.OrganisationSelectList = _info.OrganisationCollection.GetOrganisationSelectList();
            _info.GlobalSectionCollection = _globalSectionServices.GetGlobalSectionList();
            _info.SelectList = _globalSectionServices.GetGlobalSectionList().GetGlobalSectionSelectList();
            _info.MultiSelectList = new MultiSelectList(_info.GlobalSectionCollection,
                "GlobalSectId", "GlobalSectionName");

            return View(_info);
        }
    }
}
