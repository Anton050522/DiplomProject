using Microsoft.AspNetCore.Mvc.Rendering;
using RailDBProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebTestOfVMC.Models
{
    public class OperatorInfo
    {
        public int OperatorId { get; set; }
        [Display(Name = "Имя: ")]
        [StringLength(50, ErrorMessage = "FirstName is to large")]
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }
        [Display(Name = "Отчество: ")]
        [StringLength(50, ErrorMessage = "MiddleName is to large")]
        [Required(ErrorMessage = "MiddleName is required")]
        public string MiddleName { get; set; }
        [Display(Name = "Фамилия: ")]
        [StringLength(50, ErrorMessage = "LastName is to large")]
        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }
        [Display(Name = "Квалификация: ")]
        public Qualification Qualification { get; set; }
        //[RegularExpression("[a-z]+")]
        [Display(Name = "Дата приема на работу: ")]
        public DateTime HireDate { get; set; }
        [Display(Name = "Дата увольнения: ")]
        public DateTime? DismissalDate { get; set; }
        [Display(Name = "Курсы повышения квалификации: ")]
        public DateTime LastQualificationTraning { get; set; }
        [Display(Name = "Организация: ")]
        public int OrganisationId { get; set; }
        public Organisation Organisation { get; set; }
        [Display(Name = "Закрепленное оборудование: ")]
        public Defectoscope Defectoscope { get; set; }

        public List<Organisation> OrganisationCollection { get; set; }
        public List<Defectoscope> DefectoscopeCollection { get; set; }
        public SelectList DefectoscopeSelectList { get; set; }
        public SelectList OrganisationSelectList { get; set; }
    }
}
