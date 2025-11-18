using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDB", menuName = "Inventory/ItemDBData", order = 1)]
public class ItemDBData : ScriptableObject
{   
    [SerializeField] List<ItemInDB> itemsInDB = new List<ItemInDB>();
    Dictionary<ItemID, ItemData> db = new Dictionary<ItemID, ItemData>();

    public ItemData GetItem(ItemID inventoryId, bool removeAlso = false) //removeAlso is an optional parameter that defaults to false
    {
        foreach (ItemInDB temp in itemsInDB)
        {
            if (db.ContainsKey(temp.id))
            {
                continue;
            }
            db.Add(temp.id, temp.data);
        }
        ItemData itemData = db[inventoryId];
        return itemData;
    }


}
[System.Serializable]
public class ItemInDB
{
    public ItemID id;
    public ItemData data;
}
