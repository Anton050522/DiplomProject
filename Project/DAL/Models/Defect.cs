using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Project.DAL.Models;

namespace Project.Models
{
    [Serializable]
    public class Defect
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int DefectId { get; set; }
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
        public double DefectDepth { get;  set; }
        [Required]
        public double DefectLenght { get; set; }
        [Required]
        public DefectCodes DefectCode { get; set; }
        public bool IsDeleted { get; set; }
        
        public virtual Coordinate Coordinate { get; set; }

        public static implicit operator DefectAudit(Defect entity)
        {
            DefectAudit transfer = new DefectAudit();
            transfer.DefectCode = entity.DefectCode;
            transfer.DateOfDetection = entity.DateOfDetection;
            transfer.Id = entity.DefectId.ToString();
            transfer.Path = entity.Path;
            transfer.WaySide = entity.WaySide;
            transfer.Manufacture = entity.Manufacture;
            transfer.ManufactureYear = entity.ManufactureYear;
            transfer.DefectLenght = entity.DefectLenght;
            transfer.DefectDepth = entity.DefectDepth;
            return transfer;
            //реализация архива и делита разделить или удалить одну из них.
            //Предусмотреть сериализацию состояния БД на случай коллапса
            //сделать интеграцию с файлами EXCEL
        }
    }
}
