using System;

using UWP_Material.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UWP_Material.Views
{
    public sealed partial class AccountPage : Page
    {
        public AccountViewModel ViewModel { get; } = new AccountViewModel();

        public AccountPage()
        {
            InitializeComponent();
        }
    }
}
