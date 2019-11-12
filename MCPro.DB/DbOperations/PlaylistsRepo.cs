using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCProj.Models;

namespace MCPro.DB.DbOperations
{
    public class PlaylistsRepo
    {
        //get playlist information

        public PlaylistsModel GetPlayList(int id)
        {
            using (var context = new MusicDBEntities())
            {

                Playlists pl = context.Playlists.Where(x => x.Id == id).FirstOrDefault();

                PlaylistsModel pm = new PlaylistsModel()
                {
                    Id=pl.Id,
                    Uid=pl.Uid,
                    P_name=pl.P_name,
                    Date=pl.Date,
                    Sid_arr=pl.Sid_arr
                };

                return pm;
            }
        }
    }
}
