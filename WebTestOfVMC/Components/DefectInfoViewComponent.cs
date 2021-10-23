using Common.ListExtentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.BLL.Services.IServiceIntefaces;
using WebTestOfVMC.Models;

namespace WebTestOfVMC.Components
{
    public class DefectInfoViewComponent : ViewComponent
    {
        private readonly IGlobalSectionServices _globalSectionServices;
        private readonly ILocalSectionServices _localSectionServices;

        public DefectInfoViewComponent(IGlobalSectionServices _globalSectionServices, ILocalSectionServices _localSectionServices)
        {
            this._globalSectionServices = _globalSectionServices;
            this._localSectionServices = _localSectionServices;

        }
        public IViewComponentResult Invoke()
        {
            DefectInfo _info = new DefectInfo();
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
