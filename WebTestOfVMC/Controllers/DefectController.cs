using Common.ListExtentions;
using CommonClasses.PaginationAndSort.Filters;
using CommonClasses.PaginationAndSort.IndexViewModelClasses;
using CommonClasses.PaginationAndSort.PageViewClass;
using CommonClasses.PaginationAndSort.SortingClasses;
using EnumExt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.BLL.Services.IServiceIntefaces;
using RailDBProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTestOfVMC.Models;
using System.Globalization;
using Services.Interface;

namespace WebApplication.Controllers
{
    public class DefectController : Controller
    {
        private readonly IDefectServices _defectService;
        private readonly ILocalSectionServices _localSectionServices;
        private readonly IGlobalSectionServices _globalSectionServices;
        private readonly IOrganisationServices _organisationServices;
        private readonly IUserServices _userServices;

        public DefectController(IDefectServices _defectService, ILocalSectionServices _localSectionServices,
                IGlobalSectionServices _globalSectionServices, IOrganisationServices _organisationServices, IUserServices _userServices)
        {
            this._defectService = _defectService;
            this._localSectionServices = _localSectionServices;
            this._globalSectionServices = _globalSectionServices;
            this._organisationServices = _organisationServices;
            this._userServices = _userServices;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var defects = _defectService.GetAll();

            var model = new List<DefectInfo>();

            model = defects.Select(o => new DefectInfo
            {
                DefectCode = o.DefectCode,
                DefectLenght = o.DefectLenght,
                DefectDepth = o.DefectDepth,
                DateOfDetection = o.DateOfDetection,
                Path = o.Path,
                ManufactureYear = o.ManufactureYear,
                DefectId = o.DefectId,
                WaySide = o.WaySide
            }).ToList();

            return View(model);
        }

        public async Task<IActionResult> Index(int? defect, int? glSection, int? organisation, int? lcSection, string localName,
                                              string orgName, string glName, string name, int page = 1, DefectSortState sortOrder = DefectSortState.DateOfDetectionAsc)
        {
            int pageSize = 10;

            var userEmail = HttpContext.User.Identity.Name;
            var user = _userServices.GetByEmail(userEmail);
            IQueryable<Defect> defects;

            if (user.Organisation.OrganisationRole == OrganisationRole.PCH)
            {
                defects = _defectService.GetQuarable().Where(d => d.LocalSection.GlobalSection.Organisations.Any(o => o.Users.Any(u => u.Email == userEmail)));
            }
            else if (user.Organisation.OrganisationRole == OrganisationRole.NOD)
            {
                defects = _defectService.GetQuarable().Where(d => d.LocalSection.GlobalSection.Organisations.Any(o => o.Parent == user.Organisation));
            }
            else
            {
                defects = _defectService.GetQuarable();
            }

            if (defect != null && defect != 0)
            {
                var stringId = defect.ToString();
                var selectedDefect = _defectService.GetById(Convert.ToInt32(stringId));
                string selectedName = selectedDefect.DefectCodeName;
                defects = defects.Where(d => d.DefectCodeName == selectedName);
            }

            if (glSection != null && glSection != 0)
            {
                defects = defects.Where(g => g.LocalSection.GlobalSection.GlobalSectId == glSection);
            }

            if (lcSection != null && lcSection != 0)
            {
                defects = defects.Where(l => l.LocalSection.LocalSectionId == lcSection);
            }

            if (organisation != null && organisation != 0)
            {
                defects = defects.Where(o => o.LocalSection.GlobalSection.Organisations.Any(o => o.OrganisationId == organisation));
            }

            switch (sortOrder)
            {
                case DefectSortState.DateOfDetectionDesc:
                    defects = defects.OrderByDescending(s => s.DateOfDetection);
                    break;
                case DefectSortState.DateOfDetectionAsc:
                    defects = defects.OrderBy(s => s.DateOfDetection);
                    break;
                case DefectSortState.DefectCodeDesc:
                    defects = defects.OrderByDescending(s => s.DefectCode);
                    break;
                case DefectSortState.DefectCodeAsc:
                    defects = defects.OrderBy(s => s.DefectCode);
                    break;
                case DefectSortState.DefectDepthDesc:
                    defects = defects.OrderByDescending(s => s.DefectDepth);
                    break;
                case DefectSortState.DefectDepthAsc:
                    defects = defects.OrderBy(s => s.DefectDepth);
                    break;
                case DefectSortState.DefectLenghtDesc:
                    defects = defects.OrderByDescending(s => s.DefectLenght);
                    break;
                case DefectSortState.DefectLenghtAsc:
                    defects = defects.OrderBy(s => s.DefectLenght);
                    break;
                case DefectSortState.KilometerDesc:
                    defects = defects.OrderByDescending(s => s.Kilometer);
                    break;
                case DefectSortState.KilometerAsc:
                    defects = defects.OrderBy(s => s.Kilometer);
                    break;
                case DefectSortState.PktDesc:
                    defects = defects.OrderByDescending(s => s.Pkt);
                    break;
                case DefectSortState.PktAsc:
                    defects = defects.OrderBy(s => s.Pkt);
                    break;
                case DefectSortState.WaySideDesc:
                    defects = defects.OrderByDescending(s => s.WaySide);
                    break;
                case DefectSortState.WaySideAsc:
                    defects = defects.OrderBy(s => s.WaySide);
                    break;
                case DefectSortState.PathDesc:
                    defects = defects.OrderByDescending(s => s.Path);
                    break;
                case DefectSortState.PathAsc:
                    defects = defects.OrderBy(s => s.Path);
                    break;
            }

            var count = await defects.CountAsync();
            var items = await defects.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            DefectIndexViewModel viewModel = new DefectIndexViewModel
            {
                PageView = new PageView(count, page, pageSize),
                DefectSortViewModel = new DefectSortViewModel(sortOrder),
                DefectFilter = new DefectFilter(_defectService.GetDefectList(), defect, name),
                OrganisationFilter = new OrganisationFilter(_organisationServices.GetOrganisationList(), organisation, orgName),
                GlobalSectionFilter = new GlobalSectionFilter(_globalSectionServices.GetGlobalSectionList(), glSection, glName),
                LocalSectionFilter = new LocalSectionFilter(_localSectionServices.GetLocalSectionList(), lcSection, localName),
                Defects = items
            };
            return View(viewModel);
        }

        public IActionResult GetOne(int id)
        {
            var _defect = _defectService.GetById(id);

            var model = new DefectInfo
            {
                DefectId = _defect.DefectId,
                LocalSection = _defect.LocalSection,
                DateOfDetection = _defect.DateOfDetection,
                DefectCode = _defect.DefectCode,
                WaySide = _defect.WaySide,
                Path = _defect.Path,
                Kilometer = _defect.Kilometer,
                Pkt = _defect.Pkt,
                Manufacture = _defect.Manufacture,
                ManufactureYear = _defect.ManufactureYear,
                DefectCodeName = _defect.DefectCode.GetEnumDescription(),
                DefectDepth = _defect.DefectDepth,
                DefectLenght = _defect.DefectLenght,
                DefectCollection = _defectService.GetDefectList(),
                DefectSelectList = _defectService.GetDefectList().GetDefectSelectList(),
                LocalSectionCollection = _localSectionServices.GetLocalSectionList(),
                LocalSectionSelectList = _localSectionServices.GetLocalSectionList().GetLocalSectionSelectList()
            };
            return PartialView(model);
        }

        public IActionResult CreateDefect(DefectInfo info)
        {
            var localSection = _localSectionServices.GetById(info.LocalSection.LocalSectionId);

            Defect defect = new Defect
            {
                DateOfDetection = info.DateOfDetection,
                LocalSection = localSection,
                Kilometer = info.Kilometer,
                Pkt = info.Pkt,
                WaySide = info.WaySide,
                Path = info.Path,
                Manufacture = info.Manufacture,
                ManufactureYear = info.ManufactureYear,
                DefectCode = info.DefectCode,
                DefectCodeName = info.DefectCode.GetEnumDescription(),
                DefectDepth = info.DefectDepth,
                DefectLenght = info.DefectLenght
            };

            _defectService.CreateDefect(defect);

            return Json(new
            {
                url = Url.Action("Index", "Defect"),
                emailMessage = "Добавление прошло успешно!"
            });

        }

        public IActionResult UpdateDefect(DefectInfo info)
        {
            var newLocalSect = _localSectionServices.GetById(info.LocalSection.LocalSectionId);
            var _defect = _defectService.GetById(info.DefectId);

            _defect.DateOfDetection = info.DateOfDetection;
            _defect.LocalSection = newLocalSect;
            _defect.Kilometer = info.Kilometer;
            _defect.Pkt = info.Pkt;
            _defect.WaySide = info.WaySide;
            _defect.Path = info.Path;
            _defect.Manufacture = info.Manufacture;
            _defect.ManufactureYear = info.ManufactureYear;
            _defect.DefectCode = info.DefectCode;
            _defect.DefectCodeName = info.DefectCode.GetEnumDescription();
            _defect.DefectLenght = info.DefectLenght;
            _defect.DefectDepth = info.DefectDepth;

            _defectService.UpdateDefect(_defect);

            return Json(new
            {
                newData = new
                {
                    emailMessage = "Редактирование прошло успешно",
                    url = Url.Action("Index", "Defect")
                }
            });
        }

        public IActionResult DeleteDefect(int id)
        {
            var _defect = _defectService.GetById(id);
            _defectService.DeleteDefect(_defect);

            return Json(new
            {
                url = Url.Action("Index", "User"),
                emailMessage = "Удаление прошло успешно!"

            });
        }

        public IActionResult GetLocalFromGlobal(string name)
        {

            var localSections = _localSectionServices.GetLocalSectionList()
                                .Where(l => l.GlobalSection.GlobalSectionName == name).ToList();
            var selectList = localSections.GetLocalSectionSelectList();

            var model = new DefectInfo()
            {

                LocalSectionCollection = localSections,
                LocalSectionSelectList = selectList
            };
            return PartialView(model);
        }
    }
}
