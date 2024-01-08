using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem.UI
{
    public class UI_PlayerInventory : MonoBehaviour
    {
        [SerializeField]
        GameObject inventorySlotPrefab;

        [SerializeField]
        Inventory inventory;

        [SerializeField]
        List<UI_InventorySlot> slots;

        public Inventory Inventory => inventory;

        void Awake()
        {
            if (inventorySlotPrefab == null || inventory == null) return;
            slots = new List<UI_InventorySlot>();
           // InitializeInventoryUI();
        }

        [ContextMenu("Initialize Inventory")]
        public void InitializeInventoryUI()
        {

            for (int i = 0; i < inventory.Slots.Count; i++)
            {

                GameObject uiSlot = Instantiate(inventorySlotPrefab);
                uiSlot.transform.SetParent(transform, false);
                UI_InventorySlot uiSlotScript = uiSlot.GetComponent<UI_InventorySlot>();
                uiSlotScript.AssignSlot(i);

                slots.Add(uiSlotScript);



            }
        }


    }
}