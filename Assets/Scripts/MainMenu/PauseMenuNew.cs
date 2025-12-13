using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuNew : MonoBehaviour
{
    private Leopolds_Actions _actions;//I generated a script out of the inputactionasset, and we're calling it here.
    [Header("Put the item called PauseMenu here.")]
    [SerializeField] GameObject pauseMenu; //We put the pause-menu here.
    private PlayerController player; //We get the player so we can pause him.
    private BackgroundMusic music; //We get the music so we can lower the volume.

    protected bool isPaused = false; //This helps us keep track of if the game is paused, and the pause-menu is up.



    // Awake is run immediately after the object is instantiated, and before Start or OnEnable. It's where you set up essential data or assign references for other scripts.
    void Awake()
    {
        _actions = new Leopolds_Actions(); //We make sure our _actions reference is based on the right wrapper-script.

        //player = PlayerController.Instance; //We make sure we're running the current instance of PlayerController.

        //music = LLSingleton.Instance.music; //We summon the latest instance of the Backgroundmusic script in the singleton; so we can change it's volume later.


        //_actions.UI.Cancel.performed += ctx => TogglePause(); //We make it so that when the cancel-action has been performed, it toggles Pause.
        //Logging.Log($"We have established that Cancel shall toggle Pause.");
        _actions.Gameplay.Pause.performed += ctx => OpenPauseMenu();
        _actions.Gameplay.Unpause.performed += ctx => ClosePauseMenu();
        Logging.Log($"Pause and Unpause actions can now have the right context."); 

    }

    //OnEnable runs before Start.
    private void OnEnable()
    {
        /*
        _actions.UI.Cancel.Enable(); //We enable our UI-action-map, because that's where our Cancel-action is.
        Logging.Log($"Cancel can now be run.");
        */
        _actions.Gameplay.Pause.Enable();
        _actions.Gameplay.Unpause.Enable();
        Logging.Log($"We can now pause and unpause.");



    }


    private void Start()
    {
        
        if (pauseMenu.activeInHierarchy) //If the pause-menu is already active in the hierarchy when the scene loads, then...
        {
            pauseMenu.SetActive(false); //...We turn off the pause-menu, because it's not ussually meant to be on.
            Logging.Log($"Made Pause-menu not visible to start with.");
        }
        else //otherwise, if it's not on, then...
        {
            return; //...we don't do anything.
        }
        
    }

    /*
    private void TogglePause()
    { 
        isPaused = !isPaused; //We make it so that when we toggle the cancel-action with a key-press, we invert the setting of the isPaused-bool.
        
        pauseMenu.SetActive(isPaused); //Whether the pause-menu is active is now dependent on whether the isPaused-bool is true or false. (if it's true, the pause-menu should be active)

        Time.timeScale = isPaused ? 0 : 1; //Time will go from, fully on (1), when isPaused is false (its standard state), to fully off (0), when isPaused is true.

        //music.musicSource.volume = isPaused ? 0.75f : 0.2f; //The music will go from it's standard 75% output to 20% output depending on the state of isPaused.

        //player.movementLocked = isPaused; //We make it so that the players movementlock bool is set to whatever the isPaused bool is set to.

        Logging.Log($"We have toggled Pause {isPaused}");
    }
    */

    //----Canvas stuff
    public void ResumeGame() //When we resume the game, we will use this function in the Canvas.
    {
        //TogglePause(); //We run the togglePause function, and it will turn off the pause-menu again. |Old, trying something new.
        ClosePauseMenu();

    }

    public void BacktoMain() //When we click "Go back to main menu" in the canvas, we will use this.
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    //----Canvas end.

    private void OpenPauseMenu()
    {
        if (isPaused) return; //GUARD-clause -- we want to prevent double-open/closes.

        isPaused = true; //If the pause-menu is open, then isPaused should be true.

        pauseMenu.SetActive(true); //We make sure the pauseMenu is visible.

        Time.timeScale = 0f; //We freeze time.

        //music.musicSource.volume = 0.2f;

    }

    private void ClosePauseMenu()
    {
        if (!isPaused) return; //GUARD-clause -- we want to prevent double-open/closes.

        isPaused = false; //If the pause-menu is closed, then isPaused should be false.

        pauseMenu.SetActive(false); //We make sure the pauseMenu is NOT visible.

        Time.timeScale = 1f; //We UN-freeze time.

        //music.musicSource.volume = 0.75f; //We turn the music-volume up to its regular level.

    }




    //OnDisable is run last, when all other things are completed.
    private void OnDisable()
    {
        //_actions.UI.Cancel.Disable(); //We disable our Cancel-action, instead of disabling the whole UI-actions. Not sure why, but it might be useful.
        //_actions.UI.Cancel.performed -= ctx => TogglePause(); //We unsubscribe to the cancel-action and toggle off the pause.
        //Logging.Log($"Cancel no longer toggles Pause.");
        _actions.Gameplay.Pause.performed -= ctx => OpenPauseMenu();
        _actions.Gameplay.Unpause.performed -= ctx => ClosePauseMenu();
        Logging.Log($"We are no longer using Pause and Unpause.");
    }

}
