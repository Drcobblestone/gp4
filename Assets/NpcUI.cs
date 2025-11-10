using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NpcUI : MonoBehaviour
{
    [Header("References (from NPCdata)")]
    [SerializeField] Image portrait; //Should this be not specific things from NPCdata, but just NPCdata in general, and then call both portrait and name later?
    [SerializeField] TMP_Text nameof; //Where we input the name of the NPC-character.


    public void Initialize(NpcID nId, NpcData npcData) // When we start talking to an NPC, we pass it the NPC-ID, so we can populate the conversation-canvas with Name and Icon.
    {
        portrait.sprite = npcData.icon; //We give the portrait from NpcData.
        nameof.text = npcData.npcName; //We define that the NpcName field from NpcData, is what the text for the name of the NPC should be.
    }
}
