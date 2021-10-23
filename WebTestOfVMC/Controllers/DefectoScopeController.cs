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
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTestOfVMC.Models;

namespace WebTestOfVMC.Controllers
{
    public class DefectoScopeController : Controller
    {
        private readonly IOperatorServices _operatorService;
        private readonly IOrganisationServices _organisationServices;
        private readonly IDefectoscopeServices _defectoscopeServices;
        private readonly IUserServices _userServices;

        public DefectoScopeController(IOperatorServices _operatorService, IOrganisationServices _organisationServices, IDefectoscopeServices _defectoscopeServices, IUserServices _userServices)
        {
            this._operatorService = _operatorService;
            this._organisationServices = _organisationServices;
            this._defectoscopeServices = _defectoscopeServices;
            this._userServices = _userServices;
        }

        [HttpPost]
        public IActionResult UpdateDefectoscope(DefectoScopeInfo info)
        {
            var organisation = _organisationServices.GetById(info.Organisation.OrganisationId);
            var _operators = new List<Operator>();

            var _defectoscope = _defectoscopeServices.GetById(info.DefectoScopeId);
            _defectoscope.DefectoScopeType = info.DefectoScopeType;
            _defectoscope.DefectoScopeName = info.DefectoScopeType.GetEnumDescription();
            _defectoscope.SerialNumber = info.SerialNumber;
            _defectoscope.Organisation = organisation;
            _defectoscope.LastMaintenansProcedure = info.LastMaintenansProcedure;

            if (info.SelectedOperator != null)
            {
                _defectoscope.Operators = null;
                foreach (var item in info.SelectedOperator)
                {
                    _operators.Add(_operatorService.GetById(item));
                }
                _defectoscope.Operators = _operators;
            }

            _defectoscopeServices.UpdateDefectoscope(_defectoscope);

            return Json(new
            {
                url = Url.Action("Index", "Defectoscope"),
                emailMessage = "Редактирование прошло успешно!"
            });
        }

        [HttpGet]
        public IActionResult GetOne(int id)
        {
            var _defectoscope = _defectoscopeServices.GetById(id);
            var operator_ = _operatorService.GetOperatorList();

            var model = new DefectoScopeInfo
            {
                DefectoScopeId = _defectoscope.DefectoScopeId,
                DefectoScopeType = _defectoscope.DefectoScopeType,
                DefectoScopeName = _defectoscope.DefectoScopeType.GetEnumDescription(),
                SerialNumber = _defectoscope.SerialNumber,
                LastMaintenansProcedure = _defectoscope.LastMaintenansProcedure,
                Operators = _defectoscope.Operators,
                OrganisationCollection = _organisationServices.GetOrganisationList(),
                OrganisationSelectList = _organisationServices.GetOrganisationList().GetOrganisationSelectList(),
                OperatorCollection = _operatorService.GetOperatorList(),
                OperatorSelectList = _operatorService.GetOperatorList().GetOperatorSelectList(),
                OperatorMultiSelectList = new MultiSelectList(operator_, "OperatorId", "LastName")
            };
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult DeleteDefectoscope(int id)
        {

            var _defectoscope = _defectoscopeServices.GetById(id);

            List<Operator> operators = _operatorService.GetAllOpp().Where(o => o.Defectoscope.DefectoScopeId == id).ToList();
            foreach (var item in operators)
            {
                item.Defectoscope = null;
            }

            _defectoscopeServices.DeleteDefectoscope(_defectoscope);

            return Json(new
            {
                url = Url.Action("Index", "Defectoscope"),
                emailMessage = "Удаление прошло успешно!"

            });
        }

        [HttpPost]
        public IActionResult CreateDefectoscope(DefectoScopeInfo info)
        {
            var organisation = _organisationServices.GetById(info.Organisation.OrganisationId);
            var _operators = new List<Operator>();

            Defectoscope defectoscope = new Defectoscope
            {
                DefectoScopeType = info.DefectoScopeType,
                DefectoScopeName = info.DefectoScopeType.GetEnumDescription(),
                SerialNumber = info.SerialNumber,
                LastMaintenansProcedure = info.LastMaintenansProcedure,
                Organisation = organisation
            };

            if (info.SelectedOperator != null)
            {
                foreach (var item in info.SelectedOperator)
                {
                    _operators.Add(_operatorService.GetById(item));
                }
                defectoscope.Operators = _operators;
            }

            _defectoscopeServices.CreateDefectoscope(defectoscope);

            return Json(new
            {
                emailMessage = "Добавление прошло успешно!",
                url = Url.Action("Index", "Defectoscope")
            });
        }

        public async Task<IActionResult> Index(int? company, string name, int page = 1, DefectoscopeSortState sortOrder = DefectoscopeSortState.DefectoScopeNameAsc)
        {
            int pageSize = 10;

            var userEmail = HttpContext.User.Identity.Name;
            var user = _userServices.GetByEmail(userEmail);
            IQueryable<Defectoscope> defectoscopes = _defectoscopeServices.GetQuarable();
            
            if (user.Organisation.OrganisationRole == OrganisationRole.PCH)
            {
                defectoscopes = _defectoscopeServices.GetQuarable().Where(o => o.Organisation.Users.Any(u => u.Email == userEmail));
            }
            else if (user.Organisation.OrganisationRole == OrganisationRole.NOD)
            {
                defectoscopes = _defectoscopeServices.GetQuarable().Where(o => o.Organisation.Parent == user.Organisation);
            }
            else
            {
                defectoscopes = _defectoscopeServices.GetQuarable();
            }

            if (company != null && company != 0)
            {
                defectoscopes = defectoscopes.Where(p => p.Organisation.OrganisationId == company);
            }

            switch (sortOrder)
            {
                case DefectoscopeSortState.DefectoScopeTypeDesc:
                    defectoscopes = defectoscopes.OrderByDescending(s => s.DefectoScopeType);
                    break;
                case DefectoscopeSortState.DefectoScopeTypeAsc:
                    defectoscopes = defectoscopes.OrderBy(s => s.DefectoScopeType);
                    break;


                case DefectoscopeSortState.SerialNumberDesc:
                    defectoscopes = defectoscopes.OrderByDescending(s => s.SerialNumber);
                    break;
                case DefectoscopeSortState.SerialNumberAsc:
                    defectoscopes = defectoscopes.OrderBy(s => s.SerialNumber);
                    break;


                case DefectoscopeSortState.OrganisationDesc:
                    defectoscopes = defectoscopes.OrderByDescending(s => s.Organisation);
                    break;
                case DefectoscopeSortState.OrganisationAsc:
                    defectoscopes = defectoscopes.OrderBy(s => s.Organisation);
                    break;


                case DefectoscopeSortState.LastMaintenansProcedureDesc:
                    defectoscopes = defectoscopes.OrderByDescending(s => s.LastMaintenansProcedure);
                    break;
                case DefectoscopeSortState.LastMaintenansProcedureAsc:
                    defectoscopes = defectoscopes.OrderBy(s => s.LastMaintenansProcedure);
                    break;


                case DefectoscopeSortState.OperatorsDesc:
                    defectoscopes = defectoscopes.OrderByDescending(s => s.Operators);
                    break;
                case DefectoscopeSortState.OperatorsAsc:
                    defectoscopes = defectoscopes.OrderBy(s => s.Operators);
                    break;
            }

            var count = await defectoscopes.CountAsync();
            var items = await defectoscopes.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            DefectoscopeIndexViewModel viewModel = new DefectoscopeIndexViewModel
            {
                PageView = new PageView(count, page, pageSize),
                DefectoscopeSortViewModel = new DefectoscopeSortViewModel(sortOrder),
                OrganisationFilter = new OrganisationFilter(_organisationServices.GetOrganisationList(), company, name),
                Defectoscopes = items
            };
            return View(viewModel);
        }
    }
}
