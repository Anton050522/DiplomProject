using CommonClasses.PaginationAndSort.Filters;
using CommonClasses.PaginationAndSort.PageViewClass;
using CommonClasses.PaginationAndSort.SortingClasses;
using RailDBProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonClasses.PaginationAndSort.IndexViewModelClasses
{
    public class OrganisationIndexViewModel
    {
        public IEnumerable<Organisation> Organisations { get; set; }
        public PageView PageView { get; set; }
        public OrganisationFilter OrganisationFilter { get; set; }
        public OrganisationSortViewModel OrganisationSortViewModel { get; set; }
    }
}
