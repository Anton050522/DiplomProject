using Microsoft.AspNetCore.Mvc.Rendering;
using RailDBProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonClasses.PaginationAndSort.Filters
{
    public class DefectoscopeFilter
    {
        public DefectoscopeFilter(List<Defectoscope> defectoscopes, int? defectoscope, string defectoscopeName)
        {
            defectoscopes.Insert(0, new Defectoscope { DefectoScopeName = "Все", DefectoScopeId = 0 });
            Defectoscopes = new SelectList(defectoscopes, "DefectoScopeId", "DefectoScopeName", defectoscope);

            SelectedDefectoscope = defectoscope;

            SelectedName = defectoscopeName;
        }

        public SelectList Defectoscopes { get; private set; }
        public int? SelectedDefectoscope { get; private set; }
        public string SelectedName { get; private set; }
    }
}
