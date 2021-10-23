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
    public class OrganisationController : Controller
    {
        private readonly IOrganisationServices _organisationServices;
        public OrganisationController(IOrganisationServices _organisationServices)
        {
            this._organisationServices = _organisationServices;
        }

        [HttpGet]
        public IActionResult GetOne(int id)
        {
            Organisation _organisation = _organisationServices.GetById(id);

            OrganisationInfo organisation = new OrganisationInfo();

                organisation.OrganisationId = _organisation.OrganisationId;
                organisation.OrgName = _organisation.OrgName;

                if (_organisation.Parent != null)
                {
                    organisation.Parent = _organisation.Parent;
                }

                if (_organisation.Children != null)
                {
                    organisation.Children = _organisation.Children;
                }

                organisation.GlobalSections = _organisation.GlobalSections;
                organisation.OrganisationRole = _organisation.OrganisationRole;
                organisation.Users = _organisation.Users;
                organisation.IsDeleted = _organisation.IsDeleted;
                organisation.SelectList = _organisationServices.GetOrganisationList().GetOrganisationSelectList();
                organisation.OrganisationCollection = _organisationServices.GetOrganisationList();
                organisation.MultiSelectList = new MultiSelectList(organisation.OrganisationCollection, "OrganisationId", "OrgName");

            return PartialView(organisation);
        }

        [HttpPost]
        public IActionResult UpdateOrganisation(OrganisationInfo info)
        {
            var _organisation = _organisationServices.GetById(info.OrganisationId);
            var _childList = new List<Organisation>();

            if (info.SelectedOrganisations != null)
            {
                foreach (var item in info.SelectedOrganisations)
                {
                    _childList.Add(_organisationServices.GetById(item));
                }
                _organisation.Children = _childList;
            }
            else
            {
                _organisation.Children = null;
            }
            _organisation.OrganisationRole = info.OrganisationRole;
            _organisation.OrgName = info.OrgName;
            _organisation.Parent = _organisationServices.GetById(info.Parent.OrganisationId);
            _organisation.Users = info.Users;
            _organisation.IsDeleted = info.IsDeleted;
            _organisationServices.UpdateOrganisation(_organisation);

            return Json(new
            {
                newData = new
                {
                    emailMessage = "Редактирование прошло успешно",
                    url = Url.Action("Index", "Organisation")
                }
            });
        }

        [HttpPost]
        public IActionResult DeleteOrganisation(int id)
        {
            var _organisation = _organisationServices.GetById(id);

            if (_organisation.Children != null)
            {
                foreach (var item in _organisation.Children)
                {
                    item.Parent = null;
                }
                _organisation.Children = null;
            }

            _organisationServices.DeleteOrganisation(_organisation);
            return Json(new
            {
                emailMessage = "Удаление прошло успешно!",
                url = Url.Action("Index", "Organisation")
            });
        }

        public IActionResult CreateOrganisation(OrganisationInfo info)
        {
            var _childList = new List<Organisation>();

            if (info.SelectedOrganisations != null)
            {
                foreach (var item in info.SelectedOrganisations)
                {
                    _childList.Add(_organisationServices.GetById(item));
                }
            }

            if (info.Parent != null)
            {
                Organisation _organisation = new Organisation()
                {
                    OrgName = info.OrgName,
                    OrganisationRole = info.OrganisationRole,
                    Parent = _organisationServices.GetById(info.Parent.OrganisationId),
                    Children = _childList,
                    Users = info.Users,
                    IsDeleted = info.IsDeleted,
                };

                _organisationServices.CreateOrganisation(_organisation);
            }
            else
            {
                Organisation _organisation = new Organisation()
                {
                    OrgName = info.OrgName,
                    OrganisationRole = info.OrganisationRole,
                    Children = _childList,
                    Users = info.Users,
                    IsDeleted = info.IsDeleted,
                };

                _organisationServices.CreateOrganisation(_organisation);
            }

            return Json(new
            {
                url = Url.Action("Index", "Organisation"),
                emailMessage = "Добавление прошло успешно!"
            });
        }

        public IActionResult GetNodes()
        {
            var organisations = _organisationServices.GetOrganisationList();

            var model = new List<OrganisationInfo>();

            model = organisations.Select(u => new OrganisationInfo
            {
                OrganisationId = u.OrganisationId,
                OrgName = u.OrgName,
                Children = u.Children,
                Parent = u.Parent,
                Users = u.Users,
                IsDeleted = u.IsDeleted
            }).ToList();
            return View(model);
        }

        public async Task<IActionResult> Index(int? company, string name, int page = 1, OrganisationSortState sortOrder = OrganisationSortState.OrganisationAsc)
        {
            int pageSize = 12;

            IQueryable<Organisation> organisations = _organisationServices.GetQuarable();


            if (company != null && company != 0)
            {
                organisations = organisations.Where(p => p.OrganisationId == company);
            }

            switch (sortOrder)
            {
                case OrganisationSortState.OrganisationDesc:
                    organisations = organisations.OrderByDescending(s => s.OrgName);
                    break;
                case OrganisationSortState.OrganisationAsc:
                    organisations = organisations.OrderBy(s => s.OrgName);
                    break;
            }

            var count = await organisations.CountAsync();
            var items = await organisations.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            OrganisationIndexViewModel viewModel = new OrganisationIndexViewModel
            {
                PageView = new PageView(count, page, pageSize),
                OrganisationSortViewModel = new OrganisationSortViewModel(sortOrder),
                OrganisationFilter = new OrganisationFilter(_organisationServices.GetOrganisationList(), company, name),
                Organisations = items
            };
            return View(viewModel);
        }
    }
}


