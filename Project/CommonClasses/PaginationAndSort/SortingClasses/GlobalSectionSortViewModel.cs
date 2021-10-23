using System;
using System.Collections.Generic;
using System.Text;

namespace CommonClasses.PaginationAndSort.SortingClasses
{
    public class GlobalSectionSortViewModel
    {
        public GlobalSectionSortState GlobalSectionNameSort { get; private set; }
        public GlobalSectionSortState GlobalWaySort { get; private set; }
        public GlobalSectionSortState Current { get; private set; }

        public GlobalSectionSortViewModel(GlobalSectionSortState sortOrder)
        {
            GlobalSectionNameSort = sortOrder == GlobalSectionSortState.GlobalSectionNameAsc ? GlobalSectionSortState.GlobalSectionNameDesc : GlobalSectionSortState.GlobalSectionNameAsc;

            GlobalWaySort = sortOrder == GlobalSectionSortState.GlobalWayAsc ? GlobalSectionSortState.GlobalWayDesc : GlobalSectionSortState.GlobalWayAsc;

            Current = sortOrder;
        }
    }
}
