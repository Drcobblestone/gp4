using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    public static QuestController instance { get; private set; }
    public List<QuestProgress> activateQuests = new();
    [SerializeField] QuestUi questUi;
    [SerializeField] Inventory inventoryController;

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
        questUi.UpdateQuestUi();
    }

    //Now we make sure there's only ever one quest active at a time.
    public bool IsQuestActive(string questID) => activateQuests.Exists(q => q.QuestID == questID); //This checks if our QuestID already exists in our active Quest, 
                                                                                                   //and then pass along true or false.

    public void CheckInventoryForQuests()
    {

    }
}
