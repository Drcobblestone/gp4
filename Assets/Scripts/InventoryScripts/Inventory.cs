using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Collider2D))]

public class Inventory : MonoBehaviour
{   
    public static Inventory Instance;
    [Header("References")]
    InventoryUI ui; 

    [Header("Prefabs")]
    [SerializeField] GameObject droppedItemPrefab; //The player will be able to drop a prefab, irregardless of which item it is.

    [Header("Audio Clips")] //This lets us put different sounds for when picking up an item, and for when dropping an item.

    [Header("State")]
    [SerializeField] InventoryData inventoryData;
    bool canPickUp = true;
    float pickupDelay = 0.1f;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {   
        ui = LLSingleton.Instance.inventoryUI; //Start every scene with getting the right reference into the singleton.
    }
    public void OnTriggerEnter2D(Collider2D other) //Every time the player enters a trigger we compare its tag.
    {
        if (other.CompareTag("DroppedItem")) //If the item we touched has the tag DroppedItem...
        {

            DroppedItem pickedItem = other.GetComponent<DroppedItem>(); //...We get the component "dropped item" from the collider we just bumped into.
   
            if (!pickedItem.canBePickedUp) //We check if we have already picked up the item.
            {
                return; //If we cannot, we don't pick it up, but go back instead.
            }

            AddItem(pickedItem);
            pickedItem.PickUp();
        }
    }

    void AddItem (DroppedItem pickedItem)  //When picking up a new item in inventory...
    {
        StartCoroutine(AddAndDropCurrent(pickedItem));
    }
    public void DropItem(ItemID inventoryId) //This overload helps us drop items where the player is, without touching another item, and exchanging pos.
    {
        DropItem(inventoryId, transform.position);
    }
    public void DropItem(ItemID inventoryId, Vector2 dropPosition) //This creates a new dropped item Prefab, and initializes it with the dropped item data.
    {
        Item item = inventoryData.GetItem(inventoryId);
        DroppedItem droppedItem = Instantiate(item.prefab, dropPosition, Quaternion.identity).GetComponent<DroppedItem>();


        droppedItem.Initialize(item);
        inventoryData.RemoveItem(inventoryId);
        ui.RemoveUIItem(inventoryId); //The dropped item disappears from the UI.
    }
    IEnumerator AddAndDropCurrent(DroppedItem pickedItem)
    {
        Item currentItem = inventoryData.GetCurrentItem();
        if (currentItem != null) //...we check If the current item in inventory isn't null, and if it isn't...
        {
            DropItem(currentItem.id, pickedItem.transform.position); //...then we drop that item
        }
        yield return null;
        Item item = pickedItem.item;
        inventoryData.AddItem(item); //And add a new item.
        ui.AddUIItem(item.id, item);
    }

}
