using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneZone : MonoBehaviour
{
    [Header("Data for scene we change to")] //Header to explain what the field is for.
    [SerializeField] SceneData data; //We can enter scenedata here, which we can use to control what scene and what point we go to.
    [SerializeField] int enterToIndex = -1; //This lets us set our own index.
    [SerializeField] int exitToIndex = -1;

    private void OnTriggerEnter2D(Collider2D collision) //When 'something' enters the collider, then...
    {
        print("Enter other scene");
        data.entryIndex = enterToIndex; //We use the entry-point index-value we set ourselves earlier.
        SceneManager.LoadScene(data.sceneName); //We go to the in-editor designated scene.
    }

}
