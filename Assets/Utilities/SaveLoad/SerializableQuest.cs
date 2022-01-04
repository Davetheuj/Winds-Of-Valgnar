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

    public int manaReq;
    public int healthReq;
    public int intellectReq;
    public int strengthReq;
    public int wisdomReq;
    public int dexterityReq;
    public int spiritReq;
    public int resolveReq;
    public int luckReq;
    public int charismaReq;
    public int AlchemyReq;
    public int PickpocketingReq;
    public int SmithingReq;
    public int CraftingReq;
    public int CookingReq;
    public int FishingReq;
    public int WoodcuttingReq;
    public int EnchantingReq;
    public int renownReq;
    public int popularityReq;
    public int honorReq;

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

        manaReq = loadedQuest.manaReq;
        healthReq = loadedQuest.healthReq;
        intellectReq = loadedQuest.intellectReq;
        strengthReq = loadedQuest.strengthReq;
        wisdomReq = loadedQuest.wisdomReq;
        dexterityReq = loadedQuest.dexterityReq;
        spiritReq = loadedQuest.spiritReq;
        resolveReq = loadedQuest.resolveReq;
        luckReq = loadedQuest.luckReq;
        charismaReq = loadedQuest.charismaReq;
        AlchemyReq = loadedQuest.AlchemyReq;
        PickpocketingReq = loadedQuest.PickpocketingReq;
        SmithingReq = loadedQuest.SmithingReq;
        CraftingReq = loadedQuest.CraftingReq;
        CookingReq = loadedQuest.CookingReq;
        FishingReq = loadedQuest.FishingReq;
        WoodcuttingReq = loadedQuest.WoodcuttingReq;
        EnchantingReq = loadedQuest.EnchantingReq;
        honorReq = loadedQuest.honorReq;
        popularityReq = loadedQuest.popularityReq;
        renownReq = loadedQuest.renownReq;

        if (loadedQuest.rewardItems == null || loadedQuest.rewardItems.Count <= 0)
        {
            return;
        }
        foreach (GameObject item in loadedQuest.rewardItems){
            rewardItems.Add(item.name);

        }

    }


}
