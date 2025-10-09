using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

//This script handles creating new Item-Prefabs and adding them to the scrollable and viewable content in the UI.

public class InventoryUI : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] GameObject uiItemPrefab;

    [Header("References")]
    [SerializeField] Inventory inventory;
    [SerializeField] Transform uiInventoryParent;

    [Header("State")]
    [Header("SerializeField")] SerializedDictionary<ItemID, ItemUI> inventoryUI = new();


    //When adding a new item to the UI-inventory...
    public void AddUIItem(ItemID inventoryId, Item item) 
    {
        ItemUI itemUI = Instantiate(uiItemPrefab).GetComponent<ItemUI>(); //...we create a new instance from the prefab... ||fix the var, darnit!
        itemUI.transform.SetParent(uiInventoryParent); //... and set the parent of the new item to be the scroll-view.
        inventoryUI.Add(inventoryId, itemUI);
        itemUI.Initialize(inventoryId, item, inventory.DropItem);
    }

    public void RemoveUIItem(ItemID inventoryId)
    {
        ItemUI itemUI = inventoryUI[inventoryId]; //
        inventoryUI.Remove(inventoryId);
        Destroy(itemUI.gameObject);
    }


}
