using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Collider2D))]

public class Inventory : MonoBehaviour
{
    [Header("References")]
    [SerializeField] InventoryUI ui; //Where is this class then?? Which library?
    [SerializeField] AudioSource audioSource;

    [Header("Prefabs")]
    [SerializeField] GameObject droppedItemPrefab; //The player will be able to drop a prefab, irregardless of which item it is.

    [Header("Audio Clips")] //This lets us put different sounds for when picking up an item, and for when dropping an item.
    [SerializeField] AudioClip pickUpItemAudio;
    [SerializeField] AudioClip dropItemAudio;

    //Probably gonna' turn dictionary off.
    [Header("State")]
    [SerializeField]
    SerializedDictionary<string, Item> inventory = new();

    public void OnTriggerEnter2D(Collider2D other) //Every time the player enters a trigger we compare its tag.
    {
        if (other.CompareTag("DroppedItem")) //If the item we touched has the tag DroppedItem...
        {
            var droppedItem = other.GetComponent<DroppedItem>(); //...We get the component "dropped item" from the collider we just bumped into.
            //Cringe, rewrite. | Curious... droppeditem is not a Unity-component?

            // DroppedItem droppedItem = other.GetComponent<DroppedItem>(); //This is the proper rewrite.. but droppeditem is not a unity component. 


            if (droppedItem.pickedUp) //We check if we have already picked up the item.
            {
                return; //If we have, we don't pick it up, but go back instead.
            }
            droppedItem.pickedUp = true; //If the item is equal to dropped item, we get the component "droppedItem" from the collider.
            AddItem(droppedItem.item); 
            Destroy(other.gameObject); //We destroy the object within the game-world, since we have now picked it up and put it in our inventory instead.
            audioSource.PlayOneShot(pickUpItemAudio); //We play a little jingle when we have picked up the item.
        }
    }

    void AddItem (Item item)  //When adding a new item to inventory we generate...
    {
        var inventoryId = Guid.NewGuid().ToString(); //...a new itemId - this allows us to have more than one of the same itemtype in our inventory, without having conflicting ID's.
        inventory.Add(inventoryId, item);
        ui.AddUIItem(inventoryId, item); //
    }

    public void DropItem(string inventoryId) //This creates a new dropped item Prefab, and initializes it with the dropped item data.
    {
        var droppedItem = Instantiate(droppedItemPrefab, transform.position, Quaternion.identity).GetComponent<DroppedItem>(); //WAI it no like?? Btw, var's are cringe.
        var item = inventory.GetValueOrDefault(inventoryId); //Still cringe, rewrite.
        droppedItem.Initialize(item);
        inventory.Remove(inventoryId);
        ui.RemoveUIItem(inventoryId); //The dropped item disappears from the UI.
        audioSource.PlayOneShot(dropItemAudio); //And a final little jingle so we can hear we dropped the item.
    }

}
