using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_Material.Models
{
    class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Rank { get; set; }

        public User(int id = -1, string username = null, string password = null, int rank = 1)
        {
            Id = id;
            Username = username;
            Password = password;
            Rank = Rank;
        }
    }
}
