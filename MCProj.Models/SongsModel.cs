using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MCProj.Models
{
    public class SongsModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Song Name")]
        public string S_name { get; set; }

        [Required]
        [Display(Name = "Song Release Date")]
        [DataType(DataType.Date)]
        public System.DateTime? R_date { get; set; }

        [Required]
        [Display(Name = "Artist Name")]
        [MaxLength(100)]
        public string Art_name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        [MaxLength(50)]
        public string Genre { get; set; }

        [Required]
        [Display(Name = "Album Name")]
        [MaxLength(50)]
        public string Album_name { get; set; }

        [Required]
        [Display(Name = "Song link")]
        [DataType(DataType.Url)]
        public string Song_link { get; set; }

    }
}
