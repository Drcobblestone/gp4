using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestData", menuName = "ScriptableObjects/Questdata", order = 1)] //We create a scriptable Object, and where we want to store it.

public class QuestData : ScriptableObject
{
    public string questID; //An id
    public string questName; //Name for the quest: I.e: "the Lonely Frog"
    public string questDescription; // A description, something like: "Give the Frog a babe."
    public List <QuestObjective> objectives;
    public List <QuestReward> questRewards;

    public void ResetList()
    {
        //QuestIndex = -1; //We reset the quest-data, so we can test Quests.
        objectives = new List<QuestObjective>();
        //To reset we need: Int, bool, List.
    }

    //This is called whenever the Scriptable object (the quest) is edited.
    private void OnValidate() //Replace with something else, onValidate is in editor only
    {
        if (string.IsNullOrEmpty(questID))
        {
            questID = questName + Guid.NewGuid().ToString();
        }
    }
}

[System.Serializable] //This lets us create a custom class, struct, or field that can be *saved*. (serialised)
                      //It also makes it visible in the Unity-editor.

//Adding the quests...
public class QuestObjective
{
    [Header("Match with ItemID if objective is a pickup.")]
    public string objectiveID; //Match with item ID that you need to collect and then give.
    public string objectiveDescription; //This describes what the player is supposed to do in the quest.
    public ObjectiveType typeOfObjective; //This shows what kind of objective you need to fulfill.

    public bool gotItem; //You now have the item the NPC needs.
    public bool gaveItemToNpc; //You have given the item 
    public bool questCompleted; //The quest is over, when this is triggered.
                                //Idea: If both gotItem and gaveItemtoNpc are true, then the quest is completed.
}

[System.Serializable] //This lets us create a custom class, struct, or field that can be *saved*. (serialised)
                      //It also makes it visible in the Unity-editor.
public class QuestProgress
{
    public QuestData quest;
    public List<QuestObjective> objectives;

    //Now we make a constructor for quest-progress: it's run when an instance of a class or struct is created. It helps us make sure the
    //instance created is valid, that it's the right type of that instance.
    public void ResetBool()
    {
        return;
        //questCompleted = !(questCompleted);
    }

    public QuestProgress(QuestData quest)
    {
        this.quest = quest; //We are storing the quest we are accepting into our quest-slot.
        objectives = new List<QuestObjective>(); //This gives us our new list of objectives.

        //This section is added to prevent us from modifying our current quest.
        foreach (QuestObjective obj in quest.objectives)
        {
            objectives.Add(new QuestObjective
            {
                objectiveID = obj.objectiveID,
                objectiveDescription = obj.objectiveDescription,
                typeOfObjective = obj.typeOfObjective,
                //Do I add an IsCompleted here? Or do I use questCompleted from the bool.

                //We finish off by setting all of the bools for completed quests to false, since they can't be true in a new quest.
                //Write some god-damn function to call, here... so we can set the bools we made in QuestObjective.
            });
        }
    }
    //This is triggered when the Quest is completed and all of the Objectives are completed.
    public bool questCompleted => objectives.TrueForAll(o => o.questCompleted);

    public string QuestID => quest.questID;
}

[System.Serializable]
public class QuestReward
{
    public RewardType type;
    public int rewardID; //This can be ItemID et c.

}