using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShelfUI : MonoBehaviour
{
    [Header("References (from ShelfData)")]
    [SerializeField] Image bookCover; //Where we input the cover of the book we want to be readable.
    [SerializeField] TMP_Text nameofBook; //Where we input the name of the Book.


    public void Initialize(ShelfData shelfData) // When we start talking to an NPC, we pass it the NPC-ID, so we can populate the conversation-canvas with Name and Icon.
    {
        bookCover.sprite = shelfData.cover; //We give the portrait from NpcData.
        nameofBook.text = shelfData.bookName; //We define that the NpcName field from NpcData, is what the text for the name of the NPC should be.
    }
    public void Initialize(Sprite cover, string bookName) // When we start talking to an NPC, we pass it the NPC-ID, so we can populate the conversation-canvas with Name and Icon.
    {
        bookCover.sprite = cover; //We give the portrait from NpcData.
        nameofBook.text = bookName; //We define that the NpcName field from NpcData, is what the text for the name of the NPC should be.
    }
}
