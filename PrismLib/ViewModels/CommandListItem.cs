namespace PrismLib.ViewModels
{
    public class CommandListItem
    {
        public int No { get; }
        public string Value { get; }

        public CommandListItem(int no, string value)
        {
            No = no;
            Value = value;
        }
    }
}
