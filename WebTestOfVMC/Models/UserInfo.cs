using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RailDBProject.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebTestOfVMC.Models
{
    public class UserInfo
    {
        public int UserId { get; set; }
        [Display(Name = "Фамилия: ")]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public string LastName { get; set; }
        [Display(Name = "Имя: ")]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public string FirstName { get; set; }
        [Display(Name = "Отчество: ")]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public string SurName { get; set; }
        [Display(Name = "E-mail: ")]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Display(Name = "Пароль: ")]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Группа: ")]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public UserRole UserRole { get; set; }
        public bool IsDeleted { get; set; }
        [Display(Name = "№ телефона")]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public string PhoneNumber { get; set; }
        public int OrganisationId { get; set; }
        [Display(Name = "Организация: ")]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public virtual Organisation Organisation { get; set; }
        public SelectList SelectList { get; set; }
        public List<Organisation> OrganisationCollection { get; set; }
    }
}