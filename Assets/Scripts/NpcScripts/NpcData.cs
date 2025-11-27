using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NpcData", menuName = "ScriptableObjects/NpcData", order = 1)] //We create a scriptable Object, and where we want to store it.


public class NpcData : ScriptableObject
{
    public string npcName = ""; //We can use any name for the NPC in the script.
    public NpcID nId; //Let's us assign one of the itemid's we have in the GameEnums script.
    public string description; //Sadly we can't use name, as that is an inherited property too, but this is just a name.
    public Sprite icon; //This is an actual sprite/texture that's going to be visible in the UI.
    public bool talkedTo = false;

    [Header("The Conversations the NPC has when loaded.")] //Tells us what conversations the NPC is meant to have.
    public List<Conversations> conversations = new List<Conversations>(); //This creates the list of conversations the NPC is supposed to have.



    public int questInProgressIndex = 0; //If we have currently accepted a quest, this decides what/when the NPC will say a certain line of dialogue.(or give an item)
    //public int questCompletedIndex; //If we have completed a quest, this will track that.
    public QuestData quest; //The quest the NPC gives.
    public void Reset()
    {
        questInProgressIndex = 0;
        //talkedTo = false;
        foreach(Conversations conversation in conversations)
        {
            conversation.hasItem = false;
        }
    }
}


[System.Serializable] //This lets us create a custom class, struct, or field that can be *saved*. (serialised)
                      //It also makes it visible in the Unity-editor. 
public class Conversations //Here we define our various options for what happens during conversations.
{
    [TextArea(3, 10)] //TextAreaAttribute(int minLines, int maxLines);
    public string dialogue;

    //---Quest-related---
    /*
    public bool waitForQuestGiven; //Click this in editor, to make sure the particular line of text doesn't load before a Quest has been given.
    public bool waitForQuestItem1; //Click this in editor, to make sure that text doesn't show up before a quest is complete. (we need to write an if-statement to make it false as well, in another script...)
    public bool waitForQuestItemFinal;
  
    public Item firstNpcGivenItem; //If an Npc gives you an item before the quest is over - an item needed to complete the quest.
    public Item finalNpcGivenItem; //This is supposed to summon an item to give to the player, at the end of the quest. (a book)
    */

    //public int dialogueIndex; //A way to keep abreast of our dialogue-lines/options.
    //public int[] nextDialogueIndexes; //Which dialogue is supposed to show up, depending on conditions.
    //public bool[] givesQuest; //If the dialogue gives a quest.

    //---End of Quest---


    //
    [Header ("Conversation overrides, for Frog-quest.")]
    public Sprite icon = null;
    public string npcName = "";
    
    public bool endConvoEarly = false;
    public int setQuestProgressTo = 0;
    public ItemID wantedItem = ItemID.NONE; //Never change this bool!
    public ItemID rewardItem = ItemID.NONE; //Default reward, but this we can change.
    
    public ItemID givenItem = ItemID.NONE; //This we can change, since it's an item to trigger another quest.

    public bool hasItem; //I don't think we need this any more... disable?
    //public bool gaveItem; //This is potentially for giving the item.

    
}