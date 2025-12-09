using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;

public class HandInShelf : MonoBehaviour
{
    [SerializeField] ShelfData shelfData; //We use the data from the ShelfData-object to populate the shelf with books.

    [Header("Put Tom here")] 
    [SerializeField] GameObject parentTom; //We use Tom as a condition for when you shouldn't be able to use the shelf.

    /*
    [Header("Put the shelf's collider here.")]
    [SerializeField] BoxCollider2D shelfBoxcollider; //Where we put our 

    [Header("Put the shelf's UI-script here.")]
    [SerializeField] ShelfUI shelfUI; //
   
    public GameObject shelfPanel;
    public TMP_Text shelfText;
    */


    [SerializeField] GameObject[] booksinShelf = new GameObject[4]; //




    // Start is called before the first frame update
    void Start()
    {
        //shelfText.text = ""; //This is needed because the length of dialogueText starts as 1. //If you run the game all the way from Main Menu, this causes Nullreferror.

        for (int i = 0; i < booksinShelf.Length; i++)
        {
            bool bookActive = shelfData.booksCollected[i];
            booksinShelf[i].SetActive(bookActive); //change later
        }


    }

    private void OnTriggerEnter2D(Collider2D collision) //The player enters the clickable zone.
    {
        PlayerController player = collision.GetComponent<PlayerController>(); //Finds the PlayerController, aka the Player, and put the value in there.
        print(gameObject.name + " found player");
        if (player != null) //Then we check if it really is the player...
        {
            Logging.Log($"The shelf got the player!");
            //Temporary array
            ItemID[] bookIDs = { ItemID.BREMENBOOK, ItemID.SNOWBOOK, ItemID.REDBOOK, ItemID.FROGBOOK }; //Let's us go through the handed in books.
            for (int i = 0; i < bookIDs.Length; i++) //lowercase i usually implies a temporary integer.
            {
                ItemData itemTemp = Inventory.Instance.TryPopItem(bookIDs[i]); //Will attempt to give us the book-item.
                if (itemTemp != null)
                {
                    shelfData.booksCollected[i] = true; //we have collected that book.
                    booksinShelf[i].SetActive(true);
                    break;

                }
            }
            //Check if all books are deposited, then we do some win-condition.
            //"You have collected, wanna finnish??"

        }
    }



    public void OnShelfClicked()
    {
        if (parentTom.activeInHierarchy) //If Tom is active, then...
        {
            stopShelf();
        }
        else
        {

        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void stopShelf() //This determines what happens when we're not inside the shelf, looking at books.
    {
        Logging.Log($"We stopped peeking into the Shelves.");
    }
}
