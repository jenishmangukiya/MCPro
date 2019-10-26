using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCPro.Models
{
    public class PlaylistsModel
    {
        public int pid { get; set; }
        public Nullable<int> uid { get; set; }
        public string p_name { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string sid_arr { get; set; }

        public UsersModel Users { get; set; }
    }
}
