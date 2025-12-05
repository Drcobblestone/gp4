using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShelfData", menuName = "ScriptableObjects/ShelfData", order = 1)] //We create a scriptable Object, and where we want to store it.


public class ShelfData : ScriptableObject
{
    public string description; //Describes what the book is about.
    public Sprite cover; //This is an actual sprite/texture that's going to be visible in the UI.
    public string bookName = ""; //This will have the names of the books we deposit.

    [Header("The books the shelf has when clicked.")] //Tells us what conversations the NPC is meant to have.
    public List<Readables> readables = new List<Readables>(); //This creates the list of conversations the NPC is supposed to have.

    public int questInProgressIndex = 0; //If we have currently accepted a quest, this decides when we will be able to read a book. (since it can be deposited at the end of the quest.
    //public int questCompletedIndex; //If we have completed a quest, this will track that.
    public QuestData quest; //The quest the NPC gives.
    public void Reset()
    {
        questInProgressIndex = 0;
        foreach (Readables readable in readables)
        {
            readable.hasBook = false;
        }
    }
}

[System.Serializable]

public class Readables //Here we define our various options for what happens during conversations.
{
    public string dialogue;

    public bool hasBook;

}

