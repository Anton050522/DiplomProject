using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    [Serializable]
    public class Organisation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int OrganisationId { get; set; }
        
        [Required]
        [MaxLength(70)]
        public string OrgName { get; set; }
       

        public virtual ICollection<Organisation> Children { get; set; }
        public int? SubOrgId { get; set; }
        
        public virtual Organisation Parent { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<GlobalSection> GlobalSections { get; set; }

    }
}
