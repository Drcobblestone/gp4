using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryData", menuName = "Inventory/InventoryData", order = 1)]
public class InventoryData : ScriptableObject
{
    public Dictionary<ItemID, Item> inventoryItems = new Dictionary<ItemID, Item>();
    public void AddItem(Item item)
    {
        inventoryItems.Add(item.id, item);
    }

    public void RemoveItem(ItemID inventoryId) 
    {
        inventoryItems.Remove(inventoryId);
    }

    public Item GetItem(ItemID inventoryId, bool removeAlso = false) //removeAlso is an optional parameter that defaults to false
    {
        Item item = inventoryItems[inventoryId];
        if (removeAlso)
        {
            RemoveItem(inventoryId);   
        }
        return item;
    }
    public Item GetCurrentItem(bool removeAlso = false) //This just drops current item without needing any unique ID.
    {
        foreach (ItemID oldItemID in inventoryItems.Keys)
        {
            return GetItem(oldItemID, removeAlso);
        }
        return null;
        
    }

}
