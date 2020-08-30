using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace AutoFighters
{
    public class DragAndDropHandler : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler, 
        IDragHandler
    {
        [SerializeField] private RectTransform _imageTranform; // Transform used to move Icon around
        [SerializeField] private Canvas _iconCanvas; // Canvas of icon to put it in front when dragging
        [SerializeField] private Image _itemIcon; // Used to transparent icon when dragging
        [SerializeField] private Image _slotImage; // Used to change slot color when hovering

        [SerializeField] private IItemSlot _thisSlot;

        [SerializeField] private static IItemSlot _slotPickedFrom;
        [SerializeField] private static IItemSlot _slotDroppedIn;

        void Awake()
        {
            // If the component is an inventory slot
            if (GetComponent<InventoryItemSlot>() != null)
                _thisSlot = GetComponent<InventoryItemSlot>();
            // If the component is a Lower panel SpellSlot
            else if (GetComponent<LowPanelSpellSlot>() != null)
                _thisSlot = GetComponent<LowPanelSpellSlot>();
            else
                Debug.LogError("SLOT TYPE NOT RECOGNIZED");

            _imageTranform = GetComponentsInChildren<RectTransform>()[1];
            _itemIcon = GetComponentsInChildren<Image>()[1];
            _slotImage = GetComponentsInChildren<Image>()[0];
        }

        void Start()
        {
            _iconCanvas = GetComponentInChildren<Canvas>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _itemIcon.color = ColorConsts.TransparentOnDrag;
            _slotPickedFrom = _thisSlot;
            _iconCanvas.sortingOrder = 10;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            // Reset dragged image properties
            _itemIcon.color = ColorConsts.White;
            _imageTranform.anchoredPosition = Vector3.zero;
            _iconCanvas.sortingOrder = 1;

            _slotPickedFrom.SendItemTo(_slotDroppedIn);

            // Reset static
            _slotDroppedIn.NoHighlight();
            _slotPickedFrom = null;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _slotDroppedIn = _thisSlot; // remember the slot for dropping

            // if we're dragging an item
            if (_slotPickedFrom != null)
            {
                if (_slotPickedFrom.CanMoveMyItemTo(_thisSlot))
                {
                    _slotDroppedIn.HighlightGreen();
                }
                else
                {
                    _slotDroppedIn.HighlightRed();
                }
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _slotDroppedIn.NoHighlight();
            _slotDroppedIn = null;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _imageTranform.anchoredPosition += eventData.delta / _iconCanvas.scaleFactor;
        }
    }
}
