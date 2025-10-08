using UnityEngine;

[CreateAssetMenu (fileName = "Item", menuName = "Inventory/Item", order  = 1)] //This creates a new type of Unity-item we can create from the contextmenu.

public class Item : ScriptableObject //By inheriting from scriptableobjects we can create different items.
{
    public ItemID id; //Let's us assign one of the itemid's we have in the GameEnums script.
    public string description; //Sadly we can't use name, as that is an inherited property too, but this is just a name.
    public Sprite icon; //This is an actual sprite/texture that's going to be visible in the UI.
    public GameObject prefab; //This prefab will be instantiated into the gameworld.
}
