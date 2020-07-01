using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    public List<Quest> questList = new List<Quest>();
    public GameObject questHolder;
    public ConsoleManager consoleManager;



    public void AddQuest(Quest quest)
    {

    }

    public void RemoveQuest(Quest quest)
    {



    }

    public void CheckForCompletion(Quest quest)
    {
        if(quest.stepSize == quest.currentStep)//quest complete
        {
            consoleManager.AddConsoleMessage1($"You have completed {quest.questName}!");
        }
    } 

    public void SetQuestControllerFromLoad(SerializableQuestController loadedQuest)
    {
        foreach (SerializableQuest quest in loadedQuest.questList)
        {
           

            Quest newQuest = questHolder.gameObject.AddComponent<Quest>();
            newQuest.SetQuestFromLoad(quest);
            questList.Add(newQuest);
        }
    }

}

