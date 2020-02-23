using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCProj.Models;

namespace MCPro.DB.DbOperations
{
    public class SongsRepo
    {
        //Add Song
        public int AddSong(SongsModel model)
        {
            using (var context = new MusicDBEntities())
            {
                Songs sg = new Songs()
                {
                    S_name = model.S_name,
                    R_date = model.R_date,
                    Art_name = model.Art_name,
                    Genre = model.Genre,
                    Album_name = model.Album_name,
                    Song_link = model.Song_link
                };
                context.Songs.Add(sg);

                context.SaveChanges();

                return sg.Id;
            }
        }

        //Edit Song
        public int EditSong(SongsModel model)
        {
            using (var context = new MusicDBEntities())
            {
                var sg = context.Songs.Where(x=>x.Id==model.Id).FirstOrDefault();

                sg.S_name = model.S_name;
                sg.R_date = model.R_date;
                sg.Art_name = model.Art_name;
                sg.Genre = model.Genre;
                sg.Album_name = model.Album_name;
                sg.Song_link = model.Song_link;

                context.SaveChanges();

                return sg.Id;
            }
        }

        //delete song
        public void DeleteSong(int id)
        {
            using (var context = new MusicDBEntities())
            {
                var rec = context.Songs.Find(id);

                context.Songs.Remove(rec);

                context.SaveChanges();
            }
        }

        //get song
        public SongsModel GetSong(int id)
        {
            using (var context = new MusicDBEntities())
            {

                Songs s = context.Songs.Where(x => x.Id == id).FirstOrDefault();

                SongsModel sm = new SongsModel()
                {
                    Id = s.Id,
                    S_name = s.S_name,
                    R_date = s.R_date,
                    Art_name = s.Art_name,
                    Genre = s.Genre,
                    Album_name = s.Album_name,
                    Song_link = s.Song_link
                };

                return sm;
            }
        }
    }
}
