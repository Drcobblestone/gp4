using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStartMusic : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] bool standardMusic = true;
    void Start()
    {
        LLSingleton.Instance.music.ChangeMusic(standardMusic);
    }


}
