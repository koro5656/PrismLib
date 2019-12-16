using System;
using Prism.Commands;

namespace PrismLib.ViewModels
{
    public interface IApplicationCommands
    {
        CompositeCommand SaveCommand1 { get; }
        CompositeCommand SaveCommand2 { get; }
        CompositeCommand ActionCommand { get; }
    }
}
