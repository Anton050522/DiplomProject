using Common.ListExtentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.BLL.Services.IServiceIntefaces;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTestOfVMC.Models;

namespace WebTestOfVMC.Components
{
    public class DefectoscopeInfoViewComponent : ViewComponent
    {
        private readonly IDefectoscopeServices _defectoscopeServicse;
        private readonly IOrganisationServices _organisationServices;
        private readonly IOperatorServices _operatorServices;

        public DefectoscopeInfoViewComponent(IDefectoscopeServices _defectoscopeServicse, IOrganisationServices _organisationServices, IOperatorServices _operatorServices)
        {
            this._defectoscopeServicse = _defectoscopeServicse;
            this._organisationServices = _organisationServices;
            this._operatorServices = _operatorServices;
        }
        public IViewComponentResult Invoke()
        {
            DefectoScopeInfo _info = new DefectoScopeInfo();
            _info.OrganisationCollection = _organisationServices.GetOrganisationList();
            _info.OrganisationSelectList = _organisationServices.GetOrganisationList().GetOrganisationSelectList();
            _info.DefectoscopeCollection = _defectoscopeServicse.GetDefectoscopeList();
            _info.DefectoscopeSelectList = _defectoscopeServicse.GetDefectoscopeList().GetDefectoscopeSelectList();
            _info.OperatorCollection = _operatorServices.GetOperatorList();
            _info.OperatorSelectList = _operatorServices.GetOperatorList().GetOperatorSelectList();
            _info.OperatorMultiSelectList = new MultiSelectList(_info.OperatorCollection,
                "OperatorId", "LastName");
           
            return View(_info);
        }
    }
}
