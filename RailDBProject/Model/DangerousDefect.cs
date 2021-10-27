using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailDBProject.Model
{
    public class DangerousDefect
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int DangerousDefectId { get; set; }
        [Required]
        public int Kilometer { get; set; }
        [Required]
        public int Pkt { get; set; }
        [Required]
        public DateTime DateOfDetection { get; set; }
        [Required]
        public int Path { get; set; }
        [Required]
        public WaySide WaySide { get; set; }
        [Required]
        public Manufacture Manufacture { get; set; }
        [Required]
        public string ManufactureYear { get; set; }
        [Required]
        public double DangerousDefectDepth { get; set; }
        [Required]
        public double DangerousDefectLenght { get; set; }

        [Required]
        public double DangerousDefectAverageDepth { get; set; }
        [Required]
        public double DangerousDefectAverageLenght { get; set; }
        [Required]
        public DangerousDefectCodes DangerousDefectCode { get; set; }
        public string DangerousDefectCodeName { get; set; }
        public bool IsDeleted { get; set; }

        public virtual LocalSection LocalSection { get; set; }
    }
}