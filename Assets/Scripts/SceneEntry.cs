using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEntry : MonoBehaviour
{
    [SerializeField] SceneData data;
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform[] entryPoints; //We create an array of entry-points within a scene.
    [SerializeField] SceneObject[] sceneObjects = new SceneObject[8];
    [SerializeField] DroppedItem[] itemsInScene = new DroppedItem[8];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < sceneObjects.Length; i++)
        {
            SceneObject obj = sceneObjects[i];
            int index = i; //Neccesary, i is acting like a reference somehow... Unity-devs are mooks!
            if (obj == null)
            {
                continue;
            }
            obj.flagUpdated.AddListener((bool flag) => SetFlag(index, flag));

        }
        if (data.entryIndex == -1) //If we start the game, we will get this error, which will tell us that we have reset the entryindex.
        {
            Debug.LogError("Custom Error SceneEntry: Entry Index was not valid.");
            return;
        }

        playerTransform.position = entryPoints[data.entryIndex].position; //This will tell us which entrypoint the player is using, and where it is.
    }
    public void SetFlag(int index, bool flag){
        print(index);
        data.sceneFlags[index] = flag;
    }
}
