using UnityEngine;
using UnityEngine.UI;

namespace AutoFighters
{
    public class LowPanelSpellSlot : MonoBehaviour, IItemSlot
    {
        private Image _itemIcon;

        private Image _slotImage;

        [SerializeField] private IndividualLowPanel _myIndividualPanel;
        public IndividualLowPanel MyIndividualPanel { get => _myIndividualPanel; private set => _myIndividualPanel = value; }

        [SerializeField] Item _item;
        public Item Item { get => _item; private set => _item = value; }

        [SerializeField] int _index;
        public int Index { get => _index; private set => _index = value; }

        public void Awake()
        {
            _itemIcon = GetComponentsInChildren<Image>()[1];
            _slotImage = GetComponentsInChildren<Image>()[0];
            MyIndividualPanel = GetComponentInParent<IndividualLowPanel>();
        }

        public void SetItem(Item item)
        {
            Item = item as Spell;

            if (item != null)
            {
                _itemIcon.enabled = true;
                _itemIcon.sprite = item.Icon;
                MyIndividualPanel.AttachedCharacter.EquipSpell(item, Index);
            }
            else
                _itemIcon.enabled = false;
        }

        public bool CanMoveMyItemTo(IItemSlot destinationSlot)
        {
            if (destinationSlot is InventoryItemSlot)
            {
                if (destinationSlot.Item == null) return true;
                Debug.LogError($"Destination invetory slot must be empty");
                return false;
            }
            if (destinationSlot is LowPanelSpellSlot)
            {
                LowPanelSpellSlot dest = destinationSlot as LowPanelSpellSlot;
                if (dest.MyIndividualPanel.AttachedCharacter != null) return true;
                Debug.LogError($"Can't move spell to an empty panel");
                return false;
            }

            Debug.LogError($"Unrecognized item movement");
            return false;
        }

        public void SendItemTo(IItemSlot destinationSlot)
        {
            if (CanMoveMyItemTo(destinationSlot))
            {
                MyIndividualPanel.AttachedCharacter.UnequipSpell(Index);
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

        public void SetMyIndividualPanel(IndividualLowPanel panel)
        {
            MyIndividualPanel = panel;
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
