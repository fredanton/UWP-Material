﻿using System.Collections.ObjectModel;
using System.Data.SqlClient;
using UWP_Material.Helpers;
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

            using (SqlConnection conn = new SqlConnection(Constants.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from Users";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user = new User
                            {
                                Id = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Password = reader.GetString(2),
                                Rank = reader.GetInt32(3)
                            };

                            Users.Add(user);
                        }
                    }
                }
            }
        }
    }
}
