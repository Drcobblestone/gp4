using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script contains our implementation of what we want 

public class LLSingleton : GenericSingletonClass<LLSingleton>
{
    
    public InventoryUI inventoryUI;
    public override void Awake()
    {
        base.Awake();
        
        inventoryUI = GetComponentInChildren<InventoryUI>();
    }

}
