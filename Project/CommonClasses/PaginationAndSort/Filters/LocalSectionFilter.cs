using Microsoft.AspNetCore.Mvc.Rendering;
using RailDBProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonClasses.PaginationAndSort.Filters
{
    public class LocalSectionFilter
    {
        public LocalSectionFilter(List<LocalSection> localSections, int? localSection, string localSectionName)
        {
            localSections.Insert(0, new LocalSection { LocalSectionName = "Все", LocalSectionId = 0 });
            LocalSections = new SelectList(localSections, "LocalSectionId", "LocalSectionName", localSection);
            SelectedLocalSection = localSection;
            SelectedName = localSectionName;
        }

        public SelectList LocalSections { get; private set; }
        public int? SelectedLocalSection { get; private set; }
        public string SelectedName { get; private set; }
    }
}
