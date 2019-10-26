using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MCPro.Models
{
    public class SongsModel
    {
        public int sid { get; set; }

        [Required]
        [Display(Name = "Pick Image")]
        [DataType(DataType.Upload)]
        public byte[] image { get; set; }

        [Required]
        [Display(Name = "Song Name")]
        public string s_name { get; set; }

        [Required]
        [Display(Name = "Song Release Date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> r_date { get; set; }

        [Required]
        [Display(Name = "Artist Name")]
        public string art_name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public string genre { get; set; }

        [Required]
        [Display(Name = "Album Name")]
        public string album_name { get; set; }

        [Required]
        [Display(Name = "Song Link")]
        [DataType(DataType.Url)]
        public string song_link { get; set; }
    }
}
