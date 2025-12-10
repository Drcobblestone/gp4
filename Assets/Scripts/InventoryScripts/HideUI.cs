using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class HideUI : MonoBehaviour
{
    [SerializeField] private GameObject canvasInventory; //A field where we put our entire CanvasInventory object inside, so this script can make it invisible.
    [SerializeField] private InputActionReference visibleUi; //We get the VisibleUi-action from the input action asset - so that we can use it to make canvas invisible.

    public bool togglable = true;

    public void OnEnable()
    {
        visibleUi.action.Enable(); //We enable the Visible-action...
        Logging.Log($"Enabled visibleUI action.");
        canvasInventory.SetActive(true); //We make the inventory visible.
        //ToggleVisibility(); //We run it once as well, so it becomes not visible.

        visibleUi.action.performed += ctx => ToggleVisibility(); //...Then we allow for toggling visibility through the InputAction.
        Logging.Log($"We can toggle inventory visibility");
    }

    public void ToggleVisibility() //This function controls if the inventory is visible.
    {
        if (!togglable) //Guard-clause.
        {
            return;
        }
        canvasInventory.SetActive(!canvasInventory.activeInHierarchy); //Activate the Inventory-canvas if it's not active in the hierarchy.
        Logging.Log($"Toggled the inventory's visibility.");
    }
}
