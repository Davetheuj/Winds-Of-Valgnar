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
    public EquipmentController equipmentController;

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

    public int shortSword;
    public int longSword;
    public int greatSword;
    public int shield;
    public int axe;
    public int greatAxe;
    public int staff;
    public int wand;
    public int heavyArmor;
    public int mediumArmor;
    public int lightArmor;
    public int bow;
    public int throwingKnife;
    public int crossBow;
    public int throwingDagger;
    public int destruction;
    public int illusion;
    public int restoration;


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

    public int xpshortSword;
    public int xplongSword;
    public int xpgreatSword;
    public int xpshield;
    public int xpaxe;
    public int xpgreatAxe;
    public int xpstaff;
    public int xpwand;
    public int xpheavyArmor;
    public int xpmediumArmor;
    public int xplightArmor;
    public int xpbow;
    public int xpthrowingKnife;
    public int xpcrossBow;
    public int xpthrowingDagger;
    public int xpdestruction;
    public int xpillusion;
    public int xprestoration;

    public int generalXP;
    public int level = 1;


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
            Debug.Log("toggling isDead");
            this.gameObject.GetComponent<DeathController>().ExecuteDeathRoutine();
            this.gameObject.GetComponent<DeathController>().isDead = true;
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

        shortSword = loadedStats.shortSword;
        longSword = loadedStats.longSword;
        greatSword = loadedStats.greatSword;
        shield = loadedStats.shield;
        axe = loadedStats.axe;
        greatAxe = loadedStats.greatAxe;
        staff = loadedStats.staff;
        wand = loadedStats.wand;
        heavyArmor = loadedStats.heavyArmor;
        mediumArmor = loadedStats.mediumArmor;
        lightArmor = loadedStats.lightArmor;
        bow = loadedStats.bow;
        throwingKnife = loadedStats.throwingKnife;
        crossBow = loadedStats.crossBow;
        throwingDagger = loadedStats.throwingDagger;
        destruction = loadedStats.destruction;
        illusion = loadedStats.illusion;
        restoration = loadedStats.restoration;

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

        xpshortSword = loadedStats.xpshortSword;
        xplongSword = loadedStats.xplongSword;
        xpgreatSword = loadedStats.xpgreatSword;
        xpshield = loadedStats.xpshield;
        xpaxe = loadedStats.xpaxe;
        xpgreatAxe = loadedStats.xpgreatAxe;
        xpstaff = loadedStats.xpstaff;
        xpwand = loadedStats.xpwand;
        xpheavyArmor = loadedStats.xpheavyArmor;
        xpmediumArmor = loadedStats.xpmediumArmor;
        xplightArmor = loadedStats.xplightArmor;
        xpbow = loadedStats.xpbow;
        xpthrowingKnife = loadedStats.xpthrowingKnife;
        xpcrossBow = loadedStats.xpcrossBow;
        xpthrowingDagger = loadedStats.xpthrowingDagger;
        xpdestruction = loadedStats.xpdestruction;
        xpillusion = loadedStats.xpillusion;
        xprestoration = loadedStats.xprestoration;



        generalXP = loadedStats.generalXP;

        level = loadedStats.level;

    }

    /*@
     * Returns the xp until the next level
     */
    public int CheckIfLevelGained(int xp, int currentLevel)
    {     
            return ((80 * currentLevel) + ((int)Mathf.Pow(currentLevel, 2)) + ((int)Mathf.Pow(currentLevel - 1, 2))) - xp;
    }



}
