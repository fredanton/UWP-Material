using System.Collections.ObjectModel;
using System.Data.SqlClient;
using UWP_Material.Models;
using UWP_Material.Helpers;

namespace UWP_Material.Singletons
{
    class RoleSingleton
    {
        private static RoleSingleton _instance;

        public static RoleSingleton Instance => _instance ?? (_instance = new RoleSingleton());

        public ObservableCollection<Role> Roles { get; set; }

        public Role CurrentUser { get; set; } = null;

        private RoleSingleton()
        {
            Roles = new ObservableCollection<Role>();

            using (SqlConnection conn = new SqlConnection(Constants.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from Roles";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Role role = new Role
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            };

                            Roles.Add(role);
                        }
                    }
                }
            }
        }
    }
}
