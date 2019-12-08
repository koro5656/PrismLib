using System;
using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace PrismLib.ViewModels
{
    /// <summary>
    /// メインページのViewModel
    /// </summary>
    public class MainPageViewModel : ViewModelBase
    {
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
