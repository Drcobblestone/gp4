using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class HideUI : MonoBehaviour
{
    [SerializeField] private GameObject canvasInventory; //A field where we put our entire CanvasInventory object inside, so this script can make it invisible.
    [SerializeField] private InputActionReference visibleUi; //We get the VisibleUi-action from the input action asset - so that we can use it to make canvas invisible.

    [Header("(Put the SceneData here.)")]
    [SerializeField] SceneData sceneData;

    
    
    public void OnEnable()
    {
        //Should I try a switch instead? Perhaps those can be reset in-between scenes, unlike this if-statement that can never RE-check itself, it seems.
        
        if (sceneData.inventoryScene == "No")
        {
            visibleUi.action.Disable();
            Logging.Log($"We disabled the inputaction to toggle Inventory-visibility, because it's not supposed to be visible.");

            canvasInventory.SetActive(false); //We make the inventory invisible.
            Logging.Log($"We turned off the inventory.");
        }

        else if (sceneData.inventoryScene == "Yes")
        {
            visibleUi.action.Enable(); //We enable the Visible-action...
            Logging.Log($"Enabled visibleUI action.");
            canvasInventory.SetActive(true); //We make the inventory visible.

            visibleUi.action.performed += ctx => ToggleVisibility(); //...Then we allow for toggling visibility through the InputAction.
            Logging.Log($"We can toggle inventory visibility");
        }
    }

    public void ToggleVisibility() //This function controls if the inventory is visible.
    {
        canvasInventory.SetActive(!canvasInventory.activeInHierarchy); //Activate the Inventory-canvas if it's not active in the hierarchy.
        Logging.Log($"Toggled the inventory's visibility.");
    }
}
