using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuNew : MonoBehaviour
{
    private Leopolds_Actions _actions;//I generated a script out of the POS inputactionasset-shit.
    [Header("Put the item called PauseMenu here.")]
    [SerializeField] GameObject pauseMenu; //We put the pause-menu here.
    private PlayerController player; //We get the player so we can pause him.

    protected bool menuUp = false;


    // Start is called before the first frame update
    void Start()
    {
        _actions = new Leopolds_Actions();
        _actions.Enable();


        player = PlayerController.Instance;
        if (pauseMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(false); //We turn off the pause-menu, because it's not ussually meant to be on.
            Logging.Log($"Made Pause-menu not visible to start with.");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!_actions.UI.Cancel.IsPressed()) //If the player didn't press Cancel, then we don't do anything.
        {
            return;
        }

        else if (_actions.UI.Cancel.IsPressed())
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            player.Pause();
            Logging.Log($"Cancel was pressed/done!");
        }

        else //Otherwise we...
        {
            ResumeGame(); //...resume the game again.
            Logging.Log($"Resuming game.");
        }

    }

    //----Canvas stuff
    public void ResumeGame() //When we resume the game, we will use this function in the Canvas.
    {
        Time.timeScale = 1;
        player.Resume();
        menuUp = false;
        pauseMenu.SetActive(false);
        Logging.Log($"Turned off Pause-menu.");
    }

    public void BacktoMain() //When we click "Go back to main menu" in the canvas, we will use this.
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    //----Canvas end.


    /*
    private void OnEnable()
    {

        _actions.UI.Get().actionTriggered += ctx => Logging.Log(ctx.action); //...We bring up the Pause menu.

        Logging.Log($"Cancel was triggered.");
        player.Pause(); //We freeze the player.
    }


    private void OnDisable()
    {
        
        player.Resume();
        Logging.Log($"Unfreezing the player.");

    }
    */

}
