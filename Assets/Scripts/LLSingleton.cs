using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script contains our implementation of what we want to remain active in-between scenes.

public class LLSingleton : GenericSingletonClass<LLSingleton>
{
    
    public InventoryUI inventoryUI; //We make a field for the InventoryUI
    public BackgroundMusic_Script music; //And a field for the music.
    public HideUI hideUI; //A field for the hiding of the Inventory. This is an experiment to see if it has the effect I want.

    public override void Awake() //We override regular AWake...
    {
        base.Awake();
        
        inventoryUI = GetComponentInChildren<InventoryUI>(); //When we awake, we get a sub-component from LLsingleton, and load them.
        music = GetComponentInChildren<BackgroundMusic_Script>();
        hideUI = GetComponentInChildren<HideUI>();
    }

}
