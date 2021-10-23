using System;
using System.Collections.Generic;
using System.Text;

namespace CommonClasses.PaginationAndSort.SortingClasses
{
    public class DefectoscopeSortViewModel
    {
        public DefectoscopeSortState SerialNumberSort { get; private set; }
        public DefectoscopeSortState DefectoScopeTypeSort { get; private set; }
        public DefectoscopeSortState DefectoScopeNameSort { get; private set; }
        public DefectoscopeSortState LastMaintenansProcedureSort { get; private set; }
        public DefectoscopeSortState OrganisationSort { get; private set; }
        public DefectoscopeSortState OperatorsSort { get; private set; }
        public DefectoscopeSortState Current { get; private set; }


        public DefectoscopeSortViewModel(DefectoscopeSortState sortOrder)
        {
            SerialNumberSort = sortOrder == DefectoscopeSortState.SerialNumberAsc ? DefectoscopeSortState.SerialNumberDesc : DefectoscopeSortState.SerialNumberAsc;

            DefectoScopeTypeSort = sortOrder == DefectoscopeSortState.DefectoScopeTypeAsc ? DefectoscopeSortState.DefectoScopeTypeDesc : DefectoscopeSortState.DefectoScopeTypeAsc;

            DefectoScopeNameSort = sortOrder == DefectoscopeSortState.DefectoScopeNameAsc ? DefectoscopeSortState.DefectoScopeNameDesc : DefectoscopeSortState.DefectoScopeNameAsc;

            LastMaintenansProcedureSort = sortOrder == DefectoscopeSortState.LastMaintenansProcedureAsc ? DefectoscopeSortState.LastMaintenansProcedureDesc : DefectoscopeSortState.LastMaintenansProcedureAsc;

            OrganisationSort = sortOrder == DefectoscopeSortState.OrganisationAsc ? DefectoscopeSortState.OrganisationDesc : DefectoscopeSortState.OrganisationAsc;

            OperatorsSort = sortOrder == DefectoscopeSortState.OperatorsAsc ? DefectoscopeSortState.OperatorsDesc : DefectoscopeSortState.OperatorsAsc;

            Current = sortOrder;
        }
    }
}