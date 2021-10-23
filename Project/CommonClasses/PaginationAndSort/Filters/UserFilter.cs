using Microsoft.AspNetCore.Mvc.Rendering;
using RailDBProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonClasses.PaginationAndSort.Filters
{
    public class UserFilter
    {
        public UserFilter(List<User> users, int? user, string orgName)
        {
            users.Insert(0, new User { Email = "Все", OrganisationId = 0 });
            Users = new SelectList(users, "UserId", "Email", user);
            SelectedUser = user;
            SelectedName = orgName;
        }

        public SelectList Users { get; private set; }
        public int? SelectedUser { get; private set; }
        public string SelectedName { get; private set; }
    }
}
