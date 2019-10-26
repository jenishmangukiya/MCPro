using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCPro.Models
{
    public class UsersModel
    {
        public int uid { get; set; }
        public string password { get; set; }
        public string f_name { get; set; }
        public string l_name { get; set; }
        public string e_mail { get; set; }
        public string role { get; set; }
    }
}
