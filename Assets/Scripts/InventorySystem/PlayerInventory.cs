using System.Collections.Generic;

namespace InventorySystem
{
    public class PlayerInventory : Inventory
    {
        int size = 0;
        List<InventorySlot> playerSlots = new List<InventorySlot>();
        public override List<InventorySlot> Slots
        {
            get { return playerSlots; }
        }

        public override int Size
        {
            get => size; set => size = value;
        }




    }
}