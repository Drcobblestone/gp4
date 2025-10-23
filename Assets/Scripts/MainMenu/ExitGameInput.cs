using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class ExitGameInput : MonoBehaviour
{
    //Old idea, does not work...
    //private bool canCel; //We create an Integer that we can assign the value from 'UI/Cancel' in our Input Action Asset.

    /*
    public void Cancel(InputAction.CallbackContext context) //We summon the cancel-function from the new input-system.
    {
        canCel = context.ReadValueAsButton<>();
        
    }
    */

    [SerializeField] private InputAction cancelAction; //We get the cancel-action from the input action asset - we're going to use that to Quit.

    private void OnEnable()
    {
        cancelAction.Enable(); //When we enable the Cancel-action...
        cancelAction.performed += ctx => Application.Quit(); //...Then we quit the game.
    }

    private void OnDisable()
    {
        cancelAction.Disable(); //We turn off the ability to quit the game with the Cancel-action - when we don't need it.
    }



    /* //Old idea, doesn't work.
    void FixedUpdate()
    {
        //if (Cancel.current != null && Cancel.current.escapeKey.wasPressedThisFrame)
        //if (Input.GetKeyDown(KeyCode.Escape))    
        {
            Application.Quit();
        }
    }
    */
}
