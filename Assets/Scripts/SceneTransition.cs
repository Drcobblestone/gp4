using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Level1Exit : MonoBehaviour
{
    [SerializeField] GameObject keyPress;
    bool canPress;

    //We put the scene in this field, where we want to teleport to.
    [SerializeField] SceneManager scene;

    void Start()
    {
        keyPress.SetActive(false);
        canPress = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //Checks if the player enters the collider
        {
            Debug.Log("Player has entered transition");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) 
        if (collision.gameObject.tag == ("Player")) //Checks if the player leaves the collider
        {
            Debug.Log("Player is exiting.");
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && canPress == true)
        {
            SceneManager.LoadScene("Level2");
        }
    }
}
