using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[Serializable]
public class SerializableQuest 
{
    public string questName;
    public string questSeries;
    public int numberInSeries;
    public int stepSize;
    public int currentStep;

    public int rewardCoins;
    public int rewardXP;
    public List<String> rewardItems;


    public string journalEntry1;

    public bool isRepeatable;

    public SerializableQuest(Quest loadedQuest){
        questName = loadedQuest.questName;
        questSeries = loadedQuest.questSeries;
        numberInSeries = loadedQuest.numberInSeries;
        stepSize = loadedQuest.stepSize;
        currentStep = loadedQuest.currentStep;
        rewardCoins = loadedQuest.rewardCoins;
        rewardXP = loadedQuest.rewardXP;
        journalEntry1 = loadedQuest.journalEntry1;
        isRepeatable = loadedQuest.isRepeatable;

        if (loadedQuest.rewardItems == null || loadedQuest.rewardItems.Count <= 0)
        {
            return;
        }
        foreach (GameObject item in loadedQuest.rewardItems){
            rewardItems.Add(item.name);

        }

    }


}
