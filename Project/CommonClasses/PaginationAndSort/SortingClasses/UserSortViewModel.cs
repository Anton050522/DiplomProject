using System;
using System.Collections.Generic;
using System.Text;

namespace CommonClasses.PaginationAndSort.SortingClasses
{
    public class UserSortViewModel
    {
        public UserSortState FirstNameSort { get; private set; }
        public UserSortState LastNameSort { get; private set; }
        public UserSortState MiddleNameSort { get; private set; }
        public UserSortState OrganisationSort { get; private set; }
        public UserSortState UserRoleSort { get; private set; }
        public UserSortState EmailSort { get; private set; }
        public UserSortState PhoneNumberSort { get; private set; }
        public UserSortState Current { get; private set; }

        public UserSortViewModel(UserSortState sortOrder)
        {
            FirstNameSort = sortOrder == UserSortState.FirstNameAsc ? UserSortState.FirstNameDesc : UserSortState.FirstNameAsc;

            LastNameSort = sortOrder == UserSortState.LastNameAsc ? UserSortState.LastNameDesc : UserSortState.LastNameAsc;

            MiddleNameSort = sortOrder == UserSortState.MiddleNameAsc ? UserSortState.MiddleNameDesc : UserSortState.MiddleNameAsc;

            OrganisationSort = sortOrder == UserSortState.OrganisationAsc ? UserSortState.OrganisationDesc : UserSortState.OrganisationAsc;

            UserRoleSort = sortOrder == UserSortState.UserRoleAsc ? UserSortState.UserRoleDesc : UserSortState.UserRoleAsc;

            EmailSort = sortOrder == UserSortState.EmailAsc ? UserSortState.EmailDesc : UserSortState.EmailAsc;

            PhoneNumberSort = sortOrder == UserSortState.PhoneNumberAsc ? UserSortState.PhoneNumberDesc : UserSortState.PhoneNumberAsc;

            Current = sortOrder;
        }
    }
}

