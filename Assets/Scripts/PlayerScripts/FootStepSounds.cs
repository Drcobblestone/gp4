using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class FootStepSounds : MonoBehaviour
{

    [SerializeField] PlayerController playerController;
    [SerializeField] AudioClip footStep1;
    [SerializeField] AudioClip footStep2;
    [SerializeField] Camera mainCamera;

    //[SerializeField] AudioSource footStepSound;

    //private bool playingFootSteps = false;

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

//The below works, but I'm temporarily disabling it, to sync with animations instead.       
        /*
        if (playerController.horizontal != 0.0f || playerController.vertical != 0.0f)
        {
            footStepSound.Play();
        }

        else
        {
            footStepSound.Stop();
        }
        */



    }

    public void playFootstep1()
    {
        AudioSource.PlayClipAtPoint(footStep1, mainCamera.transform.position, 0.75f);
    }

    public void playFootstep2()
    {
        AudioSource.PlayClipAtPoint(footStep2, mainCamera.transform.position, 0.75f);
    }


}
