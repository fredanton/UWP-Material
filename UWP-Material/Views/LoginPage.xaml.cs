
using System.Text;
using UWP_Material.Helpers;
using UWP_Material.Singletons;
using Windows.UI.Xaml.Controls;

namespace UWP_Material.Views
{
    public sealed partial class LoginPage : Page
    {
        private static UserSingleton userSingleton { get; set; }

        public LoginPage()
        {
            InitializeComponent();

            userSingleton = UserSingleton.Instance;
        }

        private void SignUp_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SignUpPage));
        }

        private void Login_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (Username.Text == null || Password.Password == null)
            {
                StackPanelError.Visibility = Windows.UI.Xaml.Visibility.Visible;
                Error.Text = "Please provide all information to login.";
            }
            else
            {
                byte[] pw = Encoding.ASCII.GetBytes(Password.Password);
                byte[] st = Encoding.ASCII.GetBytes("alxbrn");

                string pwunhashed = Encoding.UTF8.GetString(PasswordManager.GenerateSaltedHash(pw, st));

                foreach (Models.User i in userSingleton.Users)
                {
                    if (i.Username == Username.Text && i.Password == pwunhashed)
                    {
                        userSingleton.CurrentUser = i;
                        Frame.Navigate(typeof(MainPage));
                    }
                }

                StackPanelError.Visibility = Windows.UI.Xaml.Visibility.Visible;
                Error.Text = "Please provide valid login information";
            }
        }
    }
}
