using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEntry : MonoBehaviour
{
    [SerializeField] SceneData data;
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform[] entryPoints; //We create an array of entry-points within a scene.

    // Start is called before the first frame update
    void Start()
    {
        if (data.entryIndex == -1) //If we start the game, we will get this error, which will tell us that we have reset the entryindex.
        {
            Debug.LogError("Custom Error SceneEntry: Entry Index was not valid.");
            return;
        }

        playerTransform.position = entryPoints[data.entryIndex].position; //This will tell us which entrypoint the player is using, and where it is.
    }
}
