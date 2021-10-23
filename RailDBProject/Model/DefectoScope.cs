using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailDBProject.Model
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
        public DateTime LastMaintenansProcedure { get; set; }
        public string DefectoScopeName { get; set; }
        public virtual Organisation Organisation { get; set; }
        public virtual ICollection<Operator> Operators { get; set; }
    }
}
