namespace AutoFighters
{
    public abstract class Item
    {
        public abstract string DisplayName { get; }
        public abstract ulong UniqueId { get; }
    }
}