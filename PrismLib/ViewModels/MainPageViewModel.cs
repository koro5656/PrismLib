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
        /// PrismドキュメントURL
        /// </summary>
        readonly string url = @"https://prismlibrary.github.io/docs/index.html";

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
        /// ドキュメントコマンド
        /// </summary>
        public DelegateCommand DocCommand { get; private set; }
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
                new MenuListItem(1,"テスト","テストの説明", DateTime.Now, true)
            };
            DocCommand = new DelegateCommand(ShowDocumentPage);
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
        /// ドキュメントページ表示
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

            _PageDialogService.DisplayAlertAsync("PrismLib", "テスト選択", "OK");

            // 選択を解除
            SelectedMenuItem = null;
        }
    }
}
