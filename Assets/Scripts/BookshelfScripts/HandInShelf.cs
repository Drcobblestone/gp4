using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandInShelf : MonoBehaviour
{
    [SerializeField] ShelfData shelfData; //We use the data from the ShelfData-object to populate the shelf with books.

    [Header("Put Tom here")] 
    [SerializeField] GameObject parentTom; //We use Tom as a condition for when you shouldn't be able to use the shelf.


    // Start is called before the first frame update
    void Start()
    {
        
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
