using System;
using UWP_Material.Singletons;
using UWP_Material.ViewModels;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

using WinUI = Microsoft.UI.Xaml.Controls;

namespace UWP_Material.Views
{
    public sealed partial class ShellPage : Page
    {
        private static UserSingleton userSingleton { get; set; }

        public ShellViewModel ViewModel { get; } = new ShellViewModel();

        public ShellPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
            ViewModel.Initialize(shellFrame, navigationView, KeyboardAccelerators);
            
            Loop();
        }

        public void Loop()
        {
            TimeSpan period = TimeSpan.FromSeconds(0.1);

            ThreadPoolTimer PeriodicTimer = ThreadPoolTimer.CreatePeriodicTimer(async (source) =>
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.High,
                    () =>
                    {
                        userSingleton = UserSingleton.Instance;

                        if (userSingleton.CurrentUser == null)
                        {
                            Managment.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                            Separator.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                            Admin.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                            Account.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                            Login.Visibility = Windows.UI.Xaml.Visibility.Visible;
                            Logout.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                        }
                        else
                        {
                            Managment.Visibility = Windows.UI.Xaml.Visibility.Visible;
                            Separator.Visibility = Windows.UI.Xaml.Visibility.Visible;
                            Admin.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                            Account.Visibility = Windows.UI.Xaml.Visibility.Visible;
                            Login.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                            Logout.Visibility = Windows.UI.Xaml.Visibility.Visible;
                        }
                    });

            }, period);
        }

        private void OnItemInvoked(WinUI.NavigationView sender, WinUI.NavigationViewItemInvokedEventArgs args)
        {
            ViewModel.ItemInvokedCommand.Execute(args);
        }

        private void Login_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            shellFrame.Navigate(typeof(LoginPage));
        }

        private void Logout_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            userSingleton.CurrentUser = null;
        }
    }
}
