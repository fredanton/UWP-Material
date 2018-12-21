using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_Material.Models
{
    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string username = null, string password = null)
        {
            Username = username;
            Password = password;
        }
    }
}
