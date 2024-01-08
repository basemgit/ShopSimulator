using System;
using UnityEngine;

namespace InventorySystem
{
    [Serializable]
    public class ItemStack
    {
        [SerializeField]
        ItemDefinition _item;
        [SerializeField]
        int numberOfItems;
        [SerializeField]
        float price;

        public ItemDefinition Item => _item;

        public int NumberOfItems
        {
            get => numberOfItems;
            set
            {
                value = value < 0 ? 0 : value;
                numberOfItems = value;
            }
        }
        public float Price
        {
            get => price;
            set
            {
                value = value < 0 ? 0 : value;
                price = value;

            }
        }

        public ItemStack(ItemDefinition item, int numberOfItems, float price)
        {
            _item = item;
            NumberOfItems = numberOfItems;
            Price = price;
        }

        // empty stack support
        public ItemStack() { }
    }
}