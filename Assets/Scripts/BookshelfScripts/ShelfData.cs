using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShelfData", menuName = "ScriptableObjects/ShelfData", order = 1)] //We create a scriptable Object, and where we want to store it.



public class ShelfData : ScriptableObject
{
    public bool[] booksCollected = new bool[4]; //creates an array of our books.

    public void Reset()
    {
        booksCollected = new bool[4];
    }

}

