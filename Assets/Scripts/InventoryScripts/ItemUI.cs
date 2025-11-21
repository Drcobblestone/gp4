using System;
using UnityEngine;
using UnityEngine.UI;

//Each item in the user interface has an item-UI component, which is what we define here.
public class ItemUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Image image;
    [SerializeField] Button button;

    //Experimental Field to get access to Book-functions, if the item happens to be a book.
    //----
    [SerializeField] ItemData itemData; //We grab the books Scriptable objects, so we can use that to spawn the book associated with it.
    //----

    /*
    public void Initialize(ItemID inventoryId, ItemData itemData) //When we start putting an item into the UI, we pass it the inventory-ID, and give the option to remove it.
    {
        //This is the standard-item behaviour, but we need to change this for our special book-items.
        button.onClick.RemoveAllListeners();
        image.sprite = itemData.icon;
        button.onClick.AddListener(() => Inventory.Instance.DropItem(inventoryId)); //When we click an item in inventory, we can tell the game to remove it.
    }
    */

    //-----New experimental code for two different on-Click behaviours----
    /*
    public void Start()
    {
        itemData.UIBook = uiBook;//We turn the field UIBook in ItemData into a local thing, so we can destroy it.
    }
    */

    //Consider making removing items a dragging+release, rather than a clicking.

    public void Initialize(ItemID inventoryId, ItemData itemData) //When we start putting an item into the UI, we pass it the inventory-ID, and give the option to remove it.
    {
        //We need to separate this somehow, depending on what ItemID's we have. That, or create a choice-toggle, that determines if you drop or read.
        button.onClick.RemoveAllListeners();
        image.sprite = itemData.icon;
            switch (inventoryId)
            {
            case ItemID.BREMENBOOK:
                button.onClick.AddListener(() => Instantiate(itemData.UIBook)); //When we click the right kind of item (a book) in inventory, it spawns the book-story-prefab. (so you can read the story)
                Debug.Log("Read Bremen.");
                break;
            case ItemID.REDBOOK:
                button.onClick.AddListener(() => Instantiate(itemData.UIBook)); //
                Debug.Log("Read Riding Hood.");
                break;
            case ItemID.SNOWBOOK:
                button.onClick.AddListener(() => Instantiate(itemData.UIBook)); //
                Debug.Log("Read Snow.");
                break;
            case ItemID.FROGBOOK:
                button.onClick.AddListener(() => Instantiate(itemData.UIBook)); //
                Debug.Log("Read Frog.");
                break;


            default:
                button.onClick.AddListener(() => Inventory.Instance.DropItem(inventoryId));
                Debug.Log("Item dropped.");
                break;
            }
    }

        //Spawn an object using a string in the Book-scriptableobject, or spawn a generic one, that gets populated by data in the Book/Item scriptable object?
        //SANITY-CHECK: we already have book-prefabs that contain the stories... probably best to spawn in them.
    

//-----
    void OnDestroy()
    {
        button.onClick.RemoveAllListeners(); //This tells the inventory-class to remove the item.
    }

    //We add a function to destroy the on-screen book - for use in BookContentsrScript, via the reachedEnd event.
    protected void DestroyReadingBook()
    {
        // Destroy the Open book (which is being read)
        var readingBook = GameObject.FindWithTag("ReadingBook"); //We create a local var based on any gameobject tagged to be a book. | Vars are cringe, but I don't know how to rename it.
        Destroy(readingBook);
    }
}
