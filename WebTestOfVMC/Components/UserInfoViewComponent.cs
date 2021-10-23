using Common.ListExtentions;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using WebTestOfVMC.Models;

namespace WebTestOfVMC.Components
{
    public class UserInfoViewComponent : ViewComponent
    {
        private readonly IUserServices _userServices;
        public UserInfoViewComponent(IUserServices _userServices)
        {
            this._userServices = _userServices;
        }
        public IViewComponentResult Invoke()
        {
            UserInfo _info = new UserInfo();
            _info.SelectList = _userServices.GetOrganisationList().GetOrganisationSelectList();

            return View(_info);
        }
    }
}
