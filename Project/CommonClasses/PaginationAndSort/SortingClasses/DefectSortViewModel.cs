using System;
using System.Collections.Generic;
using System.Text;

namespace CommonClasses.PaginationAndSort.SortingClasses
{
    public class DefectSortViewModel
    {
        public DefectSortState LocalSectionNameSort { get; private set; }
        public DefectSortState LocalSectionWaySort { get; private set; }
        public DefectSortState KilometerSort { get; private set; }
        public DefectSortState PktSort { get; private set; }
        public DefectSortState DateOfDetectionSort { get; private set; }
        public DefectSortState PathSort { get; private set; }
        public DefectSortState WaySideSort { get; private set; }
        public DefectSortState ManufactureSort{ get; private set; }
        public DefectSortState ManufactureYearSort { get; private set; }
        public DefectSortState DefectDepthSort { get; private set; }
        public DefectSortState DefectLenghtSort { get; private set; }
        public DefectSortState DefectCodeSort { get; private set; }
        public DefectSortState Current { get; private set; }

        public DefectSortViewModel(DefectSortState sortOrder)
        {
            LocalSectionNameSort = sortOrder == DefectSortState.LocalSectionNameAsc ? DefectSortState.LocalSectionNameDesc : DefectSortState.LocalSectionNameAsc;

            LocalSectionWaySort = sortOrder == DefectSortState.LocalSectionWayAsc ? DefectSortState.LocalSectionWayDesc : DefectSortState.LocalSectionWayAsc;

            KilometerSort = sortOrder == DefectSortState.KilometerAsc ? DefectSortState.KilometerDesc : DefectSortState.KilometerAsc;

            PktSort = sortOrder == DefectSortState.PktAsc ? DefectSortState.PktDesc : DefectSortState.PktAsc;

            DateOfDetectionSort = sortOrder == DefectSortState.DateOfDetectionAsc ? DefectSortState.DateOfDetectionDesc : DefectSortState.DateOfDetectionAsc;

            PathSort = sortOrder == DefectSortState.PathAsc ? DefectSortState.PathDesc : DefectSortState.PathAsc;

            WaySideSort = sortOrder == DefectSortState.WaySideAsc ? DefectSortState.WaySideDesc : DefectSortState.WaySideAsc;

            ManufactureSort = sortOrder == DefectSortState.ManufactureAsc ? DefectSortState.ManufactureDesc : DefectSortState.ManufactureAsc;

            ManufactureYearSort = sortOrder == DefectSortState.ManufactureYearAsc ? DefectSortState.ManufactureYearDesc : DefectSortState.ManufactureYearAsc;

            DefectDepthSort = sortOrder == DefectSortState.DefectDepthAsc ? DefectSortState.DefectDepthDesc : DefectSortState.DefectDepthAsc;

            DefectLenghtSort = sortOrder == DefectSortState.DefectLenghtAsc ? DefectSortState.DefectLenghtDesc : DefectSortState.DefectLenghtAsc;

            DefectCodeSort = sortOrder == DefectSortState.DefectCodeAsc ? DefectSortState.DefectCodeDesc : DefectSortState.DefectCodeAsc;

            Current = sortOrder;
        }
    }
}

