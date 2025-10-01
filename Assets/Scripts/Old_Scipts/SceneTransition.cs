using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class Level1Exit : MonoBehaviour
{
    //We put the chosen scene in this field, where we want to teleport to.
    [SerializeField] SceneManager sceneManager;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //Checks if the player enters the collider
        {
            Debug.Log("Player has entered transition");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == ("Player")) //Checks if the player leaves the collider
        {
            Debug.Log("Player is exiting.");

        }
        else if (collision.gameObject.tag != ("Player"))
        {
            return;
        }
    }
    /*
    void Update()
    {
        if (Move(InputAction.)
        //if (Input.GetKeyDown(KeyCode.L) && canPress == true) //Change to if player moves while in collider
        {
            SceneManager.LoadScene("Level2"); //Which scene to load.
        }
        else if 
    }*/
}
