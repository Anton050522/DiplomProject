using Microsoft.AspNetCore.Mvc.Rendering;
using RailDBProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebTestOfVMC.Models
{
    public class DefectInfo
    {
        public int DefectId { get; set; }
        [Display(Name = "Дата обнаружения: ")]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public DateTime DateOfDetection { get; set; }


        [Display(Name = "Километр")]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public int Kilometer { get; set; }


        [Display(Name = "Пикет")]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public int Pkt { get; set; }


        [Display(Name = "Нить: ")]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public WaySide WaySide { get; set; }


        [Display(Name = "Звено: ")]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public int Path { get; set; }


        [Display(Name = "Производитель: ")]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public Manufacture Manufacture { get; set; }


        [Display(Name = "Год прокатки: ")]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public string ManufactureYear { get; set; }


        [Display(Name = "Глубина дефекта: ")]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public double DefectDepth { get; set; }


        [Display(Name = "Протяженность дефекта: ")]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public double DefectLenght { get; set; }


        [Display(Name = "Код дефекта: ")]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public DefectCodes DefectCode { get; set; }


        [Display(Name = "Код дефекта: ")]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public string DefectCodeName { get; set; }


        public bool IsDeleted { get; set; }

        [Display(Name = "Перегон")]
        public LocalSection LocalSection { get; set; }


        public List<Defect> DefectCollection { get; set; }
        public List<GlobalSection> GlobalSectionCollection { get; set; }
        public List<LocalSection> LocalSectionCollection { get; set; }
        public List<int> SelectedDefect { get; set; }
        public List<int> SelectedGlobalSection { get; set; }
        public List<int> SelectedLocalSection { get; set; }
        public SelectList DefectSelectList { get; set; }
        public SelectList GlobalSectionSelectList { get; set; }
        public SelectList LocalSectionSelectList { get; set; }
        public MultiSelectList DefectMultiSelectList { get; set; }
        public MultiSelectList GlobalSectionMultiSelectList { get; set; }
        public MultiSelectList LocalSectionMultiSelectList { get; set; }
    }
}
