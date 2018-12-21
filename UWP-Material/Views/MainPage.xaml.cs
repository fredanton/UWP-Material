using System;

using UWP_Material.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UWP_Material.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
