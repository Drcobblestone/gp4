using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance; //This allows us to access the scene-controller from anywhere.

    private void Awake()
    {
        if (instance == null) //Objects with this script must not be destroyed.
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //Don't destroy the instance of this object if it has the script.
        }
        else
        {
            Destroy(gameObject); //But if the new scene has this object, then destroy this object.
        }
    }

    public void NextLevel() //We will now load the next level.
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadScene(string sceneName) //The next level will have this name, which is generic and depends on where we want to go.
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}
