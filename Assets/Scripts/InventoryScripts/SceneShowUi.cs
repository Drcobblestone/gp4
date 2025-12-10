using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This merely exists to let SceneHideUi do its thing.
public class SceneShowUi : MonoBehaviour
{
    //[SerializeField] GameObject inGameMenu; //Field for where we insert the IngameMenu canvas.


    private void Awake()
    {
        Logging.Log($"Awake runs in SceneShowUi."); //The script runs, but not ShowInventory. Or rather, it doesn't find its target.
        GameObject inGameMenu = GameObject.Find("IngameMenu"); //We establish a local parameter for IngameMenu(aka inventory) and base it on a search for the object in the scene.
        Logging.Log($"We found the IngameMenu.");

        if (!inGameMenu.activeInHierarchy)
        {
            inGameMenu.SetActive(true);
            Logging.Log($"We set ingameMenu active.");
        }

        else if (inGameMenu.activeInHierarchy)
        {
            
            Logging.Log($"No need to set ingameMenu active.");
        }


        else
        {
            Logging.Log($"We couldn't set it active...");
        }

        FindObjectOfType<HideUI>().gameObject.SetActive(true);
        Logging.Log($"We found and set the Inventory active.");

    }

    // Start is called before the first frame update

    private void Start()
    {
        /*
        Logging.Log($"Start runs in SceneShowUi.");
        if (!inGameMenu.activeInHierarchy)
        {
            inGameMenu.SetActive(true);
        }

        else
        {
            Logging.Log($"We couldn't find it...");
        }
        */
    }

    /*
    public void ShowInventory()
    {
        GameObject inGameMenu = GameObject.Find("IngameMenu"); //We establish a local parameter for IngameMenu(aka inventory) and base it on a search for the object in the scene.
        Logging.Log($"We found the IngameMenu.");

        if (!inGameMenu.activeInHierarchy)
        {
            inGameMenu.SetActive(true);
        }

        else
        {
            Logging.Log($"We couldn't find it...");
        }

        FindObjectOfType<HideUI>().gameObject.SetActive(true);
        Logging.Log($"We found and set the Inventory active.");
    }
    */
}

