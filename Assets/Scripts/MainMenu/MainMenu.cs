using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Reset for New Game, put ResetAllSceneData here")]
    [SerializeField] ResetAllSceneData resetAllSceneData;

    private void Awake()
    {
        if (resetAllSceneData != null)
        {
            Logging.Log($"ResetAllSceneData can be referenced by MainMenu.");
            resetAllSceneData = ResetAllSceneData.Instance.GetComponent<ResetAllSceneData>(); //Make sure we are using the latest instance of ResetAllSceneData.  
        }
        else if (resetAllSceneData == null)
        {
            resetAllSceneData = GameObject.FindWithTag("ResetData").GetComponent<ResetAllSceneData>();
            Logging.Log($"Had to remake the resetAllSceneData reference in MainMenu.");
        } 
    }

    public void PlayGame(string startScene = "UIBook") //To start the game from the main menu.
    {
        Time.timeScale = 1.0f;
        resetAllSceneData.resetViaGame = true; //We set the bool in ResetAllSceneData that we want to reset via in-game.
        resetAllSceneData.NewGameReset(); //Why does this not work? Awake says we HAVE the reference...! Even when loaded back and forth from scenes.
        SceneManager.LoadSceneAsync(startScene); //Pressing Start loads the first in-game scene, or the Book-intro scene.
    }

    public void ReturnGame()
    {
        //Add code to just go back to your last scene and place, here.
    }


    public void QuitGame() //To quit the game from the main menu.
    {
#if UNITY_EDITOR //This will happen only inside of the Unity Editor.
        EditorApplication.ExitPlaymode(); //stop playing.
#endif
        Application.Quit(); //Pressing quit summons the quit-function.
    }
}


