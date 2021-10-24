using ClosedXML.Excel;
using Common.ListExtentions;
using CommonClasses.PaginationAndSort.Filters;
using CommonClasses.PaginationAndSort.IndexViewModelClasses;
using CommonClasses.PaginationAndSort.PageViewClass;
using CommonClasses.PaginationAndSort.SortingClasses;
using EmailServices.Interface;
using EnumExt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.BLL.Services.IServiceIntefaces;
using RailDBProject.Model;
using Services.Interface;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebTestOfVMC.Models;

namespace WebTestOfVMC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly IOrganisationServices _organisationServices;
        private readonly IEmailService _emailService;
        public static UserIndexViewModel currentModel;
        public static User _userNew;

        public UserController(IUserServices _userServices, IOrganisationServices _organisationServices, IEmailService _emailService)
        {
            this._userServices = _userServices;
            this._organisationServices = _organisationServices;
            this._emailService = _emailService;
        }

        [HttpGet]
        public IActionResult GetOne(int id)
        {
            var _user = _userServices.GetById(id);

            var model = new UserInfo
            {
                UserId = _user.UserId,
                FirstName = _user.FirstName,
                LastName = _user.LastName,
                SurName = _user.SurName,
                PhoneNumber = _user.PhoneNumber,
                Email = _user.Email,
                Password = _user.Password,
                Organisation = _user.Organisation,
                UserRole = _user.UserRole,
                IsDeleted = _user.IsDeleted,
                OrganisationCollection = _userServices.GetOrganisationList(),
                SelectList = _userServices.GetOrganisationList().GetOrganisationSelectList()

            };
            _userNew = _user;
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult UpdateUser(UserInfo info)
        {
            var newOrg = _organisationServices.GetById(info.OrganisationId);
            var _user = _userServices.GetById(info.UserId);

            _user.FirstName = info.FirstName;
            _user.LastName = info.LastName;
            _user.SurName = info.SurName;
            _user.PhoneNumber = info.PhoneNumber;
            _user.Email = info.Email;
            _user.Password = info.Password;
            _user.Organisation = newOrg;
            _user.UserRole = info.UserRole;
            _userServices.UpdateUser(_user);

            return Json(new
            {
                newData = new
                {
                    emailMessage = "Редактирование прошло успешно",
                    url = Url.Action("Index", "User")
                }
            });
        }

        [HttpPost]
        public IActionResult DeleteUser(int id)
        {

            var _user = _userServices.GetById(id);
            _userServices.DeleteUser(_user);

            return Json(new
            {
                url = Url.Action("Index", "User"),
                emailMessage = "Удаление прошло успешно!"

            });
        }

        [HttpPost]
        public IActionResult CreateUser(UserInfo info)
        {
            User user = new User
            {
                Email = info.Email,
                FirstName = info.FirstName,
                LastName = info.LastName,
                SurName = info.SurName,
                PhoneNumber = info.PhoneNumber,
                OrganisationId = info.OrganisationId,
                IsDeleted = info.IsDeleted,
                Password = info.Password,
                UserRole = info.UserRole
            };

            if (_userServices.CheckByEmail(info.Email) == false)
            {
                _userServices.CreateUser(user);
                User administrator = _userServices.GetUsers().FirstOrDefault(u => u.UserRole.ToString() == "Administrator");
                _emailService.SendEmailAdmin(info.FirstName, info.LastName, info.SurName, administrator.Email);
                _emailService.SendEmailUser(info.FirstName, info.LastName, info.SurName, info.Email, info.Password);
                return Json(new
                {
                    newData = new
                    {
                        emailMessage = "Регистрация прошла успешно!",
                        url = Url.Action("Login", "Account"),
                        urladmin = Url.Action("Index", "User")
                    }
                });
            }
            else
            {
                return Json(new
                {
                    newData = new
                    {
                        emailMessage = "Пользователь с таким e-mail уже существует!",
                        url = Url.Action("Login", "Account")
                    }
                });
            }
        }

        public async Task<IActionResult> Index(int? company, string name, int page = 1, UserSortState sortOrder = UserSortState.FirstNameAsc)
        {
            int pageSize = 10;

            IQueryable<User> users = _userServices.GetQuarable();


            if (company != null && company != 0)
            {
                users = users.Where(p => p.OrganisationId == company);
            }

            switch (sortOrder)
            {
                case UserSortState.FirstNameDesc:
                    users = users.OrderByDescending(s => s.FirstName);
                    break;
                case UserSortState.FirstNameAsc:
                    users = users.OrderBy(s => s.FirstName);
                    break;
                case UserSortState.LastNameDesc:
                    users = users.OrderByDescending(s => s.LastName);
                    break;
                case UserSortState.LastNameAsc:
                    users = users.OrderBy(s => s.LastName);
                    break;
                case UserSortState.OrganisationDesc:
                    users = users.OrderByDescending(s => s.Organisation);
                    break;
                case UserSortState.OrganisationAsc:
                    users = users.OrderBy(s => s.Organisation);
                    break;
                case UserSortState.UserRoleDesc:
                    users = users.OrderByDescending(s => s.UserRole);
                    break;
                case UserSortState.UserRoleAsc:
                    users = users.OrderBy(s => s.UserRole);
                    break;
                case UserSortState.EmailDesc:
                    users = users.OrderByDescending(s => s.Email);
                    break;
                case UserSortState.EmailAsc:
                    users = users.OrderBy(s => s.Email);
                    break;
            }

            var count = await users.CountAsync();
            var items = await users.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            UserIndexViewModel viewModel = new UserIndexViewModel
            {
                PageView = new PageView(count, page, pageSize),
                UserSortViewModel = new UserSortViewModel(sortOrder),
                OrganisationFilter = new OrganisationFilter(_userServices.GetOrganisationList(), company, name),
                Users = items
            };

            currentModel = viewModel;

            return View(viewModel);
        }

        public async Task<IActionResult> Contacts(int? company, string name, int page = 1, UserSortState sortOrder = UserSortState.FirstNameAsc)
        {
            int pageSize = 10;

            IQueryable<User> users = _userServices.GetQuarable();


            if (company != null && company != 0)
            {
                users = users.Where(p => p.OrganisationId == company);
            }

            switch (sortOrder)
            {
                case UserSortState.FirstNameDesc:
                    users = users.OrderByDescending(s => s.FirstName);
                    break;
                case UserSortState.FirstNameAsc:
                    users = users.OrderBy(s => s.FirstName);
                    break;
                case UserSortState.LastNameDesc:
                    users = users.OrderByDescending(s => s.LastName);
                    break;
                case UserSortState.LastNameAsc:
                    users = users.OrderBy(s => s.LastName);
                    break;
                case UserSortState.OrganisationDesc:
                    users = users.OrderByDescending(s => s.Organisation);
                    break;
                case UserSortState.OrganisationAsc:
                    users = users.OrderBy(s => s.Organisation);
                    break;
                case UserSortState.UserRoleDesc:
                    users = users.OrderByDescending(s => s.UserRole);
                    break;
                case UserSortState.UserRoleAsc:
                    users = users.OrderBy(s => s.UserRole);
                    break;
                case UserSortState.EmailDesc:
                    users = users.OrderByDescending(s => s.Email);
                    break;
                case UserSortState.EmailAsc:
                    users = users.OrderBy(s => s.Email);
                    break;
            }

            var count = await users.CountAsync();
            var items = await users.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            UserIndexViewModel viewModel = new UserIndexViewModel
            {
                PageView = new PageView(count, page, pageSize),
                UserSortViewModel = new UserSortViewModel(sortOrder),
                OrganisationFilter = new OrganisationFilter(_userServices.GetOrganisationList(), company, name),
                Users = items
            };

            currentModel = viewModel;

            return View(viewModel);
        }

            public IActionResult Export(string name)
        {
            using (IXLWorkbook workbook = new XLWorkbook(XLEventTracking.Disabled)) {

                var worksheet = workbook.Worksheets.Add("Пользователи");

                worksheet.Cell(1, 1).Value = "Информация о пользователях";
                worksheet.Cell(1, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                worksheet.Cell(1, 1).Style.Fill.BackgroundColor = XLColor.Cyan;
                worksheet.Range(1, 1, 1, 7).Merge().AddToNamed("Titles");
                worksheet.Cell(2, 1).Value = "Фамилия";
                worksheet.Cell(2, 2).Value = "Имя";
                worksheet.Cell(2, 3).Value = "Отчество";
                worksheet.Cell(2, 4).Value = "Телефон";
                worksheet.Cell(2, 5).Value = "Email";
                worksheet.Cell(2, 6).Value = "Организация";
                worksheet.Cell(2, 7).Value = "Описание пользователя";
                worksheet.Range(2, 1, 2, 7).SetAutoFilter();
                worksheet.Row(1).Style.Font.Bold = true;

                for (int i = 0; i < currentModel.Users.ToList().Count; i++)
                {
                    worksheet.Cell(i + 3, 1).Value = currentModel.Users.ToList()[i].LastName;
                    worksheet.Cell(i + 3, 2).Value = currentModel.Users.ToList()[i].FirstName;
                    worksheet.Cell(i + 3, 3).Value = currentModel.Users.ToList()[i].SurName;
                    worksheet.Cell(i + 3, 4).SetValue(currentModel.Users.ToList()[i].PhoneNumber);
                    worksheet.Cell(i + 3, 5).Value = currentModel.Users.ToList()[i].Email;
                    worksheet.Cell(i + 3, 6).Value = currentModel.Users.ToList()[i].Organisation.OrgName;
                    worksheet.Cell(i + 3, 7).Value = currentModel.Users.ToList()[i].UserRole.GetEnumDescription();
                }

                using (var stream = new MemoryStream())
                {
                    worksheet.Columns().AdjustToContents();
                    worksheet.Rows().AdjustToContents();
                    workbook.SaveAs(stream);
                    stream.Flush();

                    return new FileContentResult(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        FileDownloadName = $"Пользователи по состоянию на {DateTime.UtcNow.ToShortDateString()}.xlsx"
                    };
                }
            }
        }
        [HttpGet]
        public IActionResult GetOneUser()
        {
            using IXLWorkbook workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Досье");
            worksheet.Cell(1, 1).Value = "Информация о пользователе";
            worksheet.Cell(1, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Cell(1, 1).Style.Fill.BackgroundColor = XLColor.Cyan;
            worksheet.Range(1, 1, 1, 7).Merge().AddToNamed("Titles");
            worksheet.Cell(2, 1).Value = "Фамилия";
            worksheet.Cell(2, 2).Value = "Имя";
            worksheet.Cell(2, 3).Value = "Отчество";
            worksheet.Cell(2, 4).Value = "Телефон";
            worksheet.Cell(2, 5).Value = "Email";
            worksheet.Cell(2, 6).Value = "Организация";
            worksheet.Cell(2, 7).Value = "Описание пользователя";
            worksheet.Row(1).Style.Font.Bold = true;
            worksheet.Cell(3, 1).Value = _userNew.LastName;
            worksheet.Cell(3, 2).Value = _userNew.FirstName;
            worksheet.Cell(3, 3).Value = _userNew.SurName;
            worksheet.Cell(3, 4).SetValue(_userNew.PhoneNumber);
            worksheet.Cell(3, 5).Value = _userNew.Email;
            worksheet.Cell(3, 6).Value = _userNew.Organisation.OrgName;
            worksheet.Cell(3, 7).Value = _userNew.UserRole.GetEnumDescription();

            using var ms = new MemoryStream();
            worksheet.Columns().AdjustToContents();
            worksheet.Rows().AdjustToContents();
            workbook.SaveAs(ms);
            ms.Flush();
            return new FileContentResult(ms.ToArray(),
                            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                FileDownloadName = $"Досье на пользователя {_userNew.LastName + " " + _userNew.FirstName + " " + _userNew.SurName}.xlsx"
            };
        }
    }
}

