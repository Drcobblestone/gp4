using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestUi : MonoBehaviour
{
    public Transform questListContent;
    public GameObject questEntryPrefab;
    public GameObject objectiveTextPrefab;


    public QuestData quest; //This is supposed to be a test-quest in the tutorial...
    public int questAmount;
    private List<QuestProgress> quests = new();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < questAmount; i++)
        {
            quests.Add(new QuestProgress(quest));
        }

        UpdateQuestUi();
    }

    // Called whenever there should be an update to our quest-progress.
    public void UpdateQuestUi()
    {
        //Destroy existing quest entries
        foreach (Transform child in questListContent)
        {
            Destroy(child.gameObject);
        }
        //Build quest entries.
        foreach (QuestProgress quest in quests)
        {
            GameObject entry = Instantiate(questEntryPrefab, questListContent);
            TMP_Text questNameText = entry.transform.Find("QuestNameText").GetComponent<TMP_Text>(); //This gets the QuestNameText component in our InGameMenu canvas.
            Transform objectiveList = entry.transform.Find("ObjectiveList");

            questNameText.text = quest.quest.questName; //Is "name" actually called Name here? Might be questName.

            foreach (QuestObjective objective in quest.objectives)
            {
                GameObject objTextGO = Instantiate(objectiveTextPrefab, objectiveList);
                TMP_Text objText = objTextGO.GetComponent<TMP_Text>();
                //objText = $"{objective.objectiveDescription} ({objective.currentAmount}/{objective.requiredAmount})"; //I don't have the Ints with amount that the tutorial has... What do I put here instead??
                objText.text = $"{objective.objectiveDescription}"; //This will make the text describing the objective, appear in the GUI.
            }
        }
    }
}
