using Common.ListExtentions;
using CommonClasses.PaginationAndSort.Filters;
using CommonClasses.PaginationAndSort.IndexViewModelClasses;
using CommonClasses.PaginationAndSort.PageViewClass;
using CommonClasses.PaginationAndSort.SortingClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.BLL.Services.IServiceIntefaces;
using RailDBProject.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTestOfVMC.Models;

namespace WebTestOfVMC.Controllers
{
    public class GlobalSectionController : Controller
    {
        private readonly IGlobalSectionServices _globalSectionSetvice;
        private readonly IOrganisationServices _organisationServices;

        public GlobalSectionController(IGlobalSectionServices _globalSectionSetvice, IOrganisationServices _organisationServices)
        {
            this._globalSectionSetvice = _globalSectionSetvice;
            this._organisationServices = _organisationServices;
        }

        public async Task<IActionResult> Index(int? company, string name, int page = 1,
                                         GlobalSectionSortState sortOrder = GlobalSectionSortState.GlobalSectionNameAsc)
        {
            int pageSize = 10;

            IQueryable<GlobalSection> sections = _globalSectionSetvice.GetQuarable();

            if (company != null && company != 0)
            {
                sections = sections.Where(p => p.Organisations.Any(o => o.OrganisationId == company));
            }

            switch (sortOrder)
            {
                case GlobalSectionSortState.GlobalSectionNameDesc:
                    sections = sections.OrderByDescending(s => s.GlobalSectionName);
                    break;
                case GlobalSectionSortState.GlobalSectionNameAsc:
                    sections = sections.OrderBy(s => s.GlobalSectionName);
                    break;
                case GlobalSectionSortState.GlobalWayDesc:
                    sections = sections.OrderByDescending(s => s.GlobalWayNumber);
                    break;
                case GlobalSectionSortState.GlobalWayAsc:
                    sections = sections.OrderBy(s => s.GlobalWayNumber);
                    break;
            }

            var count = await sections.CountAsync();
            var items = await sections.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            GlobalSectionIndexViewModel viewModel = new GlobalSectionIndexViewModel
            {
                PageView = new PageView(count, page, pageSize),
                GlobalSectionSortViewModel = new GlobalSectionSortViewModel(sortOrder),
                OrganisationFilter = new OrganisationFilter(_organisationServices.GetOrganisationList(), company, name),
                GlobalSections = items
            };
            return View(viewModel);
        }

        public IActionResult GetOne(int id)
        {
            var _globalSection = _globalSectionSetvice.GetById(id);
            var _organisations = _organisationServices.GetOrganisationList().Where(o => o.OrganisationRole == OrganisationRole.NOD).ToList();

            var model = new GlobalSectionInfo
            {
                GlobalSectId = _globalSection.GlobalSectId,
                GlobalWayNumber = _globalSection.GlobalWayNumber,
                GlobalSectionName = _globalSection.GlobalSectionName,
                Organisations = _globalSection.Organisations,
                OrganisationCollection = _organisations,
                SelectList = _organisations.GetOrganisationSelectList(),
                MultiSelectList = new MultiSelectList(_organisations, "OrganisationId", "OrgName")
            };
            return PartialView(model);
        }

        public IActionResult UpdateGlobalSection(GlobalSectionInfo info)
        {
            List<Organisation> _organisations = new List<Organisation>();

            foreach (var item in info.SelectedOrganisation)
            {
                _organisations.Add(_organisationServices.GetById(item));
            }

            var _globalSection = _globalSectionSetvice.GetById(info.GlobalSectId);

            foreach (var selected in _organisations)
            {
                if (!_globalSection.Organisations.Any(o => o.OrganisationId == selected.OrganisationId))
                {
                    _globalSection.Organisations.Add(selected);
                }
            }

            List<int> _orgToRemove = new List<int>(); 
            foreach (var existed in _globalSection.Organisations) 
            {
                if (!_organisations.Any(o => o.OrganisationId == existed.OrganisationId))
                {
                    _orgToRemove.Add(existed.OrganisationId);
                }
            }

            for (int i = 0; _orgToRemove != null && i < _orgToRemove.Count; i++)
            {
                _globalSection.Organisations.Remove(_organisationServices.GetById(_orgToRemove[i]));
            }
             _globalSection.GlobalSectionName = info.GlobalSectionName;
            _globalSection.GlobalWayNumber = info.GlobalWayNumber;

            _globalSectionSetvice.UpdateGlobalSection(_globalSection);

            return Json(new
            {
                newData = new
                {
                    emailMessage = "Редактирование прошло успешно",
                    url = Url.Action("Index", "GlobalSection")
                }
            });
        }

        [HttpPost]
        public IActionResult DeleteGlobalSection(int id)
        {

            var _globalSection = _globalSectionSetvice.GetById(id);
            _globalSectionSetvice.DeleteGlobalSection(_globalSection);

            return Json(new
            {
                url = Url.Action("Index", "GlobalSection"),
                emailMessage = "Удаление прошло успешно!"

            });
        }

        [HttpPost]
        public IActionResult CreateGlobalSection(GlobalSectionInfo info)
        {
            var _orgList = new List<Organisation>();

            if (info.SelectedOrganisation != null)
            {
                foreach (var item in info.SelectedOrganisation)
                {
                    _orgList.Add(_organisationServices.GetById(item));
                }
            }
            GlobalSection globalSection = new GlobalSection
            {
                GlobalSectId = info.GlobalSectId,
                GlobalSectionName = info.GlobalSectionName,
                GlobalWayNumber = info.GlobalWayNumber,
                Organisations = _orgList
            };
            _globalSectionSetvice.CreateGlobalSection(globalSection);

            return Json(new
            {
                newData = new
                {
                    emailMessage = "Регистрация прошла успешно!",
                    url = Url.Action("Index", "GlobalSection")
                }
            });
        }
    }
}
