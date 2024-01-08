using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem.UI
{
    public class UI_InventorySlot : MonoBehaviour
    {

        Inventory inventory;

        [SerializeField]
        int inventorySlotIndex;

        [SerializeField]
        Image itemIcon;

        [SerializeField]
        private TMP_Text price;

        InventorySlot slot;

        public int InventorySlotIndex
        {
            get => inventorySlotIndex;
            set => inventorySlotIndex = value;

        }


        void Start()
        {
            AssignSlot(inventorySlotIndex);
        }
        public void AssignSlot(int slotIndex)
        {
            if (slot != null) slot.StateChanged -= OnStateChanged;
            inventorySlotIndex = slotIndex;
            if (inventory == null)
            {
                inventory = GetComponentInParent<UI_Inventory>().Inventory;
            }
            slot = inventory.Slots[inventorySlotIndex];
            slot.StateChanged += OnStateChanged;
            UpdateViewState(slot.State, slot.Active);

        }

        void UpdateViewState(ItemStack state, bool active)
        {
            ItemDefinition item = state?.Item;
            bool hasItem = item != null;
            itemIcon.enabled = hasItem;
            price.enabled = hasItem;
            if (!hasItem) return;
            itemIcon.sprite = item.Sprite;
            price.SetText(state.Price.ToString() + "$");

        }

        void OnStateChanged(object sender, InventorySlotStateChangedArgs args)
        {
            UpdateViewState(args.NewState, args.Active);
        }
    }
}