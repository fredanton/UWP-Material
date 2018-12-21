using System.Collections.ObjectModel;
using UWP_Material.Models;

namespace UWP_Material.Singletons
{
    internal class UserSingleton
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
