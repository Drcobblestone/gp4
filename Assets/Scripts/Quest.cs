using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/Quest", order = 1)] //We create a scriptable Object, and where we want to store it.

public class Quest : ScriptableObject
{
    public string questID; //An id
    public string questName; //Name for the quest: I.e: "the Lonely Frog"
    public string questDescription; // A description, something like: "Give the Frog a babe."


    private void OnEnable()
    {
        if (string.IsNullOrEmpty(questID))
        {
            questID = questName + Guid.NewGuid().ToString();
        }
    }

    [System.Serializable] //This lets us create a custom class, struct, or field that can be *saved*. (serialised)
                          //It also makes it visible in the Unity-editor.

    //Adding the quests...
    public class QuestObjective
    {
        public string objectiveID; //Match with item ID that you need to collect and then give.
        public string objectiveDescription; //This describes what the player is supposed to do in the quest.
        public ObjectiveType typeofObjective; //This shows what kind of objective you need to fulfill.
        
        public bool gotItem; //You now have the item the NPC needs.
        public bool gaveItemtoNpc; //You have given the item 
        public bool questCompleted; //The quest is over, when this is triggered.
                                    //Idea: If both gotItem and gaveItemtoNpc are true, then the quest is completed.
    }

    [System.Serializable] //This lets us create a custom class, struct, or field that can be *saved*. (serialised)
                          //It also makes it visible in the Unity-editor.
    public class QuestProgress
    {
        public Quest quest;
        public List<QuestObjective> objectives;

        //Now we make a constructor for quest-progress: it's run when an instance of a class or struct is created. It helps us make sure the
        //instance created is valid, that it's right type of that instance.
        public QuestProgress(Quest quest) 
        {
            this.quest = quest; //We are storing the quest we are accepting into our quest-slot.
            objectives = new List<QuestObjective>(); //This gives us our new list of objectives.

            //This section is added to prevent us from modifying our current quest.
            foreach(QuestObjective obj in objectives)
            {
                objectives.Add(new QuestObjective
                {
                    objectiveID = obj.objectiveID,
                    objectiveDescription = obj.objectiveDescription,
                    typeofObjective = obj.typeofObjective,
                    //We finish off by setting all of the bools for completed quests to false, since they can't be true in a new quest.
                    //Write some god-damn function to call, here... so we can set the bools we made in QuestObjective.
                });
            }

        }

    }

}
