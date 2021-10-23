using System;
using System.Collections.Generic;
using System.Text;

namespace CommonClasses.PaginationAndSort.SortingClasses
{
    public class OperatorSortViewModel
    {
        public OperatorSortState FirstNameSort { get; private set; }
        public OperatorSortState LastNameSort { get; private set; }
        public OperatorSortState MiddleNameSort { get; private set; }
        public OperatorSortState OrganisationSort { get; private set; }
        public OperatorSortState HireDateSort { get; private set; }
        public OperatorSortState DefectoscopeSort { get; private set; }
        public OperatorSortState QualificationSort { get; private set; }
        public OperatorSortState DismissalDateSort { get; private set; }
        public OperatorSortState LastQualificationTraningSort { get; private set; }
        public OperatorSortState Current { get; private set; }

        public OperatorSortViewModel(OperatorSortState sortOrder)
        {
            FirstNameSort = sortOrder == OperatorSortState.FirstNameAsc ? OperatorSortState.FirstNameDesc : OperatorSortState.FirstNameAsc;

            LastNameSort = sortOrder == OperatorSortState.LastNameAsc ? OperatorSortState.LastNameDesc : OperatorSortState.LastNameAsc;

            MiddleNameSort = sortOrder == OperatorSortState.MiddleNameAsc ? OperatorSortState.MiddleNameDesc : OperatorSortState.MiddleNameAsc;

            OrganisationSort = sortOrder == OperatorSortState.OrganisationAsc ? OperatorSortState.OrganisationDesc : OperatorSortState.OrganisationAsc;

            HireDateSort = sortOrder == OperatorSortState.HireDateAsc ? OperatorSortState.HireDateDesc : OperatorSortState.HireDateAsc;

            DefectoscopeSort = sortOrder == OperatorSortState.DefectoscopeAsc ? OperatorSortState.DefectoscopeDesc : OperatorSortState.DefectoscopeAsc;

            QualificationSort = sortOrder == OperatorSortState.QualificationAsc ? OperatorSortState.QualificationDesc : OperatorSortState.QualificationAsc;

            DismissalDateSort = sortOrder == OperatorSortState.DismissalDateAsc ? OperatorSortState.DismissalDateDesc : OperatorSortState.DismissalDateAsc;

            LastQualificationTraningSort = sortOrder == OperatorSortState.LastQualificationTraningAsc ? OperatorSortState.LastQualificationTraningDesc : OperatorSortState.LastQualificationTraningAsc;

            Current = sortOrder;
        }
    }
}