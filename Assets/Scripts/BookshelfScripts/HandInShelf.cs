using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HandInShelf : MonoBehaviour
{
    [SerializeField] ShelfData shelfData; //We use the data from the ShelfData-object to populate the shelf with books.

    [Header("Put Tom here")] 
    [SerializeField] GameObject parentTom; //We use Tom as a condition for when you shouldn't be able to use the shelf.
    [Header("Put the dummy-books here.")]
    [SerializeField] GameObject[] booksInShelf = new GameObject[4]; //An array where we put all of the books inside.

    //[Header("Insert the entire parent-object here, so we can search its Hierarchy.")]
    //[SerializeField] GameObject bremenDummyChild, snowDummyChild, redDummyChild, frogDummyChild; //We need this to search through the active sub-objects in the hierarchy.




    /*
    [Header("Put the shelf's collider here.")]
    [SerializeField] BoxCollider2D shelfBoxcollider; //Where we put our 

    [Header("Put the shelf's UI-script here.")]
    [SerializeField] ShelfUI shelfUI; //
   
    public GameObject shelfPanel;
    public TMP_Text shelfText;
    */


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < booksInShelf.Length; i++)
        {
            bool bookActive = shelfData.booksCollected[i];
            booksInShelf[i].SetActive(bookActive); //change later
        }
    }

    //Below is the older, more complicated way I had planned for how the shelf should work.
    /*
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


    public void stopShelf() //This determines what happens when we're not inside the shelf, looking at books.
    {
        Logging.Log($"We stopped peeking into the Shelves.");
    }
    */




    private void OnTriggerEnter2D(Collider2D collision) //The player enters the clickable zone.
    {
        PlayerController player = collision.GetComponent<PlayerController>(); //Finds the PlayerController, aka the Player, and put the value in there.
        Logging.Log(gameObject.name + " found player");
        if (player != null) //Then we check if it really is the player...
        {
            //Temporary array
            ItemID[] bookIDs = { ItemID.BREMENBOOK, ItemID.SNOWBOOK, ItemID.REDBOOK, ItemID.FROGBOOK }; //Let's us go through the handed in books.
            for (int i = 0; i < bookIDs.Length; i++) //We make a temporary int that starts at zero, and should then be less than bookIDs, which we then can increase when the things below happen.
            {
                ItemData itemTemp = Inventory.Instance.TryPopItem(bookIDs[i]); //Will attempt to give us the book-item.
                if (itemTemp != null) //If the bookID in the temporary check  we created is an actual book, then...
                {
                    shelfData.booksCollected[i] = true; //we have collected that book. (so we set the bool to true.)
                    booksInShelf[i].SetActive(true); //And we activate the dummy-book-object, so we can click something in the shelf and read the book.
                    
                    break;

                }

                /*
                if (shelfData.booksCollected[i] = true && itemTemp == null && bremenDummyChild.activeInHierarchy && snowDummyChild.activeInHierarchy && redDummyChild.activeInHierarchy && frogDummyChild.activeInHierarchy) //If we have collected the books, don't have any new temporary ones och the dummybooks are active, then...
                {
                    //WIN-condition, after all books are deposited, below.
                    Logging.Log($"We've got all of the books back!");

                    SceneManager.LoadScene("BookClub"); //Load the winning scene.
                    break;
                }
                */

            }

            //Guard-clause, so we have to collect all books.
            foreach (bool bookCollected in shelfData.booksCollected) //we make temp vari based on bools
            {
                if (bookCollected)
                {
                    continue;
                }
                return;
            }
            //WIN-condition, after all books are deposited, below.
            Logging.Log($"We've got all of the books back!");

            SceneManager.LoadScene("BookClub"); //Load the winning scene.

        }
    }
}
