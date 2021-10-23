using Microsoft.AspNetCore.Mvc.Rendering;
using RailDBProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonClasses.PaginationAndSort.Filters
{
    public class OrganisationFilter
    {
        public OrganisationFilter(List<Organisation> organisations, int? organisation, string orgName)
        {
            organisations.Insert(0, new Organisation { OrgName = "Все", OrganisationId = 0 });
            Organisations = new SelectList(organisations, "OrganisationId", "OrgName", organisation);
            SelectedOrganisation = organisation;
            SelectedName = orgName;
        }

        public SelectList Organisations { get; private set; }
        public int? SelectedOrganisation { get; private set; }
        public string SelectedName { get; private set; }
    }
}
