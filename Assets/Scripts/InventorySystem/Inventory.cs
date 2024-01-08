using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField]
        int size = 8;
        [SerializeField]
        List<InventorySlot> slots;
        int activeSlotIndex;

        public virtual int Size
        {
            get => size;
            set => size = value;
        }
        public virtual List<InventorySlot> Slots => slots;

        public int ActiveSlotIndex
        {
            get => activeSlotIndex;
            private set
            {
                slots[activeSlotIndex].Active = false;
                activeSlotIndex = value < 0 ? size - 1 : value % Size;
                slots[activeSlotIndex].Active = true;
            }
        }


        void Awake()
        {
            if (size > 0)
            {
                slots[0].Active = true;
            }
        }

        void OnValidate()
        {
            // Editor only
         //   AdjustSize();
        }

        void AdjustSize()
        {
            slots ??= new List<InventorySlot>();
            // if slots list is bigger than size remove extra items
            if (slots.Count > size) slots.RemoveRange(size, slots.Count - size);
            // if slots list is smaller than size fill the list with extra items
            if (slots.Count < size) slots.AddRange(new InventorySlot[size - slots.Count]);
        }

        public bool IsFull()
        {
            return slots.Count(slot => slot.HasItem) >= size;
        }

        public bool CanAcceptItem(ItemStack itemStack)
        {
            InventorySlot openSlotWithThisItem = FindSlot(itemStack.Item);
            return openSlotWithThisItem != null || !IsFull();
        }

        public InventorySlot FindSlot(ItemDefinition item)
        {

            return slots.FirstOrDefault(slot => slot.Item == item);
        }

        public bool HasItem(ItemStack itemStack, bool checkNumberOfItems = false)
        {
            InventorySlot itemSlot = FindSlot(itemStack.Item);
            if (itemSlot == null) return false;
            if (checkNumberOfItems)
            {
                return itemSlot.NumberOfItems >= itemStack.NumberOfItems;
            }
            return true;
        }
        public ItemStack AddItem(ItemStack itemStack)
        {
            InventorySlot relevantSlot = FindSlot(itemStack.Item);
            if (IsFull() && relevantSlot == null)
            {
                throw new InventoryException(InventoryOperation.ADD, "Inventory is Full");
            }

            if (relevantSlot != null)
            {
                relevantSlot.NumberOfItems++;
            }
            else
            {
                relevantSlot = slots.First(slot => !slot.HasItem);
                relevantSlot.State = itemStack;

            }
            return relevantSlot.State;
        }



        public  ItemStack RemoveItem(int atIndex)
        {
            if (!slots[atIndex].HasItem)
                throw new InventoryException(InventoryOperation.REMOVE, "Slot is Empty");
            ItemStack newItemStack = new ItemStack(slots[atIndex].State.Item, slots[atIndex].State.NumberOfItems,
                slots[atIndex].State.Price);
            ClearSlot(atIndex);
            return newItemStack;
        }

        public ItemStack RemoveItem(ItemStack itemStack)
        {
            InventorySlot itemSlot = FindSlot(itemStack.Item);
            if (itemSlot == null)
                throw new InventoryException(InventoryOperation.REMOVE, "No Such Item in The Inventory");
            if (itemSlot.NumberOfItems < itemStack.NumberOfItems)
                throw new InventoryException(InventoryOperation.REMOVE, "Not Enough Items");

            itemSlot.NumberOfItems--;
            if (itemSlot.NumberOfItems > 0)
            {
                return itemSlot.State;
            }
            itemSlot.Clear();
            return new ItemStack();
        }


        public void ClearSlot(int atIndex)
        {
            slots[atIndex].Clear();
          
        }

        public void ActivateSlot(int atIndex)
        {
            ActiveSlotIndex = atIndex;
        }

        public InventorySlot GetActiveSlot()
        {
            return slots[ActiveSlotIndex];
        }
    }
}