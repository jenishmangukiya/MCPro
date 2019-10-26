using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCPro.Models;

namespace MCProDB.DBOperations
{
    public class SongsRepo
    {
        public int AddSong(SongsModel model)
        {
            using (var context = new MusicDBEntities())
            {
                Songs sg = new Songs()
                {
                    image = model.image,
                    s_name = model.s_name,
                    r_date = model.r_date,
                    art_name=model.art_name,
                    genre=model.genre,
                    album_name=model.album_name,
                    song_link=model.song_link
                };

                context.Songs.Add(sg);

                context.SaveChanges();

                return sg.sid;
            }
        }
    }
}
