using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MCProj.Models
{
    public class UsersModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Pwd { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string Fname { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string Lname { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
