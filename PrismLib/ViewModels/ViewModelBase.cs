using Prism.Mvvm;
using Prism.Navigation;

namespace PrismLib.ViewModels
{
    /// <summary>
    /// ViewModelのベースクラス
    /// </summary>
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        /// <summary>
        /// ナビゲーションサービス
        /// </summary>
        protected INavigationService NavigationService { get; private set; }

        private string _title;
        /// <summary>
        /// タイトル
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="navigationService">ナビゲーションサービス</param>
        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        /// <summary>
        /// 画面遷移完了前に実行される
        /// </summary>
        /// <param name="parameters">画面遷移パラメータ</param>
        public void Initialize(INavigationParameters parameters)
        {
        }

        /// <summary>
        /// 画面遷移完了時に実行される
        /// </summary>
        /// <param name="parameters">画面遷移パラメータ</param>
        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        /// <summary>
        /// 画面から離れる時に実行される
        /// </summary>
        /// <param name="parameters"></param>
        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        /// <summary>
        /// クラス解放処理
        /// </summary>
        public virtual void Destroy()
        {
            NavigationService = null;
        }
    }
}
