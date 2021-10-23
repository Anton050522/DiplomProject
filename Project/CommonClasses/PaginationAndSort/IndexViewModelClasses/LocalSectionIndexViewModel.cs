using CommonClasses.PaginationAndSort.Filters;
using CommonClasses.PaginationAndSort.PageViewClass;
using CommonClasses.PaginationAndSort.SortingClasses;
using RailDBProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonClasses.PaginationAndSort.IndexViewModelClasses
{
    public class LocalSectionIndexViewModel
    {
        public IEnumerable<LocalSection> LocalSections { get; set; }
        public PageView PageView { get; set; }
        public GlobalSectionFilter GlobalSectionFilter { get; set; }
        public LocalSectionSortViewModel LocalSectionSortViewModel { get; set; }
    }
}
