using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class User
    {
        [Key]
        public int User_id { get; set; }

        [Required] [MaxLength(20)]
        public string User_name { get; set;}

        [Required] [MaxLength(20)]
        public string User_lname { get; set;}

        [Required] [Range(10, 80)]
        public int User_age { get; set;}

        [Required] [MaxLength(20)]
        public string User_username { get; set;}

        [Required] [MaxLength(70)]
        public string User_password { get; set;}

        [Required] [MaxLength(20)]
        public string User_email { get; set;}

        List<User> User_friends { get; set;}

        List<Game> games { get; set;} 

        List<Genre> genres { get; set;} 

        private User()
        {
            User_friends = new List<User>();
            games = new List<Game>();
            genres = new List<Genre>();
        }

        public User(int user_id, string user_name, string user_lname, int user_age, string user_username, string user_password, string user_email)
        {
            User_id = user_id;
            User_name = user_name;
            User_lname = user_lname;
            User_age = user_age;
            User_username = user_username;
            User_password = user_password;
            User_email = user_email;
            User_friends = new List<User>();
            games = new List<Game>();
            genres = new List<Genre>();
        }


        
    }
}
