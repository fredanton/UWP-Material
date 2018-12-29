using System.Data;
using System.Data.SqlClient;
using System.Text;
using UWP_Material.Helpers;
using UWP_Material.Models;
using UWP_Material.Singletons;
using Windows.UI.Xaml.Controls;

namespace UWP_Material.Views
{
    public sealed partial class SignUpPage : Page
    {
        private static UserSingleton userSingleton { get; set; }

        public SignUpPage()
        {
            InitializeComponent();

            userSingleton = UserSingleton.Instance;
        }

        private void SignUp_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (Username.Text == "" || Password.Password == "" || RepeatPassword.Password == "")
            {
                StackPanelError.Visibility = Windows.UI.Xaml.Visibility.Visible;
                Error.Text = "Please provide all information to sign up.";
            }
            else
            {
                if (Password.Password != RepeatPassword.Password)
                {
                    StackPanelError.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    Error.Text = "Please provide matching passwords.";
                }
                else
                {
                    PasswordManager.PasswordScore score = PasswordManager.CheckStrength(RepeatPassword.Password);

                    if (score == PasswordManager.PasswordScore.Weak || score == PasswordManager.PasswordScore.Medium || score == PasswordManager.PasswordScore.Strong || score == PasswordManager.PasswordScore.VeryStrong)
                    {
                        StackPanelError.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                        Error.Text = "";

                        // Local observable collection insert
                        var x = new User();

                        x.Username = Username.Text;
                        x.Password = Password.Password;

                        userSingleton.Users.Add(x);

                        // Database insert
                        SqlConnection conn = new SqlConnection(Constants.ConnectionString);
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;

                        cmd.CommandText = "INSERT INTO Users (user_username, user_password) VALUES (@username, @password)";

                        cmd.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = x.Username;
                        cmd.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = x.Password;

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        // Success frame navigate
                        Frame.Navigate(typeof(LoginPage));
                    }
                    else
                    {
                        StackPanelError.Visibility = Windows.UI.Xaml.Visibility.Visible;
                        Error.Text = "Please provide a stronger password.";
                    }
                }
            }
        }

        private void Back_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginPage));
        }
    }
}
