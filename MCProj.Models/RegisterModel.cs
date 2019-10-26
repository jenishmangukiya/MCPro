using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MCPro.Models
{
    public class RegisterModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="First Name")]
        [MaxLength(30)]
        public string Fname { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(30)]
        public string Lname { get; set; }

        [Required]
        [Display(Name = "Email Name")]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string Pwd { get; set; }
    }
}