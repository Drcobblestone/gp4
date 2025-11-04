using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class HideUI : MonoBehaviour
{
    [SerializeField] private GameObject canvasInventory; //A field where we put our entire CanvasInventory object inside, so this script can make it invisible.
    [SerializeField] private InputActionReference visibleUi; //We get the VisibleUi-action from the input action asset - so that we can use it to make canvas invisible.

    //gameObject.GetComponent<CanvasRenderer>().cull = false; <-- Use this to only make the canvas invisible.


    public void ToggleVisibility() //This function controls if the inventory is visible.
    {
        canvasInventory.SetActive(!canvasInventory.activeInHierarchy);
        /*if (visibleUi != null) //If we haven't made the UI inactive & invisible by pressing the button/performing the action...
            canvasInventory.SetActive(!canvasInventory.activeInHierarchy); //<-- Then we make it active and visible.

        else if (visibleUi == null) //But if we have made it inactive and invisible...
            canvasInventory.SetActive(canvasInventory.activeInHierarchy); //Then we make it inactive and invisible.
        */
    }
    
    public void OnEnable()
    {
        visibleUi.action.Enable(); //When we enable the Cancel-action...
        visibleUi.action.performed += ctx => ToggleVisibility(); //...Then we make the canvas invisible.
    }
}
