using System;

using UWP_Material.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UWP_Material.Views
{
    public sealed partial class LoginPage : Page
    {
        public LoginViewModel ViewModel { get; } = new LoginViewModel();

        public LoginPage()
        {
            InitializeComponent();
        }
    }
}
