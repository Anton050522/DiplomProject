using System;
using System.Collections.Generic;
using System.Text;

namespace CommonClasses.PaginationAndSort.SortingClasses
{
    public class DangerousDefectSortViewModel
    {
        public DangerousDefectSortState LocalSectionNameSort { get; private set; }
        public DangerousDefectSortState LocalSectionWaySort { get; private set; }
        public DangerousDefectSortState KilometerSort { get; private set; }
        public DangerousDefectSortState PktSort { get; private set; }
        public DangerousDefectSortState DateOfDetectionSort { get; private set; }
        public DangerousDefectSortState PathSort { get; private set; }
        public DangerousDefectSortState WaySideSort { get; private set; }
        public DangerousDefectSortState ManufactureSort { get; private set; }
        public DangerousDefectSortState ManufactureYearSort { get; private set; }
        public DangerousDefectSortState DangerousDefectDepthSort { get; private set; }
        public DangerousDefectSortState DangerousDefectLenghtSort { get; private set; }
        public DangerousDefectSortState DangerousDefectAverageDepthSort { get; private set; }
        public DangerousDefectSortState DangerousDefectAverageLenghtSort { get; private set; }
        public DangerousDefectSortState DangerousDefectCodeSort { get; private set; }
        public DangerousDefectSortState Current { get; private set; }

        public DangerousDefectSortViewModel(DangerousDefectSortState sortOrder)
        {
            LocalSectionNameSort = sortOrder == DangerousDefectSortState.LocalSectionNameAsc ? DangerousDefectSortState.LocalSectionNameDesc : DangerousDefectSortState.LocalSectionNameAsc;

            LocalSectionWaySort = sortOrder == DangerousDefectSortState.LocalSectionWayAsc ? DangerousDefectSortState.LocalSectionWayDesc : DangerousDefectSortState.LocalSectionWayAsc;

            KilometerSort = sortOrder == DangerousDefectSortState.KilometerAsc ? DangerousDefectSortState.KilometerDesc : DangerousDefectSortState.KilometerAsc;

            PktSort = sortOrder == DangerousDefectSortState.PktAsc ? DangerousDefectSortState.PktDesc : DangerousDefectSortState.PktAsc;

            DateOfDetectionSort = sortOrder == DangerousDefectSortState.DateOfDetectionAsc ? DangerousDefectSortState.DateOfDetectionDesc : DangerousDefectSortState.DateOfDetectionAsc;

            PathSort = sortOrder == DangerousDefectSortState.PathAsc ? DangerousDefectSortState.PathDesc : DangerousDefectSortState.PathAsc;

            WaySideSort = sortOrder == DangerousDefectSortState.WaySideAsc ? DangerousDefectSortState.WaySideDesc : DangerousDefectSortState.WaySideAsc;

            ManufactureSort = sortOrder == DangerousDefectSortState.ManufactureAsc ? DangerousDefectSortState.ManufactureDesc : DangerousDefectSortState.ManufactureAsc;

            ManufactureYearSort = sortOrder == DangerousDefectSortState.ManufactureYearAsc ? DangerousDefectSortState.ManufactureYearDesc : DangerousDefectSortState.ManufactureYearAsc;

            DangerousDefectDepthSort = sortOrder == DangerousDefectSortState.DangerousDefectDepthAsc ? DangerousDefectSortState.DangerousDefectDepthDesc : DangerousDefectSortState.DangerousDefectDepthAsc;

            DangerousDefectLenghtSort = sortOrder == DangerousDefectSortState.DangerousDefectLenghtAsc ? DangerousDefectSortState.DangerousDefectLenghtDesc : DangerousDefectSortState.DangerousDefectLenghtAsc;

            DangerousDefectAverageDepthSort = sortOrder == DangerousDefectSortState.DangerousDefectAverageDepthAsc ? DangerousDefectSortState.DangerousDefectAverageDepthDesc : DangerousDefectSortState.DangerousDefectAverageDepthAsc;

            DangerousDefectAverageLenghtSort = sortOrder == DangerousDefectSortState.DangerousDefectAverageLenghtAsc ? DangerousDefectSortState.DangerousDefectAverageLenghtDesc : DangerousDefectSortState.DangerousDefectAverageLenghtAsc;

            DangerousDefectCodeSort = sortOrder == DangerousDefectSortState.DangerousDefectCodeAsc ? DangerousDefectSortState.DangerousDefectCodeDesc : DangerousDefectSortState.DangerousDefectCodeAsc;

            Current = sortOrder;
        }
    }
}