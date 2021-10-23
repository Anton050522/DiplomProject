using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RailDBProject.Model
{
    [Serializable]
    public class Defect
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int DefectId { get; set; }
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
        public double DefectDepth { get; set; }
        [Required]
        public double DefectLenght { get; set; }
        [Required]
        public DefectCodes DefectCode { get; set; }
        public string DefectCodeName { get; set; }
        public bool IsDeleted { get; set; }

        //public int LocalSectionId { get; set; }
        public virtual LocalSection LocalSection { get; set; }
    }
}
