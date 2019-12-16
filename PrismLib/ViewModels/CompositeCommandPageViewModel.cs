using Prism.Commands;
using Prism.Ioc;
using Prism.Navigation;
using PrismLib.Views;
using Unity;
using Xamarin.Forms;

namespace PrismLib.ViewModels
{
    public class CompositeCommandPageViewModel : ViewModelBase
    {
        CompositeCommand1View view1 { get; }
        CompositeCommand2View view2 { get; }

        ContentView view;
        public ContentView View
        {
            get => view;
            set => SetProperty(ref view, value);
        }

        public DelegateCommand View1NavigationCommand { get; }
        public DelegateCommand View2NavigationCommand { get; }
        public DelegateCommand SaveAllCommand { get; }
        public DelegateCommand NavigationCommand { get; }
        public IApplicationCommands ApplicationCommands { get; private set; }

        public CompositeCommandPageViewModel(INavigationService navigationService
            , IUnityContainer unityContainer, IApplicationCommands applicationCommands)
            : base(navigationService)
        {
            ApplicationCommands = applicationCommands;
            
            Title = "CompositeCommand";
            view1 = unityContainer.Resolve<CompositeCommand1View>();
            view2 = unityContainer.Resolve<CompositeCommand2View>();
            View = view1;
            View1NavigationCommand = new DelegateCommand(() => View = view1);
            View2NavigationCommand = new DelegateCommand(() => View = view2);
            var url = "CompositeCommandTabbedPage?createTab=CompositeCommand1TabPage&createTab=CompositeCommand2TabPage";
            NavigationCommand = new DelegateCommand(() => navigationService.NavigateAsync(url));
        }

        public override void Destroy()
        {
            (view1.BindingContext as IDestructible).Destroy();
            (view2.BindingContext as IDestructible).Destroy();
            base.Destroy();
        }
    }
}
