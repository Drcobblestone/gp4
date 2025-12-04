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

    /*
    public void ToggleVisibility() //This function controls if the inventory is visible.
    {
        if (sceneData.sceneName != "MainMenu" || sceneData.sceneName != "BookClub") //If the scene isn't called Mainmenu or BookClub, or if there's no Scene-data, then we do this.
        {
            canvasInventory.SetActive(!canvasInventory.activeInHierarchy); //Activate the Inventory-canvas if it's not active in the hierarchy.
            Logging.Log($"Turned on the Inventory.");
        }
        else
        {
            Logging.Log($"We didn't turn on the inventory.");
        }
    }
    */

    /*
    public void OnEnable()
    {
        visibleUi.action.Enable(); //When we enable the Cancel-action...
        visibleUi.action.performed += ctx => ToggleVisibility(); //...Then we make the canvas invisible.
        Logging.Log($"We made the inventory invisible.");
    }
    */

    public void Awake() //This function controls if the inventory is visible.
    {
        ToggleVisibility(); //We start the co-routine for controlling inventory visibility.
        Logging.Log($"We started togglevisibility co-routine.");
    }

    IEnumerator ToggleVisibility()
    {
        Logging.Log($"Toggle-vis running.");
        if (sceneData.inventoryScene == "Yes") //If it's a scene meant to have an inventory, then we do this.
        {
            canvasInventory.SetActive(!canvasInventory.activeInHierarchy); //Activate the Inventory-canvas if it's not active in the hierarchy.
            Logging.Log($"Turned on the Inventory.");
            yield break;
        }
        else if (sceneData.inventoryScene == "No") //Otherwise we do this.
        {
            canvasInventory.SetActive(canvasInventory.activeInHierarchy); //DE-Activate the Inventory-canvas if it's active in the hierarchy.
            Logging.Log($"We turned off the inventory.");
            yield break;
        }
    }

    public void OnEnable()
    {
        visibleUi.action.Enable();
        Logging.Log($"We enabled the visibleui ACTION.");
        visibleUi.action.performed += ctx => ToggleVisibility(); //...Then we make the canvas invisible.
        Logging.Log($"We made the inventory invisible.");

    }

}
