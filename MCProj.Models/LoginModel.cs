using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MCPro.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Email")]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string Pwd { get; set; }
    }
}