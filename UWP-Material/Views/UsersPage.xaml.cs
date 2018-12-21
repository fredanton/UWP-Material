using System;

using UWP_Material.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UWP_Material.Views
{
    public sealed partial class UsersPage : Page
    {
        public UsersViewModel ViewModel { get; } = new UsersViewModel();

        // TODO WTS: Change the grid as appropriate to your app, adjust the column definitions on UsersPage.xaml.
        // For more details see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid
        public UsersPage()
        {
            InitializeComponent();
        }
    }
}
