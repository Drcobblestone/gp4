using UnityEngine;

[CreateAssetMenu (fileName = "ItemData", menuName = "Inventory/ItemData", order  = 1)] //This creates a new type of Unity-item we can create from the contextmenu.


public class ItemData : ScriptableObject //By inheriting from scriptableobjects we can create different items.
{
    public ItemID id; //Let's us assign one of the itemid's we have in the GameEnums script.
    public string description; //Sadly we can't use name, as that is an inherited property too, but this is just a name.
    public Sprite icon; //This is an actual sprite/texture that's going to be visible in the UI.
    public GameObject prefab; //This prefab will be instantiated into the gameworld.
    public bool pickedUp = false;

    /*[Header("Put the book to be spawned when clickin in Inventory, here.")]
    public GameObject UIBook; //This will be instantiated when we click a book.
    */
    //This might be worthless, but could be used in removing items from inventory when handing in quest-items.
    //If it wasn't for the fact that I missed that the tutorial uses a Monoscript for "item", while I, naturally, use a Scriptable object. My Item is now ItemData - so a brand new monoscript with "itemController" might be necessary to put this in instead.
    /*
    public void RemoveFromInventory()
    {
        if (pickedUp == true && IsQuestCompleted = true)
        {

        }
    }
    */
}

//This is where we put our book-text in.
/*
[System.Serializable] //This lets us create a custom class, struct, or field that can be *saved*. (serialised)
                      //It also makes it visible in the Unity-editor. 
public class Stories //Here we define stuff to do with book-fairy-tales.
{
    [TextArea(3, 10)] //TextAreaAttribute(int minLines, int maxLines);
    [Header("If this is a book, put the book fairy-tale here.")]
    public string fairyTale;
}
*/