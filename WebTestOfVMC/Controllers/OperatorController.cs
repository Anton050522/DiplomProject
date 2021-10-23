using Common.ListExtentions;
using CommonClasses.PaginationAndSort.Filters;
using CommonClasses.PaginationAndSort.IndexViewModelClasses;
using CommonClasses.PaginationAndSort.PageViewClass;
using CommonClasses.PaginationAndSort.SortingClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.BLL.Services.IServiceIntefaces;
using RailDBProject.Model;
using Services.Interface;
using System.Linq;
using System.Threading.Tasks;
using WebTestOfVMC.Models;

namespace WebTestOfVMC.Controllers
{
    public class OperatorController : Controller
    {
        private readonly IOperatorServices _operatorService;
        private readonly IOrganisationServices _organisationServices;
        private readonly IUserServices _userServices;

        public OperatorController(IOperatorServices _operatorService, IOrganisationServices _organisationServices, IUserServices _userServices)
        {
            this._operatorService = _operatorService;
            this._organisationServices = _organisationServices;
            this._userServices = _userServices;
        }

        [HttpPost]
        public IActionResult UpdateOperator(OperatorInfo info)
        {
            var _operator = _operatorService.GetById(info.OperatorId);
            var organisation = _organisationServices.GetById(info.Organisation.OrganisationId);

            _operator.FirstName = info.FirstName;
            _operator.LastName = info.LastName;
            _operator.MiddleName = info.MiddleName;
            _operator.DismissalDate = info.DismissalDate;
            _operator.Qualification = info.Qualification;
            _operator.LastQualificationTraning = info.LastQualificationTraning;
            _operator.HireDate = info.HireDate;
            _operator.Organisation = organisation;
            _operatorService.UpdateOperator(_operator);

            return Json(new
            {
                url = Url.Action("Index", "Operator"),
                emailMessage = "Редактирование прошло успешно!"
            });
        }

        [HttpGet]
        public IActionResult GetOne(int id)
        {
            var _operator = _operatorService.GetById(id);

            var model = new OperatorInfo
            {
                OperatorId = _operator.OperatorId,
                Defectoscope = _operator.Defectoscope,
                HireDate = _operator.HireDate,
                DismissalDate = _operator.DismissalDate,
                LastQualificationTraning = _operator.LastQualificationTraning,
                MiddleName = _operator.MiddleName,
                Qualification = _operator.Qualification,
                FirstName = _operator.FirstName,
                LastName = _operator.LastName,
                Organisation = _operator.Organisation,
                OrganisationCollection = _organisationServices.GetOrganisationList(),
                OrganisationSelectList = _organisationServices.GetOrganisationList().GetOrganisationSelectList()
            };
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult DeleteOperator(int id)
        {

            var _operator = _operatorService.GetById(id);
            _operatorService.DeleteOperator(_operator);

            return Json(new
            {
                url = Url.Action("Index", "Operator"),
                emailMessage = "Удаление прошло успешно!"

            });
        }

        [HttpPost]
        public IActionResult CreateOperator(OperatorInfo info)
        {
            var organisation = _organisationServices.GetById(info.Organisation.OrganisationId);
            Operator @operator = new Operator
            {
               FirstName = info.FirstName,
               MiddleName = info.MiddleName,
               LastName = info.LastName,
               HireDate = info.HireDate,
               Qualification = info.Qualification,
               LastQualificationTraning = info.LastQualificationTraning,
               Organisation = organisation
            };
            _operatorService.CreateOperator(@operator);

                return Json(new
                {
                    emailMessage = "Регистрация прошла успешно!",
                    url = Url.Action("Index", "Operator")
                });
        }

        public async Task<IActionResult> Index(int? company, string name, int page = 1, OperatorSortState sortOrder = OperatorSortState.FirstNameAsc)
        {
            int pageSize = 10;

            var userEmail = HttpContext.User.Identity.Name;
            var user = _userServices.GetByEmail(userEmail);
            IQueryable<Operator> operators;

            if (user.Organisation.OrganisationRole == OrganisationRole.PCH)
            {
                operators = _operatorService.GetQuarable().Where(o => o.Organisation.Users.Any(u => u.Email == userEmail));
            }
            else if (user.Organisation.OrganisationRole == OrganisationRole.NOD)
            {
                operators = _operatorService.GetQuarable().Where(o => o.Organisation.Parent == user.Organisation);
            }
            else
            {
                operators = _operatorService.GetQuarable();
            }

            if (company != null && company != 0)
            {
                operators = operators.Where(p => p.Organisation.OrganisationId == company);
            }

            switch (sortOrder)
            {
                case OperatorSortState.FirstNameDesc:
                    operators = operators.OrderByDescending(s => s.FirstName);
                    break;
                case OperatorSortState.FirstNameAsc:
                    operators = operators.OrderBy(s => s.FirstName);
                    break;
                case OperatorSortState.LastNameDesc:
                    operators = operators.OrderByDescending(s => s.LastName);
                    break;
                case OperatorSortState.LastNameAsc:
                    operators = operators.OrderBy(s => s.LastName);
                    break;
                case OperatorSortState.OrganisationDesc:
                    operators = operators.OrderByDescending(s => s.Organisation);
                    break;
                case OperatorSortState.OrganisationAsc:
                    operators = operators.OrderBy(s => s.Organisation);
                    break;
                case OperatorSortState.QualificationDesc:
                    operators = operators.OrderByDescending(s => s.Qualification);
                    break;
                case OperatorSortState.QualificationAsc:
                    operators = operators.OrderBy(s => s.Qualification);
                    break;
                case OperatorSortState.LastQualificationTraningDesc:
                    operators = operators.OrderByDescending(s => s.LastQualificationTraning);
                    break;
                case OperatorSortState.LastQualificationTraningAsc:
                    operators = operators.OrderBy(s => s.LastQualificationTraning);
                    break;
                case OperatorSortState.DefectoscopeDesc:
                    operators = operators.OrderByDescending(s => s.Defectoscope);
                    break;
                case OperatorSortState.DefectoscopeAsc:
                    operators = operators.OrderBy(s => s.Defectoscope);
                    break;
                case OperatorSortState.HireDateDesc:
                    operators = operators.OrderByDescending(s => s.HireDate);
                    break;
                case OperatorSortState.HireDateAsc:
                    operators = operators.OrderBy(s => s.HireDate);
                    break;
                case OperatorSortState.DismissalDateDesc:
                    operators = operators.OrderByDescending(s => s.DismissalDate);
                    break;
                case OperatorSortState.DismissalDateAsc:
                    operators = operators.OrderBy(s => s.DismissalDate);
                    break;
            }

            var count = await operators.CountAsync();
            var items = await operators.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            OperatorIndexViewModel viewModel = new OperatorIndexViewModel
            {
                PageView = new PageView(count, page, pageSize),
                OperatorSortViewModel = new OperatorSortViewModel(sortOrder),
                OrganisationFilter = new OrganisationFilter(_organisationServices.GetOrganisationList(), company, name),
                Operators = items
            };
            return View(viewModel);
        }
    }
}
