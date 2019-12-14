using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace PrismLib.ViewModels
{
    /// <summary>
    /// CommandページのViewModel
    /// </summary>
    public class CommandPageViewModel : ViewModelBase
    {
        IPageDialogService _PageDialogService;

        public DelegateCommand Case1Command { get; private set; }

        public DelegateCommand<string> Case2Command { get; private set; }

        public ObservableCollection<CommandListItem> CommandCollection { get; }

        public DelegateCommand<CommandListItem> Case3Command { get; private set; }

        bool isChecked4 = false;
        public bool IsChecked4
        {
            get => isChecked4;
            set
            {
                SetProperty(ref isChecked4, value);
                Case4Command.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand Case4Command { get; private set; }

        bool isChecked51 = false;
        public bool IsChecked51
        {
            get => isChecked51;
            set => SetProperty(ref isChecked51, value);
        }

        bool isChecked52 = false;
        public bool IsChecked52
        {
            get => isChecked52;
            set => SetProperty(ref isChecked52, value);
        }

        public DelegateCommand Case5Command { get; private set; }

        bool isChecked6 = false;
        public bool IsChecked6
        {
            get => isChecked6;
            set => SetProperty(ref isChecked6, value);
        }

        public DelegateCommand Case6Command { get; private set; }

        string progressText = "Please Button Click!";
        public string ProgressText
        {
            get => progressText;
            set => SetProperty(ref progressText, value);
        }

        double progressValue = 0d;
        public double ProgressValue
        {
            get => progressValue;
            set => SetProperty(ref progressValue, value);
        }

        public DelegateCommand Case71Command { get; private set; }
        public DelegateCommand Case72Command { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="navigationService">ナビゲーションサービス</param>
        public CommandPageViewModel(INavigationService navigationService
            , IPageDialogService pageDialogService) : base(navigationService)
        {
            _PageDialogService = pageDialogService;

            Title = "Command";
            Case1Command = new DelegateCommand(ExecuteCase1);
            Case2Command = new DelegateCommand<string>(ExecuteCase2);
            CommandCollection = new ObservableCollection<CommandListItem>
            {
                new CommandListItem(1, "Value1"),
                new CommandListItem(2, "Value2"),
                new CommandListItem(3, "Value3"),
            };
            Case3Command = new DelegateCommand<CommandListItem>(ExecuteCase3);
            Case4Command = new DelegateCommand(ExecuteCase4, CanCase4);
            // ObservesProperty メソッドチェーンが使える。
            Case5Command = new DelegateCommand(ExecuteCase5, CanCase5)
                .ObservesProperty(() => IsChecked51)
                .ObservesProperty(() => IsChecked52);
            // ObservesCanExecute メソッドチェーンは使えない。
            Case6Command = new DelegateCommand(ExecuteCase6).ObservesCanExecute(() => IsChecked6);
            Case71Command = new DelegateCommand(ExecuteCase7);
            Case72Command = new DelegateCommand(async () => await ExecuteCase7Async());
        }

        void ExecuteCase1()
            => _PageDialogService.DisplayAlertAsync("Command", "Case1 Click!", "OK");

        void ExecuteCase2(string param)
            => _PageDialogService.DisplayAlertAsync("Command", $"Case2 Click!{Environment.NewLine}{param}", "OK");

        void ExecuteCase3(CommandListItem item)
        {
            var msg = $"{item.No} : {item.Value}";
            _PageDialogService.DisplayAlertAsync("Command", $"Case3 Click!{Environment.NewLine}{msg}", "OK");
        }

        void ExecuteCase4()
            => _PageDialogService.DisplayAlertAsync("Command", "Case4 Click!", "OK");

        bool CanCase4()
            => IsChecked4;

        void ExecuteCase5()
            => _PageDialogService.DisplayAlertAsync("Command", "Case5 Click!", "OK");

        bool CanCase5()
            => IsChecked51 && IsChecked52;

        void ExecuteCase6()
            => _PageDialogService.DisplayAlertAsync("Command", "Case6 Click!", "OK");

        async void ExecuteCase7()
        {
            await _PageDialogService.DisplayAlertAsync("Command", "Case7(パターン1) 開始", "OK");
            await DoTaskAsync();
            await _PageDialogService.DisplayAlertAsync("Command", "Case7(パターン1) 終了", "OK");
        }

        async Task ExecuteCase7Async()
        {

            await _PageDialogService.DisplayAlertAsync("Command", "Case7(パターン2) 開始", "OK");
            await DoTaskAsync();
            await _PageDialogService.DisplayAlertAsync("Command", "Case7(パターン2) 終了", "OK");
        }

        async Task DoTaskAsync()
        {
            ProgressValue = 0d;
            ProgressText = "0%";
            await Task.Run(async () =>
            {
                int cnt = 0;
                while (true)
                {
                    if (4 < cnt) break;
                    await Task.Delay(1000);
                    cnt++;
                    ProgressValue = cnt * 0.2d;
                    ProgressText = $"{ progressValue * 100 }%";
                }
            });
        }
    }
}
