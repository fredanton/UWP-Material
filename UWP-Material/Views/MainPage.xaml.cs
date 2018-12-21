
using UWP_Material.Singletons;
using Windows.UI.Xaml.Controls;

namespace UWP_Material.Views
{
    public sealed partial class MainPage : Page
    {
        private static UserSingleton userSingleton { get; set; }

        public MainPage()
        {
            InitializeComponent();

            userSingleton = UserSingleton.Instance;

            if (userSingleton.CurrentUser != null)
            {
                CurrentUser.Text += " ";
                CurrentUser.Text += userSingleton.CurrentUser.Username;
            }
        }
    }
}
