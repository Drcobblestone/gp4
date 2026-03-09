using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//Make a menu-item that you can press. Do it via a co-routine that starts in Awake.
//At the start of co-routine, activate game-object, and set reset-bool to true. Wait for 1 frame, then set reset-bool to false and deactivate game-object.


public class ResetAllSceneData : MonoBehaviour
{
    //[SerializeField] bool reset = false;
    private static bool resetViaEd = false;
    public bool resetViaGame = false;
    [SerializeField] SceneData[] sceneDatas;
    [SerializeField] NpcData[] npcDatas;
    [SerializeField] ShelfData shelfData;

    public static ResetAllSceneData Instance; //We turn the script into a static, since it doesn't work when you change back to the main-menu-scene!

#if UNITY_EDITOR //This will happen only inside of the Unity Editor.
    [MenuItem("RESET ALL DATA/Reset")]  // Adds a menu item named "RESET ALL DATA" to Reset in the menu bar.

    static void RunResetFunction()
    {
        UnityEditor.EditorApplication.ExitPlaymode();
        UnityEditor.EditorApplication.EnterPlaymode(); //And then we run the editor, so the rest of the script runs.
        resetViaEd = true; //We say that we're going to reset stuff.
    }
#endif


    public void Awake()
    {
        Instance = this;

        if (resetViaEd) //If the reset has been hit, then...
        {
            StartCoroutine(ResetData()); //...run the resetdata-co-routine.
            Logging.Log($"Starting ResetData co-routine.");
        }
        else 
        {
            Logging.Log($"Not resetting when awaking.");
        }
    }

    public void NewGameReset()
    {
        if (resetViaGame) //If we said to reset via the game, then...
        {
            StartCoroutine(ResetData()); //...run the resetdata-co-routine.
            Logging.Log($"Starting ResetData co-routine.");
        }
    }

    IEnumerator ResetData()
    {
        if (resetViaEd | resetViaGame) //If we said to reset via the editor OR the game, then start the below.
        {
            foreach (SceneData data in sceneDatas) //For each scene we have, then...
            {
                data.Reset(); //...reset it, in-between runs.
            }
            foreach (NpcData data in npcDatas) //For each scene we have, then...
            {
                data.Reset(); //...reset it, in-between runs.
            }
            shelfData.Reset();
            //Before we stop the co-routine, we set our bools back to default, i.e not true.
            resetViaEd = false;
            resetViaGame = false;
            Logging.Log($"Finished Resetting Data.");
            yield break; //Stop the co-routine after doing the above.
        }
    }
}
