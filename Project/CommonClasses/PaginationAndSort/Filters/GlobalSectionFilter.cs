using Microsoft.AspNetCore.Mvc.Rendering;
using RailDBProject.Model;
using System.Collections.Generic;

namespace CommonClasses.PaginationAndSort.Filters
{
    public class GlobalSectionFilter
    {
        public GlobalSectionFilter(List<GlobalSection> globalSections, int? globalSection, string globalSectionName)
        {
            globalSections.Insert(0, new GlobalSection { GlobalSectionName = "Все", GlobalSectId = 0 });
            GlobalSections = new SelectList(globalSections, "GlobalSectId", "GlobalSectionName", globalSection);
            SelectedGlobalSection = globalSection;
            SelectedName = globalSectionName;
        }

        public SelectList GlobalSections { get; private set; }
        public int? SelectedGlobalSection { get; private set; }
        public string SelectedName { get; private set; }
    }
}
