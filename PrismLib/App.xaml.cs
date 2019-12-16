using Prism;
using Prism.Ioc;
using Prism.Mvvm;
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
            containerRegistry.RegisterForNavigation<CompositeCommandPage, CompositeCommandPageViewModel>();
            containerRegistry.RegisterForNavigation<CompositeCommandTabbedPage, CompositeCommandTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<CompositeCommand1TabPage, CompositeCommand1TabPageViewModel>();
            containerRegistry.RegisterForNavigation<CompositeCommand2TabPage, CompositeCommand2TabPageViewModel>();

            containerRegistry.Register<CompositeCommand1View>();
            containerRegistry.Register<CompositeCommand2View>();
            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();
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
