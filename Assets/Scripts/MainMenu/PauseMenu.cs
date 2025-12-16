using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private InputActionReference pause;
    [Header("Put the item called PauseMenu here.")]
    [SerializeField] GameObject pauseMenu; //We put the pause-menu here.
    private PlayerController player; //We get the player so we can pause him.
    private BackgroundMusic music; //We get the music so we can lower the volume.

    protected bool isPaused = false; //This helps us keep track of if the game is paused, and the pause-menu is up.



    // Awake is run immediately after the object is instantiated, and before Start or OnEnable. It's where you set up essential data or assign references for other scripts.



    private void Start()
    {
        player = PlayerController.Instance; //We make sure we're running the current instance of PlayerController.
        music = LLSingleton.Instance.music;
        
        pause.action.Enable();
        pause.action.performed += ctx => TogglePause(ctx); //We give our pause-action-event the context of running the TogglePause function.
        print("started");

        if (pauseMenu.activeInHierarchy) //If the pause-menu is already active in the hierarchy when the scene loads, then...
        {
            pauseMenu.SetActive(false); //...We turn off the pause-menu, because it's not ussually meant to be on.
            Logging.Log($"Made Pause-menu not visible to start with.");
        }
        else //otherwise, if it's not on, then...
        {
            Logging.Log($"No need to make pause-menu invisible.");
            return; //...we don't do anything.
        }
    }

    
    public void TogglePause(InputAction.CallbackContext context)
    {
        Logging.Log($"Ran Togglepause, but didn't set bool yet.");

        if (!context.performed)
        {
            return;
        }
        isPaused = !isPaused; //We make it so that when we toggle the cancel-action with a key-press, we invert the setting of the isPaused-bool.
        
        pauseMenu.SetActive(isPaused); //Whether the pause-menu is active is now dependent on whether the isPaused-bool is true or false. (if it's true, the pause-menu should be active)

        Time.timeScale = isPaused ? 0 : 1; //Time will go from, fully on (1), when isPaused is false (its standard state), to fully off (0), when isPaused is true.

        music.musicSource.volume = isPaused ? 0.2f : 0.75f; //The music will go from it's standard 75% output to 20% output depending on the state of isPaused.

        //player.movementLocked = isPaused; //We make it so that the players movementlock bool is set to whatever the isPaused bool is set to.

        Logging.Log($"We have toggled Pause {isPaused}");
    }
    

    //----Canvas stuff
    public void ResumeGame() //When we resume the game, we will use this function in the Canvas.
    {
        isPaused = false; //We make it so that when we toggle the cancel-action with a key-press, we invert the setting of the isPaused-bool.

        pauseMenu.SetActive(false); //Whether the pause-menu is active is now dependent on whether the isPaused-bool is true or false. (if it's true, the pause-menu should be active)

        Time.timeScale = 1.0f; //We make time start again.

        music.musicSource.volume = 0.75f; //We set the volume of the music back to its standard-setting.
        Logging.Log($"We set music back to normal.");
    }

    public void BacktoMain() //When we click "Go back to main menu" in the canvas, we will use this.
    {
        SceneManager.LoadSceneAsync("MainMenu");
        music.musicSource.volume = 0.75f; //We set the volume of the music back to its standard-setting.
        Logging.Log($"We set music back to normal from BackToMain.");
    }

    //----Canvas end.

}
