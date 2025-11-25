using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class FootStepSounds : MonoBehaviour
{

    [SerializeField] PlayerController playerController;

    public AudioSource footStepSound;

    private bool playingFootSteps = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    void Update()
    {
        /* //Doesn't work!! Fuck my life!
        if (playerController.rb.velocity != null) //We access the rigidbody in the playercontroller, and check if it's velocity is zero or not. (is it moving)
        {
            if(playingFootSteps == true)
            {
                return;
            }
            
            footStepSound.Play(); //If the rigid-body is accelerating (we're moving), then we play footsteps.
            playingFootSteps = true;

            Debug.Log("Footsteps playing.");
        }

        else if (playerController.rb.velocity == null)
        {
            playingFootSteps = false;

            footStepSound.Stop(); //Otherwise we don't play footsteps.
        }
        */

        
        if (playerController.horizontal != 0.0f || playerController.vertical != 0.0f)
        {
            footStepSound.Play();
        }

        else
        {
            footStepSound.Stop();
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
