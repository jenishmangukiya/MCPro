using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCProj.Models
{
    public class UsersModel
    {
        public int Id { get; set; }
        public string Pwd { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
