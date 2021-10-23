using Microsoft.AspNetCore.Mvc.Rendering;
using RailDBProject.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebTestOfVMC.Models
{
    public class OrganisationInfo
    {
        public int OrganisationId { get; set; }
        [Display(Name = "Наименование организации")]
        public string OrgName { get; set; }
        public bool IsDeleted { get; set; }
        [Display(Name = "Звено")]
        public OrganisationRole OrganisationRole { get; set; }
        [Display(Name = "Вышестоящая организация")]
        public virtual Organisation Parent { get; set; }
        [Display(Name = "Нижестоящая организация")]
        public virtual ICollection<Organisation> Children { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<GlobalSection> GlobalSections { get; set; }

        public List<Organisation> OrganisationCollection { get; set; }
        public List<int> SelectedOrganisations { get; set; }
        public SelectList SelectList { get; set; }
        public MultiSelectList MultiSelectList { get; set; }
    }
}