using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

//This script handles creating new Item-Prefabs and adding them to the scrollable and viewable content in the UI.

public class InventoryUI : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] GameObject uiItemPrefab;

    [Header("References")]

    [SerializeField] Transform uiInventoryParent;

    [Header("State")]
    [Header("SerializeField")] SerializedDictionary<ItemID, ItemUI> inventoryUI = new();
    [SerializeField] ItemUI itemUI;
    [SerializeField] InventoryData inventoryData;

    private void Start()
    {   

        Item currentItem = inventoryData.GetCurrentItem();
        if (currentItem == null) //If the current item doesn't exist...
        {
            return; //..return and start over.
        }
        AddUIItem(currentItem.id, currentItem); //Otherwise put an item in the UI.
    }
    public void AddUIItem(ItemID inventoryId, Item item) 
    {
        itemUI.gameObject.SetActive(true);
        inventoryUI.Add(inventoryId, itemUI);
        itemUI.Initialize(inventoryId, item);
    }

    public void RemoveUIItem(ItemID inventoryId)
    {
        //ItemUI itemUI = inventoryUI[inventoryId]; //
        itemUI.gameObject.SetActive(false);
        inventoryUI.Remove(inventoryId);
    }
    

}
