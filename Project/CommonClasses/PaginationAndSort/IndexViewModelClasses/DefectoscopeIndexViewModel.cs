using CommonClasses.PaginationAndSort.Filters;
using CommonClasses.PaginationAndSort.PageViewClass;
using CommonClasses.PaginationAndSort.SortingClasses;
using RailDBProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonClasses.PaginationAndSort.IndexViewModelClasses
{
    public class DefectoscopeIndexViewModel
    {
        public IEnumerable<Defectoscope> Defectoscopes { get; set; }
        public PageView PageView { get; set; }
        public OrganisationFilter OrganisationFilter { get; set; }
       public DefectoscopeSortViewModel DefectoscopeSortViewModel { get; set; }
    }
}
