using System;
using System.Diagnostics;
using Prism;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace PrismLib.ViewModels
{
    public class CompositeCommand1TabPageViewModel : ViewModelBase, IActiveAware
    {
        IPageDialogService _PageDialogService;
        IApplicationCommands _ApplicationCommands;

        public event EventHandler IsActiveChanged;

        bool isActive;
        public bool IsActive
        {
            get => isActive;
            set
            {
                SetProperty(ref isActive, value);
                OnIsActiveChanged();
            }
        }

        public DelegateCommand UpdateCommand { get; }
        public DelegateCommand ClickCommand { get; }

        public CompositeCommand1TabPageViewModel(INavigationService navigationService
            , IPageDialogService pageDialogService
            , IApplicationCommands applicationCommands) : base(navigationService)
        {
            _PageDialogService = pageDialogService;
            _ApplicationCommands = applicationCommands;

            Title = "Tab1";
            UpdateCommand = new DelegateCommand(Update);
            _ApplicationCommands.SaveCommand2.RegisterCommand(UpdateCommand);
            ClickCommand = new DelegateCommand(Click);
            _ApplicationCommands.ActionCommand.RegisterCommand(ClickCommand);
            Debug.WriteLine($"Tab1 Initialize: {ClickCommand.IsActive}");
        }

        public override void Destroy()
        {
            _ApplicationCommands.SaveCommand2.UnregisterCommand(UpdateCommand);
            _ApplicationCommands.ActionCommand.UnregisterCommand(ClickCommand);
            base.Destroy();
        }

        void Update()
            => _PageDialogService.DisplayAlertAsync("Tab1", $"Save!", "OK");

        void Click()
            => _PageDialogService.DisplayAlertAsync("Tab1", $"Click!", "OK");

        void OnIsActiveChanged()
        {
            ClickCommand.IsActive = IsActive;
            Debug.WriteLine($"Tab1 OnIsActiveChanged: {ClickCommand.IsActive}");
        }
    }
}
