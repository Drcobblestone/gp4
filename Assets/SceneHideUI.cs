using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHideUI : MonoBehaviour
{

    //[SerializeField] SceneData sceneData;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<HideUI>().gameObject.SetActive(false);
        
    }



}
