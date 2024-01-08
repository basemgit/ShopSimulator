using InventorySystem.UI;
using UnityEngine;

namespace InventorySystem
{

    public class InventoryInputHandler : MonoBehaviour
    {

        Inventory inventory;
        PlayerInventory playerInventory;
        UI_InventorySlot slot;
        UI_Inventory uiInventory;
        private void Awake()
        {
            inventory = GameObject.FindGameObjectWithTag("ShopKeeper1Inventory").GetComponent<Inventory>();
            playerInventory = GameObject.FindGameObjectWithTag("PlayerInventory").GetComponent<PlayerInventory>();
            slot = GetComponent<UI_InventorySlot>();
            uiInventory = GameObject.FindGameObjectWithTag("PlayerUI").GetComponent<UI_Inventory>();
        }
        public void PickItem()
        {
            if (gameObject.CompareTag("InventorySlot"))
            {
                ItemStack itemStack = inventory.RemoveItem(slot.InventorySlotIndex);
                InventorySlot newSlot = new InventorySlot();
                newSlot.State = itemStack;
                playerInventory.Slots.Clear();
                playerInventory.Slots.Add(newSlot);
                uiInventory.InitializeInventoryUI();
                Destroy(gameObject);
            }
        }
    }
}