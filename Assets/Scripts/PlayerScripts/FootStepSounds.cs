using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Audio : MonoBehaviour
{

    [SerializeField] PlayerController playerController;

    public AudioSource footStepSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    /*
    void Update()
    {
        if (playerController.Move.) //Get the callbackcontext from playercontroller, and access the horizontal vertical, and then put it in this if.
        {
            footStepSound.enabled = true;
        }

        else
        {
            footStepSound.enabled = false;
        }
    }
    //Below is just a reminder how I access the inputAction-system.
    /*
    public void Move(InputAction.CallbackContext context) //If the Input System gets input then we shall move.
    {
        horizontal = context.ReadValue<Vector2>().x; //We assign to the horizontal variable whether (context) we are moving left or right.
        vertical = context.ReadValue<Vector2>().y; //We assign to the vertical variable whether (context) we are moving up or down.

    }
    */

}
