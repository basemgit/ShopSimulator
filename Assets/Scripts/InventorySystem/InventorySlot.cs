using System;
using UnityEngine;

namespace InventorySystem
{
    [Serializable]
    public class InventorySlot
    {
        public event EventHandler<InventorySlotStateChangedArgs> StateChanged;

        [SerializeField]
        ItemStack state;

        bool active;

        public ItemStack State
        {
            get => state;
            set 
            {
                state = value;
                NotifyAboutStateChange();
            }
        
        }

        public bool Active
        { 
            get => active;
            set
            {
                active = value;
                NotifyAboutStateChange();
            }
        
        }

        public int NumberOfItems
        {
            get => state.NumberOfItems;
            set
            {
                state.NumberOfItems = value;
                NotifyAboutStateChange();
            }
        }

        void NotifyAboutStateChange()
        {
            StateChanged?.Invoke(this, new InventorySlotStateChangedArgs(state, active));
        }

        public bool HasItem => state?.Item != null;
        public ItemDefinition Item => state?.Item;


        public void Clear()
        { 
          State = null;
        }
    }
}