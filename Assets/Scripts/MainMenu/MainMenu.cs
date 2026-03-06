using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] ResetAllSceneData resetAllSceneData;

    public void PlayGame(string startScene = "UIBook") //To start the game from the main menu.
    {
        Time.timeScale = 1.0f;
        resetAllSceneData.resetViaGame = true;
        resetAllSceneData.NewGameReset();
        SceneManager.LoadSceneAsync(startScene); //Pressing play loads the Library Inside scene.
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


