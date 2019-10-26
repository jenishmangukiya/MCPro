using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCProj.Models
{
    public class PlaylistsModel
    {
        public int Id { get; set; }
        public Nullable<int> Uid { get; set; }
        public string P_name { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Sid_arr { get; set; }

        public UsersModel user { get; set; }
    }
}
