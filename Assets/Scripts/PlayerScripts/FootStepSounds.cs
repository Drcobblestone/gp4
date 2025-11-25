using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (playerController.Move.) //Get the callbackcontext from playercontroller, and access the horizontal vertical, and then put it in this if.
        {
            footStepSound.enabled = true;
        }

        else
        {
            footStepSound.enabled = false;
        }
    }
}
