using Microsoft.AspNetCore.Mvc.Rendering;
using RailDBProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTestOfVMC.Models
{
    public class GlobalSectionInfo
    {
        public int GlobalSectId { get; set; }
        [Display(Name = "Наименование участка")]
        public string GlobalSectionName { get; set; }
        [Display(Name = "Номер пути")]
        public int GlobalWayNumber { get; set; }
        [Display(Name = "Обслуживающие организации")]
        public virtual ICollection<Organisation> Organisations { get; set; }
        public virtual ICollection<LocalSection> LocalSections { get; set; }


        public List<Organisation> OrganisationCollection { get; set; }
        public List<int> SelectedOrganisation { get; set; }
        public SelectList SelectList { get; set; }
        public MultiSelectList MultiSelectList { get; set; }
    }
}
