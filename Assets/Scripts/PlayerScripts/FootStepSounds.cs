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
    
    void Update()
    {
        if (playerController.rb.velocity != null) //We access the rigidbody in the playercontroller, and check if it's velocity is zero or not. (is it moving)
        {
            footStepSound.enabled = true; //If the rigid-body is accelerating (we're moving), then we play footsteps.
            Debug.Log("Footsteps playing.");
        }

        else
        {
            footStepSound.enabled = false; //Otherwise we don't play footsteps.
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
