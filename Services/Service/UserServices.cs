using RailDBProject.Model;
using RailDBProject.Repository;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Services.Service
{
    public class UserServices : IUserServices
    {
        private readonly IUnitOfWork _uow;
        public UserServices(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public User GetById(int id)
        {
            return _uow.Users.Read(id);
        }

        public List<User> GetUsers()
        {
            return _uow.Users
                .ReadAll()
                .ToList();
        }

        public User UpdateUser(User _user)
        {
            _uow.Users.Update(_user);
            _uow.SaveChanges();
            return _user; 
        }
        public void DeleteUser(User _user)
        {
            _uow.Users.Delete(_user);           
            _uow.SaveChanges();
        }

        public void CreateUser(User _user)
        {
            _uow.Users.Create(_user);
            _uow.SaveChanges();
        }

        public List<Organisation> GetOrganisationList()
        {
            return _uow.Organisations.ReadAll().ToList();
        }

        public IQueryable<User> GetQuarable()
        {
            return _uow.Users.ReadAll();
        }

        public bool CheckByEmail(string email)
        {
            var users = _uow.Users.ReadAll();
            foreach (var u in users)
            {
                if (u.Email == email)
                {
                    return true;
                }
            }
            return false;
        }

        public User GetByEmail(string email)
        {
            var users = _uow.Users.ReadAll();
            var user = users.FirstOrDefault(u => u.Email == email);
            return user;
        }
    }
}
