using CommonClasses.PaginationAndSort.Filters;
using CommonClasses.PaginationAndSort.PageViewClass;
using CommonClasses.PaginationAndSort.SortingClasses;
using RailDBProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonClasses.PaginationAndSort.IndexViewModelClasses
{
    public class GlobalSectionIndexViewModel
    {
        public IEnumerable<GlobalSection> GlobalSections { get; set; }
        public PageView PageView { get; set; }
        public OrganisationFilter OrganisationFilter { get; set; }
        public GlobalSectionSortViewModel GlobalSectionSortViewModel { get; set; }
    }
}
