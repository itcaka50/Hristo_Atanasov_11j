using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class Game
    {
        [Key]
        public int Game_id { get; set; }

        [Required] [MaxLength(20)]

        public string Game_name { get; set; }

        public List<User> users { get; set; }

        public List<Genre> genres { get; set; }

        private Game()
        {
            users = new List<User>();
            genres = new List<Genre>();
        }

        public Game(int game_id, string game_name)
        {
            Game_id = game_id;
            Game_name = game_name;
            users = new List<User>();
            genres = new List<Genre>();
        }


    }
}
