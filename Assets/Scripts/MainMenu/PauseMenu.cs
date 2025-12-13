using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//This script controls the pause-menu, and let's you activate it with different inputs.
public class PauseMenu : MonoBehaviour
{
    [SerializeField] InputActionReference cancelAction; //We get the cancel-action from the input action asset - we're going to use that to Quit.
    [Header("Put the item called PauseMenu here.")]
    [SerializeField] GameObject pauseMenu; //We put the pause-menu here.
    private PlayerController player; //We get the player so we can pause him.

    protected bool isPaused = false;

    private void Awake()
    {
        player = PlayerController.Instance;

        if (pauseMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(false); //We turn off the pause-menu, because it's not ussually meant to be on.
            Logging.Log($"Made Pause-menu not visible to start with.");
        }
    }



    //----Canvas stuff
    public void ResumeGame() //When we resume the game, we will use this function in the Canvas.
    {
        Time.timeScale = 1;
        //.Resume();
        isPaused = false;
        pauseMenu.SetActive(false);
        Logging.Log($"Turned off Pause-menu.");
    }

    public void BacktoMain() //When we click "Go back to main menu" in the canvas, we will use this.
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    //----Canvas end.


    void FixedUpdate()
    {
        if (!cancelAction.action.triggered) //If the player didn't press Cancel, then we don't do anything.
        {
            return;
        }

        else if (cancelAction.action.triggered) //But if we DID press cancel..!
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            //player.Pause();
            //isPaused = true;
        }
        /*
        else //Otherwise we...
        {
            ResumeGame(); //...resume the game again.
        }
        */
    }


    /*
    private void OnEnable()
    {
        cancelAction.action.Enable(); //When we enable the Cancel-action...
        Logging.Log($"We can Cancel");
        cancelAction.action.performed += ctx => isPaused = true; //...We bring up the Pause menu.

        Logging.Log($"We perform the cancel-action.");
        //player.Pause(); //We freeze the player.
    }


    private void OnDisable()
    {
        Logging.Log($"We Stopped"); //This will only be visible in-editor.
        cancelAction.action.Disable(); //We turn off the ability to quit the game with the Cancel-action - when we don't need it.
        Logging.Log($"Turning off Cancel.");
        player.Resume();
        Logging.Log($"Unfreezing the player.");

    }
    */
}
