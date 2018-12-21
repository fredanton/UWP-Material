using System.Windows.Input;

using UWP_Material.Helpers;
using UWP_Material.Services;

using Windows.ApplicationModel;
using Windows.UI.Xaml;

namespace UWP_Material.ViewModels
{
    public class SettingsViewModel : Observable
    {
        private ElementTheme _elementTheme = ThemeSelectorService.Theme;

        public ElementTheme ElementTheme
        {
            get => _elementTheme;

            set => Set(ref _elementTheme, value);
        }

        private string _versionDescription;

        public string VersionDescription
        {
            get => _versionDescription;

            set => Set(ref _versionDescription, value);
        }

        private ICommand _switchThemeCommand;

        public ICommand SwitchThemeCommand
        {
            get
            {
                if (_switchThemeCommand == null)
                {
                    _switchThemeCommand = new RelayCommand<ElementTheme>(
                        async (param) =>
                        {
                            ElementTheme = param;
                            await ThemeSelectorService.SetThemeAsync(param);
                        });
                }

                return _switchThemeCommand;
            }
        }

        public SettingsViewModel()
        {
        }

        public void Initialize()
        {
            VersionDescription = GetVersionDescription();
        }

        private string GetVersionDescription()
        {
            string appName = "AppDisplayName".GetLocalized();
            Package package = Package.Current;
            PackageId packageId = package.Id;
            PackageVersion version = packageId.Version;

            return $"{appName} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }
    }
}
