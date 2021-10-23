using Common.ListExtentions;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Services.IServiceIntefaces;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTestOfVMC.Models;

namespace WebTestOfVMC.Components
{
    public class OperatorInfoViewComponent : ViewComponent
    {
        private readonly IDefectoscopeServices _defectoscopeServicse;
        private readonly IOrganisationServices _organisationServices;

        public OperatorInfoViewComponent(IDefectoscopeServices _defectoscopeServicse, IOrganisationServices _organisationServices)
        {
            this._defectoscopeServicse = _defectoscopeServicse;
            this._organisationServices = _organisationServices;
        }
        public IViewComponentResult Invoke()
        {
                OperatorInfo _info = new OperatorInfo();
                _info.OrganisationCollection = _organisationServices.GetOrganisationList();
                _info.OrganisationSelectList = _organisationServices.GetOrganisationList().GetOrganisationSelectList();
                _info.DefectoscopeCollection = _defectoscopeServicse.GetDefectoscopeList();
                _info.DefectoscopeSelectList = _defectoscopeServicse.GetDefectoscopeList().GetDefectoscopeSelectList();

            return View(_info);
        }
    }
}
