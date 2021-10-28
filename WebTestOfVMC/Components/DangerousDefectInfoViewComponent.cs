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
    public class DangerousDefectInfoViewComponent : ViewComponent
    {
        private readonly IGlobalSectionServices _globalSectionServices;
        private readonly ILocalSectionServices _localSectionServices;

        public DangerousDefectInfoViewComponent(IGlobalSectionServices _globalSectionServices, ILocalSectionServices _localSectionServices)
        {
            this._globalSectionServices = _globalSectionServices;
            this._localSectionServices = _localSectionServices; 

        }
        public IViewComponentResult Invoke()
        {
            DangerousDefectInfo _info = new DangerousDefectInfo();
            _info.GlobalSectionCollection = _globalSectionServices.GetGlobalSectionList();
            _info.LocalSectionCollection = _localSectionServices.GetLocalSectionList();
            _info.GlobalSectionSelectList = _globalSectionServices.GetGlobalSectionList().GetGlobalSectionSelectList();
            _info.LocalSectionSelectList = _localSectionServices.GetLocalSectionList().GetLocalSectionSelectList();
            _info.GlobalSectionMultiSelectList = new MultiSelectList(_info.GlobalSectionCollection,
                "GlobalSectId", "GlobalSectionName");
            _info.LocalSectionMultiSelectList = new MultiSelectList(_info.LocalSectionCollection,
                "LocalSectionId", "LocalSectionName");

            return View(_info);
        }
    }
}