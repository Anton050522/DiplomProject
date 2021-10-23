using Microsoft.AspNetCore.Mvc.Rendering;
using RailDBProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonClasses.PaginationAndSort.Filters
{
    public class DefectFilter
    {
        public DefectFilter(List<Defect> defects, int? defect, string defectName)
        {
            defects.Insert(0, new Defect { DefectCodeName = "Все", DefectId = 0 });
            Defects = new SelectList(defects, "DefectId", "DefectCodeName", defect);
            
            SelectedDefect = defect;

            SelectedName = defectName;
        }

        public SelectList Defects { get; private set; }
        public int? SelectedDefect { get; private set; }
        public string SelectedName { get; private set; }
    }
}
