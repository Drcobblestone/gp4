using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResetAllQuestData : MonoBehaviour
{
    [SerializeField] bool reset = true;
    [SerializeField] QuestData[] datas;
    
    void Awake()
    {   
        if (!reset)
        {
            return;
        }
        foreach (QuestData data in datas) //For each scene we have, then...
        {
            data.ResetList(); //...reset it, in-between runs.
            //data.ResetBool();
        }
        Destroy(gameObject); //And destroy this reset-object, after the deed is done.
    }
}
