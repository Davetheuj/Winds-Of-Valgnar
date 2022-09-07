using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

public class StatsController : MonoBehaviour
{
    public ConsoleManager console;
    public StatusController statusController;
    public EquipmentController equipmentController;

    public string zoneName;

    public string playerName;

    public float time;

    public int currentMana = 500;
    public int currentHealth = 500;
   
    public int maxHealth = 500;
    public int maxMana = 500;

    public int playerLevel =1;
   
    public int currentIntellect = 50;
    public int currentStrength;
    public int currentWisdom;
    public int currentDexterity;
    public int currentSpirit = 15;
    public int currentResolve = 15;
    public int currentLuck;
    public int currentCharisma;

    public int maxIntellect = 50;
    public int maxStrength;
    public int maxWisdom;
    public int maxDexterity;
    public int maxSpirit = 15;
    public int maxResolve = 15;
    public int maxLuck;
    public int maxCharisma;

    public int Alchemy; 
    public int Axes; 
    public int Blunt_Weapons; 
    public int Bows; 
    public int Cooking;
    public int Crafting;
    public int Cross_Bows;
    public int Destruction;
    public int Enchanting;
    public int Fishing;
    public int Great_Axes;
    public int Great_Swords;
    public int Heavy_Armors;
    public int Illusion;
    public int Light_Armors;
    public int Long_Swords;
    public int Medium_Armors;
    public int Pickpocketing; 
    public int Restoration;
    public int Smithing;
    public int Staves;
    public int Shields;
    public int Short_Swords;
    public int Throwing_Weapons;
    //public int Throwing_Knives;
    public int Wands;
    public int Woodcutting;

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

   


    void Start()
    {
        console = GameObject.Find("ConsolePanel").GetComponent<ConsoleManager>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= 1.5f)
        {
            RegenerateStats();
            time = 0;
        }
        if(currentHealth <= 0)
        {
          
            this.gameObject.GetComponent<DeathController>().ExecuteDeathRoutine();
            //this.gameObject.GetComponent<DeathController>().isDead = true;
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

        playerLevel = loadedStats.playerLevel;



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
     Throwing_Weapons = loadedStats.Throwing_Weapons;
     Cross_Bows = loadedStats.Cross_Bows;
    // Throwing_Weapons = loadedStats.Throwing_Daggers;
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

    /*@
     * Returns the xp until the next level
     */
    public int CheckIfLevelGained(int xp, int currentLevel)
    {     
            return ((80 * currentLevel) + ((int)Mathf.Pow(currentLevel, 2)) + ((int)Mathf.Pow(currentLevel - 1, 2))) - xp;
    }

    public void GrantXPAndCheckIfLevelGained(int xp, string baseStatName)
    {
        int totalXP = xp;
        System.Reflection.FieldInfo skillLevel, skillXP;
        try
        { 
            skillLevel = this.GetType().GetField(baseStatName);
            skillXP = this.GetType().GetField("xp" + baseStatName);
        }
        catch (Exception e)
        {
            //Debug.Log($"Could not find skill matching {baseStatName}");
            return;
        }
        totalXP += (int)skillXP.GetValue(this);

        skillXP.SetValue(this, totalXP);


        int xpLeft = CheckIfLevelGained(totalXP, (int)skillLevel.GetValue(this));
        while (xpLeft <= 0) //level gained
        {
            skillLevel.SetValue(this, (int)skillLevel.GetValue(this) + 1);
            skillXP.SetValue(this, xpLeft*-1);
            xpLeft = CheckIfLevelGained((int)skillXP.GetValue(this), (int)skillLevel.GetValue(this));
            console.AddConsoleMessage1($"Your skill has increased with {getStatName(baseStatName)}!");
            console.AddConsoleMessage1($"You are now level <color={Colors.gold}> {(int)skillLevel.GetValue(this)}</color>!");

        }
        
    }

    private string getStatName(string original)
    {
        String[] array = original.Split('_');
        StringBuilder newString = new StringBuilder();
        for(int i = 0; i<array.Length; i++)
        {
            newString.Append(array[i]);
            if(i!=array.Length - 1)
            {
                newString.Append(" ");
            }
        }
        return newString.ToString();
    }


}
