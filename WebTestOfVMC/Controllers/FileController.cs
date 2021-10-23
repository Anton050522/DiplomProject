using CommonClasses.PaginationAndSort.IndexViewModelClasses;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTestOfVMC.Models;

namespace WebTestOfVMC.Controllers
{
    public class FileController : Controller
    {
        private readonly IUserServices _userServices;
    
        public static UserIndexViewModel currentModel;

        public FileController(IUserServices _userServices)
        {
            this._userServices = _userServices;
        }
        public IActionResult GetOne(int id)
        {
            var _user = _userServices.GetById(id);

            var model = new UserInfo
            {
                UserId = _user.UserId,
                FirstName = _user.FirstName,
                LastName = _user.LastName,
                SurName = _user.SurName,
                Email = _user.Email
                

            };
            return PartialView(model);
        }
    }
}
