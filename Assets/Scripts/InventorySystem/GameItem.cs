using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class GameItem : MonoBehaviour
    {
        [SerializeField]
        ItemStack stack;

        [SerializeField]
        SpriteRenderer spriteRenderer;

        [SerializeField]
        Image image;

        [SerializeField]
        Inventory inventory;

        public ItemStack Stack => stack;

        void Awake()
        {
            inventory = inventory.GetComponent<Inventory>();
        }

        //OnValidate is Called on Editor Only
        //used to automate item properties in the editor
        void OnValidate()
        {
            SetUpGameObject();
        }
        void SetUpGameObject()
        {
            if (stack == null) return;
            SetGameSprite();
            UpdateGameObjectName();
        }

        void SetGameSprite()
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = stack.Item.Sprite;

            }

            if (image != null)
            {

                image.sprite = stack.Item.Sprite;
            }
        }

        void UpdateGameObjectName()
        {
            string name = stack.Item.Name;
            string number = stack.NumberOfItems.ToString();
            gameObject.name = $"{name} ({number})";
        }

        public ItemStack Pick()
        {
            return stack;
        }



        public void ChooseItem()
        {
            if (inventory.CanAcceptItem(stack))
            {
                inventory.AddItem(Pick());
            }
        }

    }
}