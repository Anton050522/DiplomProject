using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailDBProject.Model
{
    [Serializable]
    public class GlobalSection
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int GlobalSectId { get; set; }
        [Required]
        [MaxLength(50)]
        public string GlobalSectionName { get; set; }
        [Required]
        public int GlobalWayNumber { get; set; }
        public int OrganisationId { get; set; }

        public virtual ICollection<Organisation> Organisations { get; set; }
        public virtual ICollection<LocalSection> LocalSections { get; set; }
    }
}