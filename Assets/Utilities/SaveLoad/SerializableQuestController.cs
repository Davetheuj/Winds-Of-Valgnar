using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[Serializable]

public class SerializableQuestController 
{

    public List<SerializableQuest> questList = new List<SerializableQuest>();
    public List<QuestSeries> questSeries = new List<QuestSeries>();

    public SerializableQuestController(QuestController loadedQuest)
    {
        foreach(Quest quest in loadedQuest.questList) {

            questList.Add(new SerializableQuest(quest));
        }
        foreach(QuestSeries questSery in loadedQuest.questSeries)
        {
            questSeries.Add(questSery);
        }

    }
}
