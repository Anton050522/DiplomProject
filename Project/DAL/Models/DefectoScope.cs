using Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Project.DAL.Models
{
    [Serializable]
    public class Defectoscope
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int DefectoScopeId { get; set; }
        [Required]
        public int SerialNumber { get; set; }
        [Required]
        public DefectoScopeType DefectoScopeType { get; set; }

        public int OrganisationId { get; set; } //???
        public int? SubOrgId { get; set; } //???
        public virtual Organisation Organisation { get; set; }
        public virtual ICollection<Operator> Operators { get; set; }
    }
}
