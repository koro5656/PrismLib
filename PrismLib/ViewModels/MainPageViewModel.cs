using System;
using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using PrismLib.Views;
using Xamarin.Essentials;

namespace PrismLib.ViewModels
{
    /// <summary>
    /// メインページのViewModel
    /// </summary>
    public class MainPageViewModel : ViewModelBase
    {
        /// <summary>
        /// GitURL
        /// </summary>
        readonly string url = @"https://github.com/koro5656/PrismLib";

        /// <summary>
        /// ページダイアログサービス
        /// </summary>
        IPageDialogService _PageDialogService;

        MenuListItem selectedMenuItem;
        /// <summary>
        /// 選択したメニュー
        /// </summary>
        public MenuListItem SelectedMenuItem
        {
            get => selectedMenuItem;
            set => SetProperty(ref selectedMenuItem, value);
        }

        /// <summary>
        /// メニューコレクション
        /// </summary>
        public ObservableCollection<MenuListItem> MenuCollection { get; private set; }
        /// <summary>
        /// Gitコマンド
        /// </summary>
        public DelegateCommand GitCommand { get; private set; }
        /// <summary>
        /// アプリケーション情報コマンド
        /// </summary>
        public DelegateCommand AppInfoCommand { get; private set; }
        /// <summary>
        /// メニュー選択コマンド
        /// </summary>
        public DelegateCommand<MenuListItem> MenuSelectCommand { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="navigationService">ナビゲーションサービス</param>
        public MainPageViewModel(INavigationService navigationService
            ,IPageDialogService pageDialogService)
            : base(navigationService)
        {
            _PageDialogService = pageDialogService;

            Title = "PrismLib";
            MenuCollection = new ObservableCollection<MenuListItem>
            {
                new MenuListItem(1,"Prism Template Pack","Prism Template Packのインストール方法について説明します。", DateTime.Now, false),
                new MenuListItem(2,"INotifyPropertyChanged","INotifyPropertyChangedについて説明します。", DateTime.Now, false),
                new MenuListItem(3,"Command","Commandについて説明します。", DateTime.Now, false),
                new MenuListItem(4,"CompositeCommand","CompositeCommandについて説明します。", DateTime.Now, true),
            };
            GitCommand = new DelegateCommand(ShowDocumentPage);
            AppInfoCommand = new DelegateCommand(ShowAppInfoPage);
            MenuSelectCommand = new DelegateCommand<MenuListItem>(SelectedMenu);
        }

        /// <summary>
        /// クラス解放処理
        /// </summary>
        public override void Destroy()
        {
            _PageDialogService = null;
            base.Destroy();
        }

        /// <summary>
        /// Gitページ表示
        /// </summary>
        void ShowDocumentPage()
        {
            Browser.OpenAsync(url, BrowserLaunchMode.SystemPreferred);
        }

        /// <summary>
        /// アプリケーション情報ページ表示
        /// </summary>
        void ShowAppInfoPage()
        {
            NavigationService.NavigateAsync(nameof(AppInfoPage));
        }

        /// <summary>
        /// メニュー選択
        /// </summary>
        /// <param name="item">選択したメニューリストアイテム</param>
        void SelectedMenu(MenuListItem item)
        {
            if (item == null)
            {
                return;
            }

            var naviParams = new NavigationParameters();
            switch (item.Id)
            {
                case 1:
                    naviParams.Add(WebViewPageViewModel.ParameterKey_Title, "Prism Template Pack");
                    naviParams.Add(WebViewPageViewModel.ParameterKey_Url, @"https://github.com/koro5656/PrismUnityForm-for-mac");
                    NavigationService.NavigateAsync(nameof(WebViewPage), naviParams);
                    break;
                case 2:
                    NavigationService.NavigateAsync(nameof(NotifyPropertyChangedPage), naviParams);
                    break;
                case 3:
                    NavigationService.NavigateAsync(nameof(CommandPage), naviParams);
                    break;
                case 4:
                    NavigationService.NavigateAsync(nameof(CompositeCommandPage), naviParams);
                    break;
                default:
                    break;
            }

            // 選択を解除
            SelectedMenuItem = null;
        }
    }
}
