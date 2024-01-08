using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class InventorySlotStateChangedArgs
    {
       public ItemStack NewState { get; }
        public bool Active { get; }

        public InventorySlotStateChangedArgs(ItemStack newState, bool active)
        { 
          NewState = newState;
          Active = active;
        }
    }
}