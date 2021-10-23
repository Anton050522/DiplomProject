using Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Project.DAL.Models
{
    [Serializable]
    public class Operator
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int OperatorId { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string MiddleName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public Qualification Qualification { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        [Required]
        public DateTime LastQualificationTraning { get; set; }
               

        public int OrganisationId { get; set; } //???
        public int? SubOrgId { get; set; } //???
        public virtual Organisation Organisation { get; set; }
        public virtual Defectoscope Defectoscope { get; set; }
    }
}
