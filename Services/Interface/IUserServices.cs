using RailDBProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Services.Interface
{
    public interface IUserServices
    {
        public User UpdateUser(User user);
        public List<User> GetUsers();
        public IQueryable<User> GetQuarable();
        public User GetById(int id);
        public void DeleteUser(User user);
        public void CreateUser(User user);
        public List<Organisation> GetOrganisationList();
        public bool CheckByEmail(string email);
        public User GetByEmail(string email);

    }
}
