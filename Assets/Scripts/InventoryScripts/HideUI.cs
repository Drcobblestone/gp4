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

    
    public void ToggleVisibility() //This function controls if the inventory is visible.
    {
        //if (sceneData.sceneName != "MainMenu" || sceneData.sceneName != "BookClub" || sceneData.sceneName != "UIBook") //If the scene isn't called Mainmenu or BookClub, then we do this.
        //{
            canvasInventory.SetActive(!canvasInventory.activeInHierarchy); //Activate the Inventory-canvas if it's not active in the hierarchy.
            Logging.Log($"Turned on the Inventory.");
        //}
        /*
        else
        {
            return;
        }
        */
    }
    

    
    public void OnEnable()
    {
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
            visibleUi.action.performed += ctx => ToggleVisibility(); //...Then we make the canvas invisible.
            Logging.Log($"We toggled inventory visibility.");
        }
    }
    

    /*
    public void Awake() //This function controls if the inventory is visible.
    {
        ToggleVisibility(); //We start the co-routine for controlling inventory visibility.
        Logging.Log($"We started togglevisibility co-routine.");
    }

    IEnumerator ToggleVisibility()
    {
        Logging.Log($"Toggle-vis running.");
        if (sceneData.inventoryScene == "No") //If it's a scene meant to have an inventory, then we do this.
        {
            canvasInventory.SetActive(false); //De-Activate the Inventory-canvas if it's not meant to be active.
            Logging.Log($"Turned off the Inventory.");
            yield break;
        }
        else if (sceneData.inventoryScene == "Yes") //Otherwise we do this.
        {
            canvasInventory.SetActive(true); //Re-Activate the Inventory-canvas if it's not active in the hierarchy.
            Logging.Log($"We turned on the inventory.");
            yield break;
        }
    }
 
    /*
    public void VisibilityAction()
    {
        visibleUi.action.Enable();
        Logging.Log($"We enabled the visibleui ACTION.");
        visibleUi.action.performed += ctx => ToggleVisibility(); //...Then we make the canvas invisible.
        Logging.Log($"We made the inventory invisible.");
    }
    */
}
