using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    public List<Quest> questList = new List<Quest>();
    public List<QuestSeries> questSeries = new List<QuestSeries>();
    public GameObject questHolder;
    public ConsoleManager consoleManager;
    public StatsController pS;



    public void AddQuest(Quest quest)
    {
        

        Quest newQuest = questHolder.gameObject.AddComponent<Quest>();
        newQuest.CopyValues(quest);
        questList.Add(newQuest);
        bool seriesFlag = false;
        foreach(QuestSeries sery in questSeries)
        {
            if(quest.questSeries == sery.seriesName)
            {
                sery.countInSeries++;
                seriesFlag = true;
                break;
            }
        }
        if (!seriesFlag) //add Sery to list
        {
            questSeries.Add(new QuestSeries(quest.questSeries));
        }
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
        foreach(QuestSeries sery in loadedQuest.questSeries)
        {
            questSeries.Add(sery);
        }
       
    }
    public bool CheckQuestRequirements(Quest q)
    {
        if ()
        {
            return false;
        }
        return true;
    }

}

