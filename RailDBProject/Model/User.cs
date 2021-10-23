using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace RailDBProject.Model
{
    [Serializable]
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(15)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(15)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(15)]
        public string SurName { get; set; }
        [MaxLength(30)]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string Login { get; set; }
        [Required]
        [MaxLength(15)]

        public string Password { get; set; }
        [Required]
        public UserRole UserRole { get; set; }
        public bool IsDeleted { get; set; }
        public string PhoneNumber { get; set; }

        public int OrganisationId { get; set; }
        public virtual Organisation Organisation { get; set; }
    }
}