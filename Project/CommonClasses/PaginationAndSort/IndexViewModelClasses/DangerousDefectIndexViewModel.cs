using CommonClasses.PaginationAndSort.Filters;
using CommonClasses.PaginationAndSort.PageViewClass;
using CommonClasses.PaginationAndSort.SortingClasses;
using RailDBProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonClasses.PaginationAndSort.IndexViewModelClasses
{
    public class DangerousDefectIndexViewModel
    {
        public IEnumerable<DangerousDefect> DangerousDefects { get; set; }
        public PageView PageView { get; set; }
        public DangerousDefectFilter DangerousDefectFilter { get; set; }
        public OrganisationFilter OrganisationFilter { get; set; }// Added for multifilter
        public GlobalSectionFilter GlobalSectionFilter { get; set; }// Added for multifilter
        public LocalSectionFilter LocalSectionFilter { get; set; }// Added for multifilter
        public DangerousDefectSortViewModel DangerousDefectSortViewModel { get; set; }// Added for multifilter
    }
}