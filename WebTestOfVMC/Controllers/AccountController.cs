using Common.ListExtentions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.BLL.Services.IServiceIntefaces;
using RailDBProject.Model;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WebTestOfVMC.Models;
using WebTestOfVMC.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebTestOfVMC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly IOrganisationServices _organisationServices;
        public AccountController(IUserServices _userServices, IOrganisationServices _organisationServices)
        {
            this._userServices = _userServices;
            this._organisationServices = _organisationServices;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User _user = await _userServices.GetQuarable().FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (_user != null)
                {
                    await Authenticate(_user.Email, _user.UserRole);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(string userName, Enum userRole)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, userRole.ToString())
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}