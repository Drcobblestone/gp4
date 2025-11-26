using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcEffects : MonoBehaviour
{
    [Header("Insert the animation/effect here")]
    [SerializeField] GameObject _transfEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void RemoveAnimation()
    {
        Destroy(_transfEffect);
        Debug.Log("Removing Transformation-effect.");
    }

}
