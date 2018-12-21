using System;

using UWP_Material.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UWP_Material.Views
{
    public sealed partial class AdminPage : Page
    {
        public AdminViewModel ViewModel { get; } = new AdminViewModel();

        public AdminPage()
        {
            InitializeComponent();
        }
    }
}
