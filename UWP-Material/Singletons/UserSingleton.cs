using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_Material.Models;

namespace UWP_Material.Singletons
{
    class UserSingleton
    {
        private static UserSingleton _instance;

        public static UserSingleton Instance => _instance ?? (_instance = new UserSingleton());

        public ObservableCollection<User> Users { get; set; }

        public User CurrentUser { get; set; } = null;

        private UserSingleton()
        {
            Users = new ObservableCollection<User>();
        }
    }
}
