using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{ 

    public void PlayGame(string startScene = "LibraryInside") //To start the game from the main menu.
    {
        SceneManager.LoadSceneAsync(startScene); //Pressing play loads the Library Inside scene.
    }

    public void ReturnGame()
    {

    }


    public void QuitGame() //To quit the game from the main menu.
    {
#if UNITY_EDITOR //This will happen only inside of the Unity Editor.
        EditorApplication.ExitPlaymode(); //stop playing.
#endif
        Application.Quit(); //Pressing quit summons the quit-function.
    }
}


