using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Collider2D))]

public class Inventory : MonoBehaviour
{   
    public static Inventory Instance;
    public event Action OnInventoryChanged; //Event to notify the quest-system that we have something new in inventory.

    [Header("References")]
    InventoryUI ui; 

    [Header("Prefabs")]
    [SerializeField] GameObject droppedItemPrefab; //The player will be able to drop a prefab, irregardless of which item it is.

    [Header("Audio Clips")] //This lets us put different sounds for when picking up an item, and for when dropping an item.
    //It's bugged though, so we turned it off. Unity's Audio-system is mega-slow.

    [Header("State - put InventoryData here")]
    [SerializeField] InventoryData inventoryData;
    public Dictionary<ItemID, ItemData> inventoryDictionary; //We'll create a new dictionary that's going to just be our old dictionary in InventoryData.



    bool canPickUp = true;
    float pickupDelay = 0.1f;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {   
        ui = LLSingleton.Instance.inventoryUI; //Start every scene with getting the right reference into the singleton.

        //Accessing the dictionary in InventoryData, we rename it to a Dictionary.
        inventoryDictionary = inventoryData.inventoryItems; //I will attempt to move this to a later function.

        if (inventoryData !=null)
        {
            Logging.Log($"The current contents in the InventoryDictionary is: " + inventoryData.inventoryItems);
            //How the frack do I get it to show me what's currently in the inventory??
        }
        else
        {
            Logging.LogWarning($"Inventory-controller is not getting the dictionary from InventoryData!");
        }
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
        DroppedItem droppedItem = SpawnInventoryItem(inventoryId, dropPosition);
        GameManager.Instance.DropItem(droppedItem);
        //REMOVE FROM SCENE DATA IF ITEM GETS PICKED UP
        inventoryData.RemoveItem(inventoryId);
        ui.RemoveUIItem(inventoryId); //The dropped item disappears from the UI.
    }
    public DroppedItem SpawnInventoryItem(ItemID inventoryId, Vector2 dropPosition) //This spawns and returns the spawned item so we can use it in another function / script
    {
        ItemData itemData = inventoryData.GetItem(inventoryId);
        DroppedItem droppedItem = Instantiate(itemData.prefab, dropPosition, Quaternion.identity).GetComponent<DroppedItem>();
        droppedItem.Initialize(itemData);
        return droppedItem;
    }
    IEnumerator AddAndDropCurrent(DroppedItem pickedItem)
    {
        ItemData currentItem = inventoryData.GetCurrentItem();
        if (currentItem != null) //...we check If the current item in inventory isn't null, and if it isn't...
        {
            DropItem(currentItem.id, pickedItem.transform.position); //...then we drop that item
        }
        yield return null;
        ItemData itemData = pickedItem.itemData;
        inventoryData.AddItem(itemData); //And add a new item.
        ui.AddUIItem(itemData.id, itemData);
    }

    //Check if the inventory has changed, so we can tell the Quest-system.
    public void CheckInventory()
    {
        OnInventoryChanged?.Invoke(); //Can I put a debug here, to see that it's checked the inventory?
    }
    public ItemData TryPopItem(ItemID id) //Pop is getting and removing from the list at the same time
    {
        ItemData item = inventoryData.GetItem(id, true);
        if (item != null)
        {
            ui.RemoveUIItem(id);
        }
        return item;
    }

    //--------------------
    //This is for destroying the inventory-items if we finish a quest, since we don't want them around after that.
    public void RemoveItem (ItemID inventoryId)
    {
        inventoryData.RemoveItem(inventoryId);
        ui.RemoveUIItem(inventoryId);
        //May not be needed, since the tutorial once more mentions amounts to remove - i.e if you have to give 5 bottles, but you have 10.
        /*foreach (Transform activeItem in inventoryPanel.transform) //Which transform? The one that shows up in Inventory, right? Do I need a serializefield to get this reference from ItemUI? Or possibly from the UiItemPrefab -prefab?
        {
            if (itemToRemove <=0) break; //If there's nothing to remove from inventory, then break and don't run the rest of the code.

            //This might be borked, since the Tutorial uses a MonoScript as "item" and I use a Scriptable Object as Item. On 2025-11-17 I renamed "Item" to "ItemData" to clarify what the script is.
            /*
            if (activeItem?.currentItem?.GetComponent<ItemController>() is ItemController itemController && itemController.ID == itemID) //Do we have a current item in our inventory/Slot? If so, we will grab it out by checking if it's an actual item and if it matches the ItemID we said the item from the completed objective/quest has.
            {
                //This might be empty too, since it's a bunch of quantity and stacked.
                //A function called "RemoveFromInventory" (aka RemoveFromStack) in Item.cs (which I sadly now know is ItemController.cs) might be cool though. Consider going back to an older Tutorial, to add the functionality.
                

            }
            */
    }

}
    //-------------------
    //Original Tutorial-function, that won't work, because we don't use multiples of an item, and we don't stack them.
    /*
    public void RemoveItemsFromInventory(int itemID, int amountToRemove)
    {
        foreach (Transform slotTransform in inventoryPanel.transform)
        {
            if (amountToRemove  <=0) break;

            Slot slot = slotTransform.GetComponent<Slot>(); //Slot does not exist as a script in our project.
            if (slot?.currentItem?.GetComponent<ItemController>()) is ItemController itemController && itemController.ID == itemID)
            {
                int removed = Mathf.Min(amountToRemove, ItemController.quantity);
                ItemController.RemoveFromStack(removed);
                amountToRemove -= removed;

                if(itemController.quantity == 0)
                {
                    Destroy(slot.currentItem);
                    slot.currentItem = null;
                }
            }
        }
    }
    */
    

