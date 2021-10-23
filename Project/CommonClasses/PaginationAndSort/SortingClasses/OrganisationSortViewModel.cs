using System;
using System.Collections.Generic;
using System.Text;

namespace CommonClasses.PaginationAndSort.SortingClasses
{
    public class OrganisationSortViewModel
    {
        public OrganisationSortState OrganisationSort { get; private set; }
        public OrganisationSortState Current { get; private set; }

        public OrganisationSortViewModel(OrganisationSortState sortOrder)
        {
            OrganisationSort = sortOrder == OrganisationSortState.OrganisationAsc ? OrganisationSortState.OrganisationDesc : OrganisationSortState.OrganisationAsc;

            Current = sortOrder;
        }
    }
}
