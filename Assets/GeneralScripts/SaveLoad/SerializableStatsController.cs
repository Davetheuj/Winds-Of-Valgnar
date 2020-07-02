using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SerializableStatsController
{
    public string zoneName;
    public string playerName;
    public int currentMana;
    public int currentHealth;
    public int maxHealth;

    public int maxMana;



    public int maxIntellect;
    public int currentIntellect;

    public float time;

  

    public int currentStrength;

    public int currentWisdom;
    public int currentDexterity;
    public int currentSpirit;
    public int currentResolve;
    public int currentLuck;
    public int currentCharisma;

    public int maxStrength;

    public int maxWisdom;
    public int maxDexterity;
    public int maxSpirit;
    public int maxResolve;
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

    public int renown;
    public int popularity;
    public int honor;

    public int xpAlchemy;
    public int xpPickpocketing;
    public int xpSmithing;
    public int xpCrafting;
    public int xpCooking;
    public int xpFishing;
    public int xpWoodcutting;
    public int xpEnchanting;
           
    public int generalXP;
    public SerializableStatsController(StatsController loadedStats)
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
        honor = loadedStats.honor;
        renown = loadedStats.renown;
        popularity = loadedStats.popularity;

        xpAlchemy = loadedStats.xpAlchemy;
        xpPickpocketing = loadedStats.xpPickpocketing;
        xpSmithing = loadedStats.xpSmithing;
        xpCrafting = loadedStats.xpCrafting;
        xpCooking = loadedStats.xpCooking;
        xpFishing = loadedStats.xpFishing;
        xpWoodcutting = loadedStats.xpWoodcutting;
        xpEnchanting = loadedStats.xpEnchanting;

        generalXP = loadedStats.generalXP;

}
}
