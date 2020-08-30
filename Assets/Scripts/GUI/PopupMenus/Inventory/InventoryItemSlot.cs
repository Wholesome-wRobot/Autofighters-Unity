using UnityEngine;
using UnityEngine.UI;

namespace AutoFighters
{
    public class InventoryItemSlot : MonoBehaviour, IItemSlot
    {
        public Canvas inventoryCanvas;

        private Image _slotImage;

        [SerializeField] private Item _item;
        public Item Item { get => _item; private set => _item = value; }

        [SerializeField] private int _index;
        public int Index { get => _index; private set => _index = value; }

        private Image _imageComponent;

        void Awake()
        {
            _imageComponent = GetComponentsInChildren<Image>()[1];
            _slotImage = GetComponentsInChildren<Image>()[0];
        }

        void Start()
        {
            Transform transform = gameObject.GetComponent<Transform>();
            transform.localScale = new Vector3(1, 1, 1); 
        }

        public void SetItem(Item item)
        {
            if (item != null)
            {
                Item = item;
                _imageComponent.enabled = true;
                _imageComponent.overrideSprite = item.Icon;
            }
            else
            {
                Item = item;
                _imageComponent.enabled = false;
            }
        }

        public bool CanMoveMyItemTo(IItemSlot destinationSlot)
        {
            if (destinationSlot is InventoryItemSlot) return true;
            if (destinationSlot is LowPanelSpellSlot)
            {
                LowPanelSpellSlot dest = destinationSlot as LowPanelSpellSlot;
                if (Item is Spell && dest.MyIndividualPanel.AttachedCharacter != null)
                {
                    return true;
                }
                Debug.LogError($"Item {Item.DisplayName} is not a spell or the panel char is null");
                return false;
            }

            Debug.LogError($"Unrecognized item movement");
            return false;
        }

        public void SendItemTo(IItemSlot destinationSlot)
        {
            if (CanMoveMyItemTo(destinationSlot))
            {
                Item myItem = Item;
                SetItem(destinationSlot.Item);
                destinationSlot.SetItem(myItem);
            }
        }

        public void RemoveItem()
        {
            Item = null;
        }

        public void SetIndex(int index)
        {
            Index = index;
        }

        public void HighlightRed()
        {
            _slotImage.color = ColorConsts.SlotColorRed;
        }

        public void HighlightGreen()
        {
            _slotImage.color = ColorConsts.SlotColorOnHover;
        }

        public void NoHighlight()
        {
            _slotImage.color = ColorConsts.White;
        }
    }
}
