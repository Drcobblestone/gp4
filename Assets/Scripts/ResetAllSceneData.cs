using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResetAllSceneData : MonoBehaviour
{
    [SerializeField] bool reset = true;
    [SerializeField] SceneData[] sceneDatas;
    [SerializeField] NpcData[] npcDatas;
    [SerializeField] ShelfData shelfData;


    void Awake()
    {   
        if (!reset)
        {
            return;
        }
        foreach (SceneData data in sceneDatas) //For each scene we have, then...
        {
            data.Reset(); //...reset it, in-between runs.
        }
        foreach (NpcData data in npcDatas) //For each scene we have, then...
        {
            data.Reset(); //...reset it, in-between runs.
        }
        shelfData.Reset();

        Destroy(gameObject); //And destroy this reset-object, after the deed is done.
    }
}
