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
        this.manaReq = oldQuest.manaReq;
        this.healthReq = oldQuest.healthReq;
        this.intellectReq = oldQuest.intellectReq;
        this.strengthReq = oldQuest.strengthReq;
        this.wisdomReq = oldQuest.wisdomReq;
        this.dexterityReq = oldQuest.dexterityReq;
        this.spiritReq = oldQuest.spiritReq;
        this.resolveReq = oldQuest.resolveReq;
        this.luckReq = oldQuest.luckReq;
        this.charismaReq = oldQuest.charismaReq;
        this.AlchemyReq = oldQuest.AlchemyReq;
        this.PickpocketingReq = oldQuest.PickpocketingReq;
        this.SmithingReq = oldQuest.SmithingReq;
        this.CraftingReq = oldQuest.CraftingReq;
        this.CookingReq = oldQuest.CookingReq;
        this.FishingReq = oldQuest.FishingReq;
        this.WoodcuttingReq = oldQuest.WoodcuttingReq;
        this.EnchantingReq = oldQuest.EnchantingReq;
    this.renownReq = oldQuest.renownReq;
    this.popularityReq = oldQuest.popularityReq;
    this.honorReq = oldQuest.honorReq;

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
        foreach (string itemName in loadedQuest.rewardItems)
        {
            rewardItems.Add(GameObject.Find(itemName));

        }
    }
}