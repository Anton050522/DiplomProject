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
using ClosedXML.Excel;
using System.IO;

namespace WebApplication.Controllers
{
    public class DangerousDefectController : Controller
    {
        private readonly IDangerousDefectServices _dangerousDefectService;
        private readonly ILocalSectionServices _localSectionServices;
        private readonly IGlobalSectionServices _globalSectionServices;
        private readonly IOrganisationServices _organisationServices;
        private readonly IUserServices _userServices;
        public static DangerousDefectIndexViewModel currentModel;

        public DangerousDefectController(IDangerousDefectServices _dangerousDefectService, ILocalSectionServices _localSectionServices,
                IGlobalSectionServices _globalSectionServices, IOrganisationServices _organisationServices, IUserServices _userServices)
        {
            this._dangerousDefectService = _dangerousDefectService;
            this._localSectionServices = _localSectionServices;
            this._globalSectionServices = _globalSectionServices;
            this._organisationServices = _organisationServices;
            this._userServices = _userServices;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var defects = _dangerousDefectService.GetAll();

            var model = new List<DangerousDefectInfo>();

            model = defects.Select(o => new DangerousDefectInfo
            {
                DangerousDefectCode = o.DangerousDefectCode,
                DangerousDefectLenght = o.DangerousDefectLenght,
                DangerousDefectDepth = o.DangerousDefectDepth,
                DangerousDefectAverageLenght = o.DangerousDefectAverageLenght,
                DangerousDefectAverageDepth = o.DangerousDefectAverageDepth,
                DateOfDetection = o.DateOfDetection,
                Path = o.Path,
                ManufactureYear = o.ManufactureYear,
                DangerousDefectId = o.DangerousDefectId,
                WaySide = o.WaySide
            }).ToList();

            return View(model);
        }

        public async Task<IActionResult> Index(int? defect, int? glSection, int? organisation, int? lcSection, string localName,
                                              string orgName, string glName, string name, int page = 1, DangerousDefectSortState sortOrder = DangerousDefectSortState.DateOfDetectionAsc)
        {
            int pageSize = 10;

            var userEmail = HttpContext.User.Identity.Name;
            var user = _userServices.GetByEmail(userEmail);
            IQueryable<DangerousDefect> defects;

            if (user.Organisation.OrganisationRole == OrganisationRole.PCH)
            {
                defects = _dangerousDefectService.GetQuarable().Where(d => d.LocalSection.GlobalSection.Organisations.Any(o => o.Users.Any(u => u.Email == userEmail)));
            }
            else if (user.Organisation.OrganisationRole == OrganisationRole.NOD)
            {
                defects = _dangerousDefectService.GetQuarable().Where(d => d.LocalSection.GlobalSection.Organisations.Any(o => o.Parent == user.Organisation));
            }
            else
            {
                defects = _dangerousDefectService.GetQuarable();
            }

            if (defect != null && defect != 0)
            {
                var stringId = defect.ToString();
                var selectedDefect = _dangerousDefectService.GetById(Convert.ToInt32(stringId));
                string selectedName = selectedDefect.DangerousDefectCodeName;
                defects = defects.Where(d => d.DangerousDefectCodeName == selectedName);
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
                case DangerousDefectSortState.DateOfDetectionDesc:
                    defects = defects.OrderByDescending(s => s.DateOfDetection);
                    break;
                case DangerousDefectSortState.DateOfDetectionAsc:
                    defects = defects.OrderBy(s => s.DateOfDetection);
                    break;
                case DangerousDefectSortState.DangerousDefectCodeDesc:
                    defects = defects.OrderByDescending(s => s.DangerousDefectCode);
                    break;
                case DangerousDefectSortState.DangerousDefectCodeAsc:
                    defects = defects.OrderBy(s => s.DangerousDefectCode);
                    break;
                case DangerousDefectSortState.DangerousDefectDepthDesc:
                    defects = defects.OrderByDescending(s => s.DangerousDefectDepth);
                    break;
                case DangerousDefectSortState.DangerousDefectDepthAsc:
                    defects = defects.OrderBy(s => s.DangerousDefectDepth);
                    break;
                case DangerousDefectSortState.DangerousDefectLenghtDesc:
                    defects = defects.OrderByDescending(s => s.DangerousDefectLenght);
                    break;
                case DangerousDefectSortState.DangerousDefectLenghtAsc:
                    defects = defects.OrderBy(s => s.DangerousDefectLenght);
                    break;
                case DangerousDefectSortState.DangerousDefectAverageDepthDesc:
                    defects = defects.OrderByDescending(s => s.DangerousDefectAverageDepth);
                    break;
                case DangerousDefectSortState.DangerousDefectAverageDepthAsc:
                    defects = defects.OrderBy(s => s.DangerousDefectAverageDepth);
                    break;
                case DangerousDefectSortState.DangerousDefectAverageLenghtDesc:
                    defects = defects.OrderByDescending(s => s.DangerousDefectAverageLenght);
                    break;
                case DangerousDefectSortState.DangerousDefectAverageLenghtAsc:
                    defects = defects.OrderBy(s => s.DangerousDefectLenght);
                    break;
                case DangerousDefectSortState.KilometerDesc:
                    defects = defects.OrderByDescending(s => s.Kilometer);
                    break;
                case DangerousDefectSortState.KilometerAsc:
                    defects = defects.OrderBy(s => s.Kilometer);
                    break;
                case DangerousDefectSortState.PktDesc:
                    defects = defects.OrderByDescending(s => s.Pkt);
                    break;
                case DangerousDefectSortState.PktAsc:
                    defects = defects.OrderBy(s => s.Pkt);
                    break;
                case DangerousDefectSortState.WaySideDesc:
                    defects = defects.OrderByDescending(s => s.WaySide);
                    break;
                case DangerousDefectSortState.WaySideAsc:
                    defects = defects.OrderBy(s => s.WaySide);
                    break;
                case DangerousDefectSortState.PathDesc:
                    defects = defects.OrderByDescending(s => s.Path);
                    break;
                case DangerousDefectSortState.PathAsc:
                    defects = defects.OrderBy(s => s.Path);
                    break;
            }

            var count = await defects.CountAsync();
            var items = await defects.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            DangerousDefectIndexViewModel viewModel = new DangerousDefectIndexViewModel
            {
                PageView = new PageView(count, page, pageSize),
                DangerousDefectSortViewModel = new DangerousDefectSortViewModel(sortOrder),
                DangerousDefectFilter = new DangerousDefectFilter(_dangerousDefectService.GetDangerousDefectList(), defect, name),
                OrganisationFilter = new OrganisationFilter(_organisationServices.GetOrganisationList(), organisation, orgName),
                GlobalSectionFilter = new GlobalSectionFilter(_globalSectionServices.GetGlobalSectionList(), glSection, glName),
                LocalSectionFilter = new LocalSectionFilter(_localSectionServices.GetLocalSectionList(), lcSection, localName),
                DangerousDefects = items
            };

            currentModel = viewModel;

            return View(viewModel);
        }

        public IActionResult GetOne(int id)
        {
            var _defect = _dangerousDefectService.GetById(id);

            var model = new DangerousDefectInfo
            {
                DangerousDefectId = _defect.DangerousDefectId,
                LocalSection = _defect.LocalSection,
                DateOfDetection = _defect.DateOfDetection,
                DangerousDefectCode = _defect.DangerousDefectCode,
                WaySide = _defect.WaySide,
                Path = _defect.Path,
                Kilometer = _defect.Kilometer,
                Pkt = _defect.Pkt,
                Manufacture = _defect.Manufacture,
                ManufactureYear = _defect.ManufactureYear,
                DangerousDefectCodeName = _defect.DangerousDefectCode.GetEnumDescription(),
                DangerousDefectDepth = _defect.DangerousDefectDepth,
                DangerousDefectLenght = _defect.DangerousDefectLenght,
                DangerousDefectAverageDepth = _defect.DangerousDefectAverageDepth,
                DangerousDefectAverageLenght = _defect.DangerousDefectAverageLenght,
                DangerousDefectCollection = _dangerousDefectService.GetDangerousDefectList(),
                DangerousDefectSelectList = _dangerousDefectService.GetDangerousDefectList().GetDangerousDefectSelectList(),
                LocalSectionCollection = _localSectionServices.GetLocalSectionList(),
                LocalSectionSelectList = _localSectionServices.GetLocalSectionList().GetLocalSectionSelectList()
            };
            return PartialView(model);
        }

        public IActionResult CreateDangerousDefect(DangerousDefectInfo info)
        {
            var localSection = _localSectionServices.GetById(info.LocalSection.LocalSectionId);

            DangerousDefect defect = new DangerousDefect
            {
                DateOfDetection = info.DateOfDetection,
                LocalSection = localSection,
                Kilometer = info.Kilometer,
                Pkt = info.Pkt,
                WaySide = info.WaySide,
                Path = info.Path,
                Manufacture = info.Manufacture,
                ManufactureYear = info.ManufactureYear,
                DangerousDefectDepth = info.DangerousDefectDepth,
                DangerousDefectLenght = info.DangerousDefectLenght,
                DangerousDefectAverageDepth = info.DangerousDefectAverageDepth,
                DangerousDefectAverageLenght = info.DangerousDefectAverageLenght,
                DangerousDefectCode = info.DangerousDefectCode,
                DangerousDefectCodeName = info.DangerousDefectCode.GetEnumDescription()
            };

            _dangerousDefectService.CreateDangerousDefect(defect);

            return Json(new
            {
                url = Url.Action("Index", "DangerousDefect"),
                emailMessage = "Добавление прошло успешно!"
            });

        }

        public IActionResult UpdateDangerousDefect(DangerousDefectInfo info)
        {
            var newLocalSect = _localSectionServices.GetById(info.LocalSection.LocalSectionId);
            var _defect = _dangerousDefectService.GetById(info.DangerousDefectId);

            _defect.DateOfDetection = info.DateOfDetection;
            _defect.LocalSection = newLocalSect;
            _defect.Kilometer = info.Kilometer;
            _defect.Pkt = info.Pkt;
            _defect.WaySide = info.WaySide;
            _defect.Path = info.Path;
            _defect.Manufacture = info.Manufacture;
            _defect.ManufactureYear = info.ManufactureYear;
            _defect.DangerousDefectCode = info.DangerousDefectCode;
            _defect.DangerousDefectCodeName = info.DangerousDefectCode.GetEnumDescription();
            _defect.DangerousDefectLenght = info.DangerousDefectLenght;
            _defect.DangerousDefectLenght = info.DangerousDefectLenght;
            _defect.DangerousDefectAverageDepth = info.DangerousDefectAverageDepth;
            _defect.DangerousDefectAverageDepth = info.DangerousDefectAverageDepth;

            _dangerousDefectService.UpdateDangerousDefect(_defect);

            return Json(new
            {
                newData = new
                {
                    emailMessage = "Редактирование прошло успешно",
                    url = Url.Action("Index", "DangerousDefect")
                }
            });
        }

        public IActionResult DeleteDangerousDefect(int id)
        {
            var _defect = _dangerousDefectService.GetById(id);
            _dangerousDefectService.DeleteDangerousDefect(_defect);

            return Json(new
            {
                url = Url.Action("Index", "DangerousDefect"),
                emailMessage = "Удаление прошло успешно!"

            });
        }

        public IActionResult GetLocalFromGlobal(string name)
        {

            var localSections = _localSectionServices.GetLocalSectionList()
                                .Where(l => l.GlobalSection.GlobalSectionName == name).ToList();
            var selectList = localSections.GetLocalSectionSelectList();

            var model = new DangerousDefectInfo()
            {

                LocalSectionCollection = localSections,
                LocalSectionSelectList = selectList
            };
            return PartialView(model);
        }

        public IActionResult Export()
        {
            using (IXLWorkbook workbook = new XLWorkbook(XLEventTracking.Disabled))
            {
                var worksheet = workbook.Worksheets.Add("DangerousDefects");

                worksheet.Cell(1, 1).Value = "Информация об остродефектных рельсах";
                worksheet.Cell(1, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                worksheet.Cell(1, 1).Style.Fill.BackgroundColor = XLColor.Cyan;
                worksheet.Range(1, 1, 1, 12).Merge().AddToNamed("Titles");
                worksheet.Cell(2, 1).Value = "Дата обнаружения";
                worksheet.Cell(2, 2).Value = "Перегон";
                worksheet.Cell(2, 3).Value = "№ пути";
                worksheet.Cell(2, 4).Value = "Километр";
                worksheet.Cell(2, 5).Value = "Пикет";
                worksheet.Cell(2, 6).Value = "Звено";
                worksheet.Cell(2, 7).Value = "Нить";
                worksheet.Cell(2, 8).Value = "Производитель";
                worksheet.Cell(2, 9).Value = "Год прокатки";
                worksheet.Cell(2, 10).Value = "Код дефекта";
                worksheet.Cell(2, 11).Value = "Глубина залегания (Н)";
                worksheet.Cell(2, 12).Value = "Протяженность (L)";
                worksheet.Cell(2, 13).Value = "Условная высота (дельта Н)";
                worksheet.Cell(2, 14).Value = "Условная протяженность (дельта L)";
                worksheet.Range(2, 1, 2, 14).SetAutoFilter();
                worksheet.Row(1).Style.Font.Bold = true;

                for (int i = 0; i < currentModel.DangerousDefects.ToList().Count; i++)
                {
                    worksheet.Cell(i + 3, 1).Value = currentModel.DangerousDefects.ToList()[i].DateOfDetection;
                    worksheet.Cell(i + 3, 2).Value = currentModel.DangerousDefects.ToList()[i].LocalSection.LocalSectionName;
                    worksheet.Cell(i + 3, 3).Value = currentModel.DangerousDefects.ToList()[i].LocalSection.LocalWayNumber;
                    worksheet.Cell(i + 3, 4).Value = currentModel.DangerousDefects.ToList()[i].Kilometer;
                    worksheet.Cell(i + 3, 5).SetValue(currentModel.DangerousDefects.ToList()[i].Pkt);
                    worksheet.Cell(i + 3, 6).Value = currentModel.DangerousDefects.ToList()[i].Path;
                    worksheet.Cell(i + 3, 7).Value = currentModel.DangerousDefects.ToList()[i].WaySide.GetEnumDescription();
                    worksheet.Cell(i + 3, 8).Value = currentModel.DangerousDefects.ToList()[i].Manufacture.GetEnumDescription();
                    worksheet.Cell(i + 3, 9).Value = currentModel.DangerousDefects.ToList()[i].ManufactureYear;
                    worksheet.Cell(i + 3, 10).Value = currentModel.DangerousDefects.ToList()[i].DangerousDefectCode.GetEnumDescription();
                    worksheet.Cell(i + 3, 11).Value = currentModel.DangerousDefects.ToList()[i].DangerousDefectDepth;
                    worksheet.Cell(i + 3, 12).Value = currentModel.DangerousDefects.ToList()[i].DangerousDefectLenght;
                    worksheet.Cell(i + 3, 13).Value = currentModel.DangerousDefects.ToList()[i].DangerousDefectAverageDepth;
                    worksheet.Cell(i + 3, 14).Value = currentModel.DangerousDefects.ToList()[i].DangerousDefectAverageLenght;
                }

                using (var stream = new MemoryStream())
                {
                    worksheet.Columns().AdjustToContents();
                    worksheet.Rows().AdjustToContents();
                    workbook.SaveAs(stream);
                    stream.Flush();

                    return new FileContentResult(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        FileDownloadName = $"ОДР по состоянию на {DateTime.UtcNow.ToShortDateString()}.xlsx"
                    };
                }
            }
        }
    }
}