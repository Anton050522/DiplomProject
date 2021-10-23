using Microsoft.AspNetCore.Mvc.Rendering;
using RailDBProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTestOfVMC.Models
{
    public class DefectoScopeInfo
    {
        public int DefectoScopeId { get; set; }
        [Required]
        public int SerialNumber { get; set; }
        [Required]
        public DefectoScopeType DefectoScopeType { get; set; }
        public string DefectoScopeName { get; set; }
        public DateTime LastMaintenansProcedure { get; set; }
        public virtual Organisation Organisation { get; set; }
        public virtual ICollection<Operator> Operators { get; set; }



        public List<Organisation> OrganisationCollection { get; set; }
        public List<Defectoscope> DefectoscopeCollection { get; set; }
        public List<Operator> OperatorCollection { get; set; }
        public SelectList DefectoscopeSelectList { get; set; }
        public SelectList OrganisationSelectList { get; set; }
        public SelectList OperatorSelectList { get; set; }
        public List<int> SelectedOperator { get; set; }
        public MultiSelectList OperatorMultiSelectList { get; set; }
    }
}
