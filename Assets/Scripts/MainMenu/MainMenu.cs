using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{ 

    public void PlayGame(string startScene = "LibraryInside") //To start the game from the main menu.
    {
        SceneManager.LoadSceneAsync(startScene); //Pressing play loads the Library Inside scene.
    }

    public void QuitGame() //To quit the game from the main menu.
    {
        Application.Quit(); //Pressing quit summons the quit-function.
    }
}


