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
        Dictionary<ItemID, ItemData> checkForItem = Inventory.Instance.inventoryDictionary;

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
        /*
        if(!RemoveRequiredItemsFromInventory(questID))
        { 
            //Quest couldn't be completed - missing items.
            return;  //If we can't remove the item from inventory, then we return.
        }*/


        //Remove the finished Quest from the Quest-log.
        QuestProgress quest = activateQuests.Find(q => q.QuestID == questID);
        if (quest != null) //If we don't have an active quest, then...
        {
            handinQuestIDs.Add(questID); //We add the finished quest to handed in quests, aka finished ones.
            activateQuests.Remove(quest); //...remove the inactive quest. (it should be completed then)
            questUi.UpdateQuestUi();
        }

    }

    public bool IsQuestHandedIn(string questID) //A double-check to make sure the quest is handed in. If our quest has been handed in...
    {
        return handinQuestIDs.Contains(questID); //...it will be within this list.
    }



    //When a quest finishes, we remove the items of the Quest, from the inventory.
    /*
    public bool RemoveRequiredItemsFromInventory(string questID)
    {
        QuestProgress quest = activateQuests.Find(q => q.QuestID == questID);
        if (quest == null) return false; //If we don't have a quest, we don't need to remove items from inventory.

        Dictionary<int, int> requiredItems = new(); //We make a new dictionary to keep abreast of the required items.

        //Item requirements from objectives
        foreach(QuestObjective objective in quest.objectives)
        {
            if (objective.typeOfObjective == ObjectiveType.CollectItem && int.TryParse(objective.objectiveID, out int itemID)) //If this objective is to collect an Item and we 
                                                                                                                               //can parse our objectiveID out to an Int, then...
            {
                //requiredItems; //This is written in the tutorial for if you need to collect several of the same type of item...
                //requiredItems[itemID] = objective.requiredAmount; <-- Change to requiredItem? How?
            }
        }

        //Verify we have items -- this might be only for if we have multi-collect of one type of item...
        
        Dictionary<ItemID, ItemData> requiredItem = Inventory.Instance.GetInstanceID(); //Could I just use the requiredItems dictionary? (above)
                                                                                        //The original uses GetItemCounts -- how do I pick the replacement?
        foreach(ItemData itemRequirement in requiredItems)
        {
            if(inventoryId.GetValueOrDefault(ItemData.Key)) //Should "Key" be in ItemController instead?
            {
                return false;
            }

            //The below code is from the tutorial - it has to be changed from amounts again...
            /*
            if(itemCounts.GetValueOrDefault(itemController.Key) < itemController.Value) //Note again that the tutorial calls an item-controller instead of an ItemData
            {
                //Not enough items to complete quest. (I need to change this to not the item to complete quest)
                return false;
            }
            
        }

        //Remove required items from inventory (when the quest is completed)
        foreach (var itemRequirement in requiredItems) //Vars are cringe, but what do I name it?
        {
            //We summon RemoveItemFromInventory from Inventory.cs.
            Inventory.Instance.RemoveItemFromInventory(itemRequirement.Key, itemRequirement.Value);
        }
        return true;
    }
*/


    //This is mostly for a save-system, to recall what quests we have completed since the last session.
    public void LoadQuestProgress(List<QuestProgress> savedQuests)
    {
        activateQuests = savedQuests ?? new();

        CheckInventoryForQuests();
        questUi.UpdateQuestUi();
    }

}
