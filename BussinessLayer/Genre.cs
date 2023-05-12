using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class Genre
    {
        [Key] 
        public int Genre_id { get; set; }

        [Required] [MaxLength(20)]
        public string Genre_name { get; set; }

        List<User> users { get; set; }

        List<Game> games { get; set; }

        private Genre()
        {
            users = new List<User>();
            games = new List<Game>();
        }

        public Genre(int genre_id, string genre_name)
        {
            Genre_id = genre_id;
            Genre_name = genre_name;  
            users = new List<User>();
            games = new List<Game>();
        }
    }
}
