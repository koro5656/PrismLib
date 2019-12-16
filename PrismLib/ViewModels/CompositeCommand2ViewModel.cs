using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;

namespace PrismLib.ViewModels
{
    public class CompositeCommand2ViewModel : BindableBase, IDestructible
    {
        IPageDialogService _PageDialogService;
        IApplicationCommands _ApplicationCommands;

        string saveValue;
        public string SaveValue
        {
            get => saveValue;
            set => SetProperty(ref saveValue, value);
        }

        public DelegateCommand UpdateCommand { get; }

        public CompositeCommand2ViewModel(IPageDialogService pageDialogService
            , IApplicationCommands applicationCommands)
        {
            _PageDialogService = pageDialogService;
            _ApplicationCommands = applicationCommands;

            UpdateCommand = new DelegateCommand(Update, () => !string.IsNullOrWhiteSpace(SaveValue))
                .ObservesProperty(() => SaveValue);
            applicationCommands.SaveCommand1.RegisterCommand(UpdateCommand);
        }

        public void Destroy()
            => _ApplicationCommands.SaveCommand1.UnregisterCommand(UpdateCommand);

        void Update()
        {
            _PageDialogService.DisplayAlertAsync("View2", $"{SaveValue} Save!", "OK");
            SaveValue = string.Empty;
        }
    }
}
