using CommonClasses.PaginationAndSort.Filters;
using CommonClasses.PaginationAndSort.PageViewClass;
using CommonClasses.PaginationAndSort.SortingClasses;
using RailDBProject.Model;
using System.Collections.Generic;

namespace CommonClasses.PaginationAndSort.IndexViewModelClasses
{
    public class OperatorIndexViewModel
    {
        public IEnumerable<Operator> Operators { get; set; }
        public PageView PageView { get; set; }
        public OrganisationFilter OrganisationFilter { get; set; }
        public OperatorSortViewModel OperatorSortViewModel { get; set; }
    }
}
