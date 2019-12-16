using Prism.Commands;

namespace PrismLib.ViewModels
{
    public class ApplicationCommands : IApplicationCommands
    {
        public CompositeCommand SaveCommand1 { get; } = new CompositeCommand();
        public CompositeCommand SaveCommand2 { get; } = new CompositeCommand();
        public CompositeCommand ActionCommand { get; } = new CompositeCommand();
    }
}
