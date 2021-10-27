using Microsoft.AspNetCore.Mvc.Rendering;
using RailDBProject.Model;
using System.Collections.Generic;

namespace CommonClasses.PaginationAndSort.Filters
{
    public class DangerousDefectFilter
    {
        public DangerousDefectFilter(List<DangerousDefect> defects, int? defect, string defectName)
        {
            defects.Insert(0, new DangerousDefect { DangerousDefectCodeName = "Все", DangerousDefectId = 0 });
            DangerousDefects = new SelectList(defects, "DangerousDefectId", "DangerousDefectCodeName", defect);

            SelectedDangerousDefect = defect;

            SelectedName = defectName;
        }

        public SelectList DangerousDefects { get; private set; }
        public int? SelectedDangerousDefect { get; private set; }
        public string SelectedName { get; private set; }
    }
}