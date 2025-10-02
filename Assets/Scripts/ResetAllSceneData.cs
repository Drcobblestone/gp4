using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResetAllSceneData : MonoBehaviour
{
    [SerializeField] SceneData[] datas;
    void Awake()
    {
        foreach (SceneData data in datas) //For each scene we have, then...
        {
            data.Reset(); //...reset it, in-between runs.
        }
        Destroy(gameObject); //And destroy this reset-object, after the deed is done.
    }
}
