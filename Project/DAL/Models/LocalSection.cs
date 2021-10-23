using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    [Serializable]
    public class LocalSection
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int LocalSectoionId { get; set; }
        [Required]
        [MaxLength(50)]
        public string LocaSectionlName { get; set; }
        [Required]
        public int LocalWayNumber { get; set; }

        public virtual GlobalSection GlobalSection { get; set; }
        public virtual ICollection<Coordinate> Coordinates { get; set; }
    }
}
