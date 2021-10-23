using Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Project.DAL.Models
{
    [Serializable]
    public class DefectAudit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        public DateTime DateOfDetection { get; set; }
        public int Path { get; set; }
        public WaySide WaySide { get; set; }
        public Manufacture Manufacture { get; set; }
        public string ManufactureYear { get; set; }
        public double DefectDepth { get; set; }
        public double DefectLenght { get; set; }
        public DefectCodes DefectCode { get; set; }
    }
}
