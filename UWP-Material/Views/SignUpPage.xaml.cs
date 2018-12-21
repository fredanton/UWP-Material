
using System.ComponentModel;
using System.Text;
using UWP_Material.Helpers;
using UWP_Material.Models;
using UWP_Material.Singletons;
using Windows.UI.Xaml.Controls;

namespace UWP_Material.Views
{
    public sealed partial class SignUpPage : Page, INotifyPropertyChanged
    {
        private static UserSingleton userSingleton { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public SignUpPage()
        {
            InitializeComponent();

            userSingleton = UserSingleton.Instance;
        }

        private void SignUp_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (Username.Text == null || Password.Password == null || RepeatPassword.Password == null)
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

                        byte[] pw = Encoding.ASCII.GetBytes(RepeatPassword.Password);
                        byte[] st = Encoding.ASCII.GetBytes("alxbrn");

                        string pwunhashed = Encoding.UTF8.GetString(PasswordManager.GenerateSaltedHash(pw, st));

                        userSingleton.Users.Add(
                            new User(
                                Username.Text,
                                pwunhashed)
                        );

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
