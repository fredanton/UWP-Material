using System;

using UWP_Material.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UWP_Material.Views
{
    public sealed partial class SignUpPage : Page
    {
        public SignUpViewModel ViewModel { get; } = new SignUpViewModel();

        public SignUpPage()
        {
            InitializeComponent();
        }
    }
}
