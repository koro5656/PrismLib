using Prism.Navigation;
using Xamarin.Essentials;

namespace PrismLib.ViewModels
{
    /// <summary>
    /// アプリケーション情報ページのViewModel
    /// </summary>
    public class AppInfoPageViewModel : ViewModelBase
    {
        /// <summary>
        /// PrismLibバージョン
        /// </summary>
        public string PrismLibVersion { get; }
        /// <summary>
        /// Xamarin.Formsバージョン
        /// </summary>
        public string XamarinFormsVersion { get; }
        /// <summary>
        /// Prism.Unity.Formsバージョン
        /// </summary>
        public string PrismUnityFormsVersion { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="navigationService">ナビゲーションサービス</param>
        public AppInfoPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "アプリケーション情報";
            PrismLibVersion = AppInfo.VersionString;
            XamarinFormsVersion = "4.3.0.991221";
            PrismUnityFormsVersion = "7.2.0.1422";
        }
    }
}
