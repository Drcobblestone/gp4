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


    //This version doesn't work, as it gets stuck in the Singleton, and can never change to being toglable again.
    /*
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
   
        //if (sceneData.inventoryScene == "Yes")
        else if (sceneData.inventoryScene == "Yes")
        {
            visibleUi.action.Enable(); //We enable the Visible-action...
            Logging.Log($"Enabled visibleUI action.");
            canvasInventory.SetActive(true); //We make the inventory visible.

            visibleUi.action.performed += ctx => ToggleVisibility(); //...Then we allow for toggling visibility through the InputAction.
            Logging.Log($"We can toggle inventory visibility");
        }
    }
    */

    public void Awake()
    {
        //Create code that seeks out the camera if we are in a scene marked NOT-inventory and inserts it into the IngameMenu-objects Canvas/Render mode/Render Camera
    }


    public void OnEnable()
    {
            visibleUi.action.Enable(); //We enable the Visible-action...
            Logging.Log($"Enabled visibleUI action.");
            canvasInventory.SetActive(true); //We make the inventory visible.

            visibleUi.action.performed += ctx => ToggleVisibility(); //...Then we allow for toggling visibility through the InputAction.
            Logging.Log($"We can toggle inventory visibility");
    }

    public void ToggleVisibility() //This function controls if the inventory is visible.
    {
        canvasInventory.SetActive(!canvasInventory.activeInHierarchy); //Activate the Inventory-canvas if it's not active in the hierarchy.
        Logging.Log($"Toggled the inventory's visibility.");
    }
}
