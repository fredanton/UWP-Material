
using UWP_Material.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UWP_Material.Views
{
    public sealed partial class UsersPage : Page
    {
        public UsersViewModel ViewModel { get; } = new UsersViewModel();
        
        public UsersPage()
        {
            InitializeComponent();
        }
    }
}
