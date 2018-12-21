using System;
using System.Threading.Tasks;

using UWP_Material.Services;

using Windows.ApplicationModel.Activation;

namespace UWP_Material.Activation
{
    internal class DefaultLaunchActivationHandler : ActivationHandler<LaunchActivatedEventArgs>
    {
        private readonly Type _navElement;

        public DefaultLaunchActivationHandler(Type navElement)
        {
            _navElement = navElement;
        }

        protected override async Task HandleInternalAsync(LaunchActivatedEventArgs args)
        {
            NavigationService.Navigate(_navElement, args.Arguments);

            await Task.CompletedTask;
        }

        protected override bool CanHandleInternal(LaunchActivatedEventArgs args)
        {
            return NavigationService.Frame.Content == null;
        }
    }
}
