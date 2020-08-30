namespace AutoFighters
{
    public interface IItemSlot
    {
        void SetItem(Item item);
        void RemoveItem();
        void SendItemTo(IItemSlot destinationSlot);
        bool CanMoveMyItemTo(IItemSlot destinationSlot);
        void SetIndex(int index);

        void HighlightRed();
        void HighlightGreen();
        void NoHighlight();

        Item Item { get; }
    }
}
