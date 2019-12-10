using System;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace PrismLib.ViewModels
{
    /// <summary>
    /// WebViewページのViewModel
    /// </summary>
    public class WebViewPageViewModel : ViewModelBase
    {
        /// <summary>
        /// 画面遷移パラメータ−タイトル
        /// </summary>
        public const string ParameterKey_Title = "Title";
        /// <summary>
        /// 画面遷移パラメータ−URL
        /// </summary>
        public const string ParameterKey_Url = "Url";

        bool _isBack = false;
        /// <summary>
        /// WebViewのGoBack実行可否
        /// </summary>
        public bool IsBack
        {
            get => _isBack;
            set => SetProperty(ref _isBack, value);
        }

        bool _isForward = false;
        /// <summary>
        /// WebViewのGoForward実行可否
        /// </summary>
        public bool IsForward
        {
            get => _isForward;
            set => SetProperty(ref _isForward, value);
        }

        bool isLoading = false;
        /// <summary>
        /// WebViewロード中
        /// </summary>
        public bool IsLoading
        {
            get => isLoading;
            set => SetProperty(ref isLoading, value);
        }

        DelegateCommand _goBackCommand;
        /// <summary>
        /// WebViewのGoBackを実行するコマンド
        /// </summary>
        /// <remarks>
        /// WebViewBehaviorのGoBackCommandを受けるためSetPropertyで実装
        /// </remarks>
        public DelegateCommand GoBackCommand
        {
            get => _goBackCommand;
            set
            {
                // IsBack=trueのみ活性にするためObservesCanExecuteを設定
                if (_goBackCommand == null && value != null)
                {
                    value.ObservesCanExecute(() => IsBack);
                }
                SetProperty(ref _goBackCommand, value);
            }
        }

        DelegateCommand _goForwardCommand;
        /// <summary>
        /// WebViewのGoForwardを実行するコマンド
        /// </summary>
        /// <remarks>
        /// WebViewBehaviorのGoForwardCommandを受けるためSetPropertyで実装
        /// </remarks>
        public DelegateCommand GoForwardCommand
        {
            get => _goForwardCommand;
            set
            {
                // IsForward=trueのみ活性にするためObservesCanExecuteを設定
                if (_goForwardCommand == null && value != null)
                {
                    value.ObservesCanExecute(() => IsForward);
                }
                SetProperty(ref _goForwardCommand, value);
            }
        }

        DelegateCommand _reloadCommand;
        /// <summary>
        /// WebViewのReloadを実行するコマンド
        /// </summary>
        /// <remarks>
        /// WebViewBehaviorのReloadCommandを受けるためSetPropertyで実装
        /// </remarks>
        public DelegateCommand ReloadCommand
        {
            get => _reloadCommand;
            set => SetProperty(ref _reloadCommand, value);
        }

        WebViewSource _webViewSource;
        public WebViewSource WebViewSource
        {
            get => _webViewSource;
            set => SetProperty(ref _webViewSource, value);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="navigationService">ナビゲーションサービス</param>
        public WebViewPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "WebView";
        }

        /// <summary>
        /// 画面遷移完了前に実行される処理
        /// </summary>
        /// <param name="parameters">画面遷移パラメータ</param>
        public override void Initialize(INavigationParameters parameters)
        {
            // Title
            parameters.TryGetValue<string>(ParameterKey_Title, out string title);
            Title = string.IsNullOrEmpty(title) ? "WebPage" : title;
            // URI
            parameters.TryGetValue<string>(ParameterKey_Url, out string url);
            WebViewSource = new UrlWebViewSource { Url = url };
        }
    }
}
