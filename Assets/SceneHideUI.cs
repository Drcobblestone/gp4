using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script is meant to be placed on a gameobject that's only present in the scenes where we turn the inventory off.

public class SceneHideUI : MonoBehaviour
{

    //[SerializeField] GameObject inGameMenu; //Field for where we insert the IngameMenu canvas.

    // Start is called before the first frame update
    void Start()
    {
        GameObject inGameMenu = LLSingleton.Instance.hideUI;
        inGameMenu.GetComponent<HideUI>().togglable = false;

        inGameMenu.SetActive(false); //Turn off ingame-menu.
        Logging.Log($"Sniped the Inventory.");
    }
}
