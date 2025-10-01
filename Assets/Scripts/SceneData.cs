using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SceneData", menuName = "ScriptableObjects/SceneData", order = 1)] //We create a scriptable Object, and where we want to store it.
public class SceneData : ScriptableObject
{
    public string sceneName = ""; //We can use any name for the scene in the script.
    public int entryIndex = -1; //We set the entry-point index default value to -1, so it won't work in an Array, and we can put an error-message for when we haven't assigned any point to it.
}
