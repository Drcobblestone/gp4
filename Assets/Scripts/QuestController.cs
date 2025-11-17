using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    public static QuestController instance { get; private set; }
    public List<QuestProgress> activateQuests = new();
    [SerializeField] QuestUi questUi;

    public List<string> handinQuestIDs = new(); //We make a list for keeping tabs of completed Quests.

    //We make sure we only ever have *one* QuestController in our game.
    private void Awake()
    {
        if (instance == null) instance = this; //If the quest-controller instance is set to Null, then create this new instance.
        else Destroy(gameObject); //Otherwise destroy this instance, since then it's a double.

        Inventory.Instance.OnInventoryChanged += CheckInventoryForQuests; //When the controller wakes up, it shall have a look at the inventory (if there are quest-items).
    }

    public void AcceptQuest (QuestData quest) //When we accept a quest from an NPC...
    {
        if (IsQuestActive(quest.questID)) return; //If IsQuestActive is already running, then we just return.

        activateQuests.Add(new QuestProgress(quest)); //We create a new active Quest, based on our QuestData.

        CheckInventoryForQuests(); //We double-check inventory for Quest-items before we update.
        questUi.UpdateQuestUi(); //Then we update the Ui and show our new quest.
    }

    //Now we make sure there's only ever one quest active at a time.
    public bool IsQuestActive(string questID) => activateQuests.Exists(q => q.QuestID == questID); //This checks if our QuestID already exists in our active Quest, 
                                                                                                   //and then pass along true or false.

    public void CheckInventoryForQuests()
    {
        Dictionary<ItemID, Item> checkForItem = Inventory.Instance.inventoryDictionary;
        // Dictionary<ItemID, Item> inventoryDictionary = inventoryData.inventoryItems; //<- This is an example that fucking WORKS in the other script!!

        foreach (QuestProgress quest in activateQuests)
        { //Why am I nesting for-loops...?
            foreach (QuestObjective questObjective in quest.objectives) 
            {
                if (questObjective.typeOfObjective != ObjectiveType.CollectItem) continue; //If the current objective in the quest is to collect items, then continue.
                if (!int.TryParse(questObjective.objectiveID, out int itemID)) continue; //If the current objective isn't something item-related (an int), then we will skip
                                                                                         //comparing that objective to the Item-dictionary.
            }
        }
        questUi.UpdateQuestUi(); //Finally we update the questUi, so we can see that we have the thing that we should give to someone.

    }

    public bool IsQuestCompleted(string questID)
    {
        QuestProgress quest = activateQuests.Find(q => q.QuestID == questID); //Grab the quest from our Active Quest 
        return quest != null && quest.objectives.TrueForAll(o => o.questCompleted); //And if the quest isn't null (we are working on a quest) and all of the objectives are completed, then...
        //return quest != null && quest.objectives.TrueForAll(o => o.IsCompleted); //<- From tutorial, but gives error. Probably that I named it differently.
    }
    
    public void HandInQuest(string questID)
    {
        //Try to remove the required items (of the quest).



        //Remove the finished Quest from the Quest-log.
        foreach (QuestProgress objective in quest.objectives)
        {

        }

    }

    //When a quest finishes, we remove the items of the Quest, from the inventory.
    public bool RemoveRequiredItemsFromInventory(string questID)
    {
        QuestProgress quest = activateQuests.Find(q => q.QuestID == questID);
        if (quest == null) return false; //If we don't have a quest, we don't need to remove items from inventory.

        Dictionary<int, int> requiredItems = new(); //We make a new dictionary to keep abreast of the required items.

        //Item requirements from objectives
        foreach(QuestObjective objective in quest.objectives)
        {
            if (objective.typeOfObjective == ObjectiveType.CollectItem && int.TryParse(objective.objectiveID, out int itemID))
            {
                //requiredItems; //This is written in the tutorial for if you need to collect several of the same type of item...
            }
        }

        //Verify we have items -- this might be only for if we have multi-collect of one type of item...
        
        Dictionary<ItemID, Item> requiredItem = Inventory.Instance.GetInstanceID();
        foreach(Item itemRequirement in requiredItems)
        {
            if(inventoryId.GetValueOrDefault(Item.Key))
            {
                return false;
            }
        }

        //Remove required items from inventory (when the quest is completed)
        foreach (var itemRequirement in requiredItems) //Vars are cringe, but what do I name it?
        {

        }


        return true;
    }



    //This is mostly for a save-system, to recall what quests we have completed since the last session.
    public void LoadQuestProgress(List<QuestProgress> savedQuests)
    {
        activateQuests = savedQuests ?? new();

        CheckInventoryForQuests();
        questUi.UpdateQuestUi();
    }

}
