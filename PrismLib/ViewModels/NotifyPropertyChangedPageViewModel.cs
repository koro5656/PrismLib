using System;
using Prism.Navigation;

namespace PrismLib.ViewModels
{
    /// <summary>
    /// INotifyPropertyChangedページのViewModel
    /// </summary>
    public class NotifyPropertyChangedPageViewModel : ViewModelBase
    {
        /// <summary>
        /// コンストラクタで設定するプロパティ
        /// </summary>
        public string Property1 { get; set; }

        string property2;
        /// <summary>
        /// コンストラクタで設定するプロパティ
        /// </summary>
        public string Property2
        {
            get => property2;
            set => SetProperty(ref property2, value);
        }

        /// <summary>
        /// Initializeで設定するプロパティ
        /// </summary>
        public string Property3 { get; set; }

        string property4;
        /// <summary>
        /// Initializeで設定するプロパティ
        /// </summary>
        public string Property4
        {
            get => property4;
            set => SetProperty(ref property4, value);
        }

        /// <summary>
        /// OnNavigatedToで設定するプロパティ
        /// </summary>
        public string Property5 { get; set; }

        string property6;
        /// <summary>
        /// OnNavigatedToで設定するプロパティ
        /// </summary>
        public string Property6
        {
            get => property6;
            set => SetProperty(ref property6, value);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="navigationService">ナビゲーションサービス</param>
        public NotifyPropertyChangedPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "INotifyPropertyChanged";
            Property1 = "Hello PrismLib!";
            Property2 = "Hello PrismLib!";
        }

        /// <summary>
        /// 画面遷移完了前に実行される
        /// </summary>
        /// <param name="parameters">画面遷移パラメータ</param>
        public override void Initialize(INavigationParameters parameters)
        {
            Property3 = "Hello PrismLib!!";
            Property4 = "Hello PrismLib!!";
        }

        /// <summary>
        /// 画面遷移完了後に実行される
        /// </summary>
        /// <param name="parameters">画面遷移パラメータ</param>
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Property5 = "Hello PrismLib!!!";
            Property6 = "Hello PrismLib!!!";
            base.OnNavigatedTo(parameters);
        }
    }
}
