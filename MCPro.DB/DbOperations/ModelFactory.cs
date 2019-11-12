using MCProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCPro.DB.DbOperations
{
    public class ModelFactory
    {
        public PlaylistsModel Create(Playlists p)
        {
            return new PlaylistsModel()
            {
                Id = p.Id,
                Uid = p.Uid,
                P_name = p.P_name,
                Date = p.Date,
                Sid_arr = p.Sid_arr
            };
        }
    }
}
