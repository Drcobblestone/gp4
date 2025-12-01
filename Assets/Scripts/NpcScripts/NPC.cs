using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro; //We get the textmeshpro library.
using UnityEngine;
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

    [SerializeField] GameObject npcObject; //Insert NPC-character Prefab here, so we can despawn it.
    [SerializeField] GameObject transfEffectPrefab;

    [SerializeField] BoxCollider2D npcBoxcollider; //We make a field where we can get the NPC's box-collider.
    public bool resetDialougeAtEnd = false;
    public bool cantClickNPC = false; //We define a condition wherein you can't click the NPC 
    NpcUI npcUI;
    //Old queststate code.
    //private enum QuestState { NotStarted, InProgress, Completed} //We define the different states a Quest can be in.
    //private QuestState questState = QuestState.NotStarted; //The first quest-state is always "not being started".

    private void Start()
    {
        dialogueText.text = ""; //This is needed because the length of dialogueText starts as 1. //If you run the game all the way from Main Menu, this causes Nullreferror.
        npcUI = dialoguePanel.GetComponent<NpcUI>();

        /*//This stuff should perhaps not be in start... we'll see.
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
            //dialogueIndex = npcData.questCompletedIndex; //...our dialogue-index shall be at the final point.
        }*/
    }


    public void OnClicked() //Clicking the character starts the dialogue-panels. 
    {   
        if (dialoguePanel.activeInHierarchy)
        {
            zeroText();
        }

        else
        {
            //NpcUI npcUI = dialoguePanel.GetComponent<NpcUI>();
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
            if (npcObject == null)
            {
                yield break;
            }
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

    //Old way of syncing with queststates.
 
    /*private void SyncQuestState()
    {
        if (npcData.quest == null) return;

        string questID = npcData.quest.questID;

        //Quest completing and handing in quest to NPC.
        if (QuestController.instance.IsQuestCompleted(questID) || QuestController.instance.IsQuestHandedIn(questID)) //If the quest is either marked completed or handed in...
        {
            questState = QuestState.Completed; //...then the quest is completed.
        }


        else if (QuestController.instance.IsQuestActive(questID))
        {
            questState = QuestState.InProgress;
        }
        else
        {
            questState = QuestState.NotStarted;
        }

    }*/
    

    public void NextLine() //To load the next part of the conversation.
    {
        npcUI.Initialize(npcData);
        contButton.SetActive(false); //We turn off the continue-button, since now we're going to load the next conversation.

        //Quest Hand In Here
        Conversations currentConvo = npcData.conversations[dialogueIndex];
        if (currentConvo.icon != null)
        {
            npcUI.Initialize(currentConvo.icon, currentConvo.npcName);
        }
        if (currentConvo.setQuestProgressTo > 0)
        {
            npcData.questInProgressIndex = currentConvo.setQuestProgressTo;
        }
        if (currentConvo.wantedItem != ItemID.NONE && !currentConvo.hasItem)
        {
            ItemData item = Inventory.Instance.TryPopItem(currentConvo.wantedItem);
            if (item != null) //If you have an item
            {
                currentConvo.hasItem = true; //Then we set the hasItem bool to true.
                npcData.questInProgressIndex = dialogueIndex + 1; //Potential Out of Bounds here //We move the conversation onwards.
            }
            else
            {
                zeroText();
                return;
            }
        }

        //Quest items
        if (currentConvo.givenItem != ItemID.NONE) //If we have been given an intermediate quest-item, then...
        {
            //Cinematic Effects and Animations Start Here
            /*
            if (transfEffectPrefab != null) //If we have set a transformation-effect prefab on the NPC, then...
            {
                Instantiate(transfEffectPrefab, transform.position, Quaternion.identity); // We instantiate this effect-prefab in the same place as the NPC.
                Debug.Log("POOF!");
            }
            */

            DroppedItem droppedItem = GameManager.Instance.SpawnItem(currentConvo.givenItem, transform.position); //Then we spawn the quest-item/given item.

            if (droppedItem != null) //If the dropped item isn't nothing, then... 
            {
                Debug.Log("The quest-item has spawned."); //we print the debug-message.
            }
            else //But if the dropped item didn't happen, then we warn.
            {
                Debug.LogWarning("The Quest-item DIDN'T spawn!");
            }

        }
        //End of quest-items.


        //Reward Item Here
        if (currentConvo.rewardItem != ItemID.NONE) //If the reward for the current conversation is NOT set to nothing, then run below.
        {
            //Cinematic Effects and Animations Start Here
            if (transfEffectPrefab != null) //If we have set a transformation-effect prefab on the NPC, then...
            {
                Instantiate(transfEffectPrefab, transform.position, Quaternion.identity); // We instantiate this prefab in the same place as the NPC.
                Debug.Log("POOF!");
            }


            //and end before here

            DroppedItem droppedItem = GameManager.Instance.SpawnItem(currentConvo.rewardItem, transform.position); //Then we spawn the Book/reward.
            
            if (droppedItem != null) //If the dropped item isn't nothing, then... 
            {
                Debug.Log("The book has spawned."); //we print the debug-message.
                npcObject.SetActive(false); //And turn off the NPC.
            }
            else //But if the dropped item didn't happen, then we warn.
            {
                Debug.LogWarning("The book DIDN'T spawn!");
            }
        //No more reward-stuff.

        }
        if (currentConvo.endConvoEarly)
        {
            zeroText(); //We run the zero-text routine, to stop typing text, and end the conversation.
            return;
        }

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

    //Adding an end-dialogue - not sure if right for our project.
    /*public void EndDialogue() 
    {
        if (questState == QuestState.Completed && !QuestController.instance.IsQuestHandedIn(npcData.quest.questID)) //We want to make sure our quest is completed, but not handed in.
        {
            //This will handle our quest-completion.
            //HandleQuestCompletion(npcData.quest); //So we only complete and hand in our quest, when it's NOT ALREADY completed and handed in.
        }

        //The tutorial adds all this code...
        /*
        StopAllCoroutines();
        isDialogueActive = false; //We don't have this bool.
        dialogueUI.SetDialogueText(""); //We don't have anything called DialogueUI either...
        dialogueUI.ShowDialogueUI(false);
        PauseController.SetPause(false); //We don't have a pause-controller script either, but it'd be a nice feature for the future.
        
    }*/

    /*void HandleQuestCompletion(QuestData quest)
    {
        QuestController.instance.HandInQuest(quest.questID);
    }
    */



    public void zeroText() //This is to reset our text-conversation.
    {
        dialogueText.text = "";
        dialogueIndex = 0;
        cantClickNPC = !resetDialougeAtEnd; //
        if (npcObject != null) //If we do have an NPC active...
        {
            npcBoxcollider.enabled = !cantClickNPC; //...and therefore an active collider, then we can click the NPC.
        }
        dialoguePanel.SetActive(false); //We turn off our dialogue-panel.
    }

}
