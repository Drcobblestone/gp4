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
    [SerializeField] GameObject pauseMenu; //We put the pause-menu here.
    PlayerController player; //We get the player so we can pause him.

    protected bool menuUp = false;

    /*
    private void OnEnable()
    {
        cancelAction.action.Enable(); //When we enable the Cancel-action...
        Logging.Log($"We can Cancel");
        cancelAction.action.performed += ctx => menuUp = true; //...Then we quit the game.
    }
    */

    private void Start()
    {
        pauseMenu.SetActive(false); //We turn off the pause-menu, because it's not ussually meant to be on.
    }

    public void ResumeGame() //When we resume the game, we will use this function in the Canvas.
    {
        Time.timeScale = 1;
        player.Resume();
        menuUp = false;
        pauseMenu.SetActive(false);
    }

    void FixedUpdate()
    {
        if (!cancelAction.action.triggered) //If the player didn't press Cancel, then we don't do anything.
        {
            return;
        }
        if (menuUp == false)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            player.Pause();
            menuUp = true;
        }
        else //Otherwise we...
        {
            ResumeGame(); //...resume the game again.
        }
    }




    /*
    private void OnEnable()
    {
        cancelAction.action.Enable(); //When we enable the Cancel-action...
        Logging.Log($"We can Cancel");
        string menuScene = "MainMenu"; //we create a string that refers to the scene with our main Menu.
        cancelAction.action.performed += ctx => SceneManager.LoadSceneAsync(menuScene); //...Then we quit the game.

        //cancelAction.action.performed += ctx => EditorApplication.ExitPlaymode();
    }

    private void OnDisable()
    {
        Logging.Log($"We Stopped"); //This will only be visible in-editor.
        cancelAction.action.Disable(); //We turn off the ability to quit the game with the Cancel-action - when we don't need it.
        Logging.Log($"Turning off Cancel.");
    }
    */
}
