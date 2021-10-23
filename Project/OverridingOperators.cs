sing System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using WebTestOfVMC.Models;

namespace Project.Overriding
{
    public static class OverridingOperators
    {
        public static override implicit operator User(UserInfo _userinfo)
        {
            var _user = new User();
            _user.FirstName = _userinfo.FirstName;
            return _user; 
        }
    }
}

