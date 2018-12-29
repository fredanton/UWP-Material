using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using UWP_Material.Helpers;
using UWP_Material.Models;
using UWP_Material.Singletons;
using Windows.UI.Xaml.Controls;

namespace UWP_Material.ViewModels
{
    internal class UserViewModel : INotifyPropertyChanged
    {
        private readonly UserSingleton _user;

        private User _newUser;
        private User _selectedUser;

        public RelayCommand AddCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }

        public ObservableCollection<User> Users
        {
            get => _user.Users;
            set
            {
                _user.Users = value;
                OnPropertyChanged();
            }
        }

        public User NewUser
        {
            get => _newUser;
            set
            {
                _newUser = value;
                OnPropertyChanged();
            }
        }

        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                OnPropertyChanged();
            }
        }


        public UserViewModel()
        {
            _user = UserSingleton.Instance;

            NewUser = new User();

            AddCommand = new RelayCommand(() =>
            {
                Users.Add(NewUser);

                SqlConnection conn = new SqlConnection(Constants.ConnectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "INSERT INTO Users (user_username, user_password) VALUES (@username, @password)";

                cmd.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = NewUser.Username;
                cmd.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = NewUser.Password;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            });

            DeleteCommand = new RelayCommand(() =>
            {
                Users.Remove(SelectedUser);
            });

            SaveCommand = new RelayCommand(() =>
            {
                SelectedUser = null;
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
