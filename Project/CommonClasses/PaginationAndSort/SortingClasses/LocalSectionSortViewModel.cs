using System;
using System.Collections.Generic;
using System.Text;

namespace CommonClasses.PaginationAndSort.SortingClasses
{
    public class LocalSectionSortViewModel
    {
        public LocalSectionSortState LocalSectionNameSort { get; private set; }
        public LocalSectionSortState LocalWaySort { get; private set; }
        public LocalSectionSortState Current { get; private set; }

        public LocalSectionSortViewModel(LocalSectionSortState sortOrder)
        {
            LocalSectionNameSort = sortOrder == LocalSectionSortState.LocalSectionNameAsc ? LocalSectionSortState.LocalSectionNameDesc : LocalSectionSortState.LocalSectionNameAsc;

            LocalWaySort = sortOrder == LocalSectionSortState.LocalWayAsc ? LocalSectionSortState.LocalWayDesc : LocalSectionSortState.LocalWayAsc;

            Current = sortOrder;
        }
    }
}
