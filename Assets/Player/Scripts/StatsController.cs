using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class StatsController : MonoBehaviour
{
    public string zoneName;
    public string playerName;
    public int currentMana = 500;
    public int currentHealth = 500;
    public int maxHealth = 500;
    
    public int maxMana = 500;
   
    

    public int maxIntellect = 50;
    public int currentIntellect = 50;

    public float time;

    public StatusController statusController;

    public int currentStrength;
    
    public int currentWisdom;
    public int currentDexterity;
    public int currentSpirit = 15;
    public int currentResolve = 15;
    public int currentLuck;
    public int currentCharisma;

    public int maxStrength;
  
    public int maxWisdom;
    public int maxDexterity;
    public int maxSpirit = 15;
    public int maxResolve = 15;
    public int maxLuck;
    public int maxCharisma;

    public int Alchemy;
    public int Pickpocketing;
    public int Smithing;
    public int Crafting;
    public int Cooking;
    public int Fishing;
    public int Woodcutting;
    public int Enchanting;



    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= 1.5f)
        {
            RegenerateStats();
            time = 0;
        }
    }


    private void RegenerateStats()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth +=(int) (currentResolve/5f);
        }
        if (currentMana< maxMana)
        {
            currentMana += (int)(currentSpirit / 5f);
        }

        currentMana = Mathf.Clamp(currentMana, 0, maxMana);
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        statusController.UpdateStatusUI();
    }

    public void SetStatsFromLoad(SerializableStatsController loadedStats)
    {
     zoneName = loadedStats.zoneName;
     playerName = loadedStats.playerName;
     currentMana = loadedStats.currentMana;
     currentHealth = loadedStats.currentHealth;
     maxHealth = loadedStats.maxHealth;

     maxMana = loadedStats.maxMana;



     maxIntellect = loadedStats.maxIntellect;
     currentIntellect = loadedStats.currentIntellect;

    time = loadedStats.time;

    

     currentStrength = loadedStats.currentStrength;
    
     currentWisdom = loadedStats.currentWisdom;
     currentDexterity = loadedStats.currentDexterity;
     currentSpirit = loadedStats.currentSpirit;
     currentResolve = loadedStats.currentResolve;
     currentLuck = loadedStats.currentLuck;
     currentCharisma = loadedStats.currentLuck;

     maxStrength = loadedStats.maxStrength;

        maxWisdom = loadedStats.maxWisdom; ;
     maxDexterity = loadedStats.maxDexterity;
     maxSpirit = loadedStats.maxSpirit;
     maxResolve = loadedStats.maxResolve;
     maxLuck = loadedStats.maxLuck;
     maxCharisma = loadedStats.maxCharisma;

     Alchemy = loadedStats.Alchemy;
      Pickpocketing = loadedStats.Pickpocketing;
     Smithing = loadedStats.Smithing;
     Crafting = loadedStats.Crafting;
     Cooking = loadedStats.Cooking;
     Fishing = loadedStats.Fishing;
     Woodcutting = loadedStats.Woodcutting;
     Enchanting = loadedStats.Enchanting;

}

}
