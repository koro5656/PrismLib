using System;
using Prism.Navigation;

namespace PrismLib.ViewModels
{
    public class CompositeCommandTabbedPageViewModel : ViewModelBase
    {
        private IApplicationCommands _applicationCommands;
        public IApplicationCommands ApplicationCommands
        {
            get { return _applicationCommands; }
            set { SetProperty(ref _applicationCommands, value); }
        }

        public CompositeCommandTabbedPageViewModel(INavigationService navigationService
            , IApplicationCommands applicationCommands) : base(navigationService)
        {
            ApplicationCommands = applicationCommands;

            Title = "CompositeCommand";
        }
    }
}
