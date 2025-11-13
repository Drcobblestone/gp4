using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //We get the textmeshpro library.
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    [SerializeField] NpcData npcData;
    private int dialogueIndex = 0;
    ClickHandler clickHandler;
    public GameObject contButton;
    public float wordSpeed; //This lets us set how fast the words appear.

    [SerializeField] BoxCollider2D npcBoxcollider; //We make a field where we can get the NPC's box-collider.
    public bool resetDialougeAtEnd = false;
    public bool cantClickNPC = false; //We define a condition wherein you can't click the NPC 

    //Is it really a good idea to have a private Enum??
    private enum QuestState { NotStarted, InProgress, Completed} //We define the different states a Quest can be in.
    private QuestState questState = QuestState.NotStarted; //The first quest-state is always "not being started".

    private void Start()
    {
        dialogueText.text = ""; //This is needed because the length of dialogueText starts as 1. //If you run the game all the way from Main Menu, this causes Nullreferror.
        
        //This stuff should perhaps not be in start... we'll see.
        SyncQuestState(); //This might be unneccessary?

        //Set dialogue line based on questState
        if (questState == QuestState.NotStarted) //If the quest hasn't started, then...
        {
            dialogueIndex = 0; //...the dialogue-index is at 0. (because the NPC is only supposed to say the first dialogue-line then)
        }
        else if (questState == QuestState.InProgress) //...but if the quest has started, then...
        {
            dialogueIndex = npcData.questInProgressIndex; //...we make our dialogue-index be whatever our Quest-inprogress-index is, so the dialogue lines up with what we're doing.
        }
        else if (questState == QuestState.Completed) //And finally if we have completed the quest...
        {
            dialogueIndex = npcData.questCompletedIndex; //...our dialogue-index shall be at the final point.
        }
    }


    public void OnClicked() //Clicking the character starts the dialogue-panels. 
    {   
        if (dialoguePanel.activeInHierarchy)
        {
            zeroText();
        }
        else
        {
            NpcUI npcUI = dialoguePanel.GetComponent<NpcUI>();
            npcUI.Initialize(npcData);
            dialogueIndex = npcData.questInProgressIndex; //the sync with Quest Data
            dialoguePanel.SetActive(true); //...otherwise we activate the dialogue-panel in the hierarchy.
            StartCoroutine(Typing()); //... and start making words appear.
        }
    }

    //Always remember: Co-routines don't stop running unless you tell them! They're on a different thread.
    IEnumerator Typing() //This is our typing-effect, where the letters come out bit by bit.
    {
        if (dialoguePanel.activeInHierarchy)
        {
            cantClickNPC = true; //We make it so we can't click the NPC while the dialogue-panel is active.
            npcBoxcollider.enabled = false; //We do this by turning off the collider who detects the player.
        }

        string dialogue = npcData.conversations[dialogueIndex].dialogue;
        foreach (char letter  in dialogue.ToCharArray()) 
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
            
        }

        contButton.SetActive(true);
        ButtonMiddleman button = contButton.GetComponent<ButtonMiddleman>();
        button.onClicked.RemoveAllListeners();
        button.onClicked.AddListener(NextLine);        
    }

    //Should this be in NextLine, then?
 
    private void SyncQuestState()
    {
        if (npcData.quest == null) return;

        string questID = npcData.quest.questID;

        if (QuestController.instance.IsQuestActive(questID))
        {
            questState = QuestState.InProgress;
        }
        else
        {
            questState = QuestState.NotStarted;
        }

    }
    

    public void NextLine() //To load the next part of the conversation.
    {
        contButton.SetActive(false); //We turn off the continue-button, since now we're going to load the next conversation.

        //Check Quest stuff here, like if quest is complete.
        //dialogueIndex = 0;
        /*
        if (npcData.quest == null) return;

        string questID = npcData.quest.questID;

        if (QuestController.instance.IsQuestActive(questID))
        {
            questState = QuestState.InProgress;
        }
        else
        {
            questState = QuestState.NotStarted;
        }
        */
        //--

        if (dialogueIndex < npcData.conversations.Count -1) //If our dialogue-index is shorter than our dialogue-length
        {
            dialogueIndex++; //...the we start another conversation.
            dialogueText.text = ""; //We set the text to nothing, since we have a list of lines that's going to load instead.
            StartCoroutine(Typing()); //...and we'll start making the words appear again as well.
        }

        else //But If we don't want to load the next part of the conversation...
        { 
            zeroText() ; //We zero out our conversation.
        }

    }


    public void zeroText() //This is to reset our text-conversation.
    {
        dialogueText.text = "";
        dialogueIndex = 0;
        cantClickNPC = !resetDialougeAtEnd; //
        npcBoxcollider.enabled = !cantClickNPC;
        dialoguePanel.SetActive(false); //We turn off our dialogue-panel.
    }


}
