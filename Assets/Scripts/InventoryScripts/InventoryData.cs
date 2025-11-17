using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryData", menuName = "Inventory/InventoryData", order = 1)]
public class InventoryData : ScriptableObject
{
    public Dictionary<ItemID, ItemData> inventoryItems = new Dictionary<ItemID, ItemData>();
    public void AddItem(ItemData itemData)
    {
        inventoryItems.Add(itemData.id, itemData);
    }

    public void RemoveItem(ItemID inventoryId) 
    {
        inventoryItems.Remove(inventoryId);
    }

    public ItemData GetItem(ItemID inventoryId, bool removeAlso = false) //removeAlso is an optional parameter that defaults to false
    {
        ItemData itemData = inventoryItems[inventoryId];
        if (removeAlso)
        {
            RemoveItem(inventoryId);   
        }
        return itemData;
    }
    public ItemData GetCurrentItem(bool removeAlso = false) //This just drops current item without needing any unique ID.
    {
        foreach (ItemID oldItemID in inventoryItems.Keys)
        {
            return GetItem(oldItemID, removeAlso);
        }
        return null;
        
    }

}
