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

    public int Short_Swords;
    public int Long_Swords;
    public int Great_Swords;
    public int Shields;
    public int Axes;
    public int Blunt_Weapons;
    public int Great_Axes;
    public int Staves;
    public int Wands;
    public int Heavy_Armors;
    public int Medium_Armors;
    public int Light_Armors;
    public int Bows;
    public int Throwing_Knives;
    public int Cross_Bows;
    public int Throwing_Daggers;
    public int Destruction;
    public int Illusion;
    public int Restoration;

    public int honor;
    public int renown;
    public int popularity;

    public int xpAlchemy;
    public int xpPickpocketing;
    public int xpSmithing;
    public int xpCrafting;
    public int xpCooking;
    public int xpFishing;
    public int xpWoodcutting;
    public int xpEnchanting;

    public int xpShort_Swords;
    public int xpLong_Swords;
    public int xpGreat_Swords;
    public int xpShields;
    public int xpAxes;
    public int xpBlunt_Weapons;
    public int xpGreat_Axes;
    public int xpStaves;
    public int xpWands;
    public int xpHeavy_Armors;
    public int xpMedium_Armors;
    public int xpLight_Armors;
    public int xpBows;
    public int xpThrowing_Knives;
    public int xpCross_Bows;
    public int xpThrowing_Daggers;
    public int xpDestruction;
    public int xpIllusion;
    public int xpRestoration;

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

        Short_Swords = loadedStats.Short_Swords;
        Long_Swords = loadedStats.Long_Swords;
        Great_Swords = loadedStats.Great_Swords;
        Shields = loadedStats.Shields;
        Axes = loadedStats.Axes;
        Blunt_Weapons = loadedStats.Blunt_Weapons;
        Great_Axes = loadedStats.Great_Axes;
        Staves = loadedStats.Staves;
        Wands = loadedStats.Wands;
        Heavy_Armors = loadedStats.Heavy_Armors;
        Medium_Armors = loadedStats.Medium_Armors;
        Light_Armors = loadedStats.Light_Armors;
        Bows = loadedStats.Bows;
        Throwing_Knives = loadedStats.Throwing_Knives;
        Cross_Bows = loadedStats.Cross_Bows;
        Throwing_Daggers = loadedStats.Throwing_Daggers;
        Destruction = loadedStats.Destruction;
        Illusion = loadedStats.Illusion;
        Restoration = loadedStats.Restoration;

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

        xpShort_Swords = loadedStats.xpShort_Swords;
        xpLong_Swords = loadedStats.xpLong_Swords;
        xpGreat_Swords = loadedStats.xpGreat_Swords;
        xpShields = loadedStats.xpShields;
        xpAxes = loadedStats.xpAxes;
        xpBlunt_Weapons = loadedStats.xpBlunt_Weapons;
        xpGreat_Axes = loadedStats.xpGreat_Axes;
        xpStaves = loadedStats.xpStaves;
        xpWands = loadedStats.xpWands;
        xpHeavy_Armors = loadedStats.xpHeavy_Armors;
        xpMedium_Armors = loadedStats.xpMedium_Armors;
        xpLight_Armors = loadedStats.xpLight_Armors;
        xpBows = loadedStats.xpBows;
        xpThrowing_Knives = loadedStats.xpThrowing_Knives;
        xpCross_Bows = loadedStats.xpCross_Bows;
        xpThrowing_Daggers = loadedStats.xpThrowing_Daggers;
        xpDestruction = loadedStats.xpDestruction;
        xpIllusion = loadedStats.xpIllusion;
        xpRestoration = loadedStats.xpRestoration;



    }
}
