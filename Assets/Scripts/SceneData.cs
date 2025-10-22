using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SceneData", menuName = "ScriptableObjects/SceneData", order = 1)] //We create a scriptable Object, and where we want to store it.
public class SceneData : ScriptableObject
{
    public string sceneName = ""; //We can use any name for the scene in the script.
    public int entryIndex = -1; //We set the entry-point index default value to -1, so it won't work in an Array, and we can put an error-message for when we haven't assigned any point to it.

    [Header("The items the scene has when loaded.")] //Tellls us where to drop items that are meant to be in the scene.
    public bool[] sceneFlags = new bool[8]; // [X][ ][X][ ][ ][ ][ ][ ][ ][ ]
    public List<ItemToSpawn> itemsToSpawn = new List<ItemToSpawn>();   
    //public ItemID[] itemsInSceneID = new ItemID[8];
    public void Reset()
    {
        entryIndex = -1; //We reset the scene-data, so we don't end up in the wrong scene when we restart the game.
        sceneFlags = new bool[8];
    }
    
}
[System.Serializable]
public class ItemToSpawn
{
    public Item itemData;
    public Vector2 position;
}
