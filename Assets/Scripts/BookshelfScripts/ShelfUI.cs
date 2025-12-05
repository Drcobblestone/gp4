using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShelfUI : MonoBehaviour
{
    [Header("References (from ShelfData)")]
    [SerializeField] Image cover; //Where we input the cover of the book we want to be readable.
    [SerializeField] TMP_Text nameof; //Where we input the name of the Book.


    public void Initialize(NpcData npcData) // When we start talking to an NPC, we pass it the NPC-ID, so we can populate the conversation-canvas with Name and Icon.
    {
        cover.sprite = npcData.icon; //We give the portrait from NpcData.
        nameof.text = npcData.npcName; //We define that the NpcName field from NpcData, is what the text for the name of the NPC should be.
    }
    public void Initialize(Sprite icon, string npcName) // When we start talking to an NPC, we pass it the NPC-ID, so we can populate the conversation-canvas with Name and Icon.
    {
        cover.sprite = icon; //We give the portrait from NpcData.
        nameof.text = npcName; //We define that the NpcName field from NpcData, is what the text for the name of the NPC should be.
    }
}
