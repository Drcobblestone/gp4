using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    //If it wasn't for the fact that I missed that the tutorial uses a Monobehaviour for "item", while I, naturally, use a Scriptable object. My Item is now ItemData - so I've put the code down below in a brand new ItemController based on Monobehaviour.

    private ItemData itemData; //We get the data-object, so we can manipulate it.
    private QuestObjective questObjective; //We get the quest-controller, since we need a bool from it.

    /*public void RemoveFromInventory() //The original uses an int, a whole number, but we don't have any god-damn counts of items, so I'm attempting a Function instead of counting.
    {
        if (itemData.pickedUp == true && questObjective.questCompleted == true) //If we have both picked the item up, and the Quest says its completed, then...
        {
            
            return removed; //Remove the item. (from existence?)
            //How the hell do I create a property/flag or thing that happens in this script, that I can then say makes an item be destroyed?
        }
    }*/
}
