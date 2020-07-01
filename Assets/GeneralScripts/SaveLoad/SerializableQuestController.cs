using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[Serializable]

public class SerializableQuestController 
{

    public List<SerializableQuest> questList = new List<SerializableQuest>();

    public SerializableQuestController(QuestController loadedQuest)
    {
        foreach(Quest quest in loadedQuest.questList) {

            questList.Add(new SerializableQuest(quest));
        }

    }
}
