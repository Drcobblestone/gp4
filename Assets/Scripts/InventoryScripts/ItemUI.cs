using System;
using UnityEngine;
using UnityEngine.UI;

//Each item in the user interface has an item-UI component, which is what we define here.
public class ItemUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Image image;
    [SerializeField] Button button;
    
    public void Initialize(ItemID inventoryId, Item item, Action<ItemID> removeItemAction) //When we start putting an item into the UI, we pass it the inventory-ID, and give the option to remove it.
    {
        image.sprite = item.icon;
        transform.localScale = Vector2.one;
        button.onClick.AddListener(() => removeItemAction.Invoke(inventoryId)); //When we click an item in inventory, we can tell the game to remove it.
    }
    
    void OnDestroy()
    {
        button.onClick.RemoveAllListeners(); //This tells the inventory-class to remove the item.
    }
}
