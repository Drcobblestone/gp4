using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class HideUI : MonoBehaviour
{
    [SerializeField] private GameObject canvasInventory; //A field where we put our entire CanvasInventory object inside, so this script can make it invisible.
    [SerializeField] private InputActionReference visibleUi; //We get the VisibleUi-action from the input action asset - so that we can use it to make canvas invisible.

    //[Header("(Put MainMenuCanvas here)")]
    //[SerializeField] private GameObject mainMenuCanvas ; //A field where we put our MainMenuCanvas inside, so we can add it to an if-statement, if this canvas should be active.
    [Header("(Put the SceneData here.)")]
    [SerializeField] SceneData sceneData;


    /*
    public void ToggleVisibility() //This function controls if the inventory is visible.
    {
 
        if (mainMenuCanvas == null) //If there's no mainMenuCanvas, then...
        {
            canvasInventory.SetActive(!canvasInventory.activeInHierarchy); //Activate the Inventory-canvas if it's not active in the hierarchy.
            Logging.Log($"Turned on the Inventory.");
        }
    }
    */

    //New experiment!
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





    public void OnEnable()
    {
        visibleUi.action.Enable(); //When we enable the Cancel-action...
        visibleUi.action.performed += ctx => ToggleVisibility(); //...Then we make the canvas invisible.
        Logging.Log($"We made the inventory invisible.");
    }
}
