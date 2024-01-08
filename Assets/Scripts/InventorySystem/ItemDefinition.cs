using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu(menuName = "Inventory/Item Definition", fileName = "New Item Definition")]
    public class ItemDefinition : ScriptableObject
    {
        [SerializeField]
        string _name;
        [SerializeField]
        Sprite sprite;

        public string Name => _name;
        public Sprite Sprite => sprite;

    }
}