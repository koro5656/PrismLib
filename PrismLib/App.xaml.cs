using Prism;
using Prism.Ioc;
using Prism.Unity;
using PrismLib.ViewModels;
using PrismLib.Views;
using Xamarin.Forms;

namespace PrismLib
{
    public partial class App : PrismApplication
    {
        public App()
            : this(null)
        {
        }

        public App(IPlatformInitializer platformInitializer)
            : base(platformInitializer)
        {
        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<WebViewPage, WebViewPageViewModel>();
            containerRegistry.RegisterForNavigation<AppInfoPage, AppInfoPageViewModel>();
            containerRegistry.RegisterForNavigation<NotifyPropertyChangedPage, NotifyPropertyChangedPageViewModel>();
            containerRegistry.RegisterForNavigation<CommandPage, CommandPageViewModel>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            base.OnSleep();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }
    }
}
