using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Quest : MonoBehaviour
{
    public string questName;
    public string questSeries;
    public int numberInSeries;
    public int stepSize;
    public int currentStep;

    public int rewardCoins;
    public int rewardXP;
    public List<GameObject> rewardItems;
   

     public string journalEntry1;

    public bool isRepeatable;

    public void CopyValues(Quest oldQuest)
    {
        this.questName = oldQuest.questName;
        this.questSeries = oldQuest.questSeries;
        this.numberInSeries = oldQuest.numberInSeries;
        this.stepSize = oldQuest.stepSize;
        this.currentStep = oldQuest.currentStep;
        this.rewardCoins = oldQuest.rewardCoins;
        this.rewardXP = oldQuest.rewardXP;
        this.rewardItems = oldQuest.rewardItems;
        this.journalEntry1 = oldQuest.journalEntry1;
        this.isRepeatable = oldQuest.isRepeatable;
      
    }

   /* public void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }*/

    public void SetQuestFromLoad(SerializableQuest loadedQuest)
    {
        questName = loadedQuest.questName;
        questSeries = loadedQuest.questSeries;
        numberInSeries = loadedQuest.numberInSeries;
        stepSize = loadedQuest.stepSize;
        currentStep = loadedQuest.currentStep;
        rewardCoins = loadedQuest.rewardCoins;
        rewardXP = loadedQuest.rewardXP;
        journalEntry1 = loadedQuest.journalEntry1;
        isRepeatable = loadedQuest.isRepeatable;
        
        if(loadedQuest.rewardItems == null || loadedQuest.rewardItems.Count <= 0)
        {
            return;
        }
        foreach (string itemName in loadedQuest.rewardItems)
        {
            rewardItems.Add(GameObject.Find(itemName));

        }
    }
}