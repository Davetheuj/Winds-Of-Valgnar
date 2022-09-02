using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsPanelController : MonoBehaviour
{
    public StatsController pS;

    public TMP_Text strength;
    public TMP_Text dexterity;
    public TMP_Text wisdom;
    public TMP_Text luck;
    public TMP_Text charisma;
    public TMP_Text resolve;
    public TMP_Text intellect;
    public TMP_Text spirit;

    public TMP_Text Alchemy;
    public TMP_Text Axes;
    public TMP_Text Blunt_Weapons;
    public TMP_Text Bows;
    public TMP_Text Cooking;
    public TMP_Text Crafting;
    public TMP_Text Cross_Bows;
    public TMP_Text Destruction;
    public TMP_Text Enchanting;
    public TMP_Text Fishing;
    public TMP_Text Great_Axes;
    public TMP_Text Great_Swords;
    public TMP_Text Heavy_Armors;
    public TMP_Text Illusion;
    public TMP_Text Light_Armors;
    public TMP_Text Long_Swords;
    public TMP_Text Medium_Armors;
    public TMP_Text Pickpocketing;
    public TMP_Text Restoration;
    public TMP_Text Smithing;
    public TMP_Text Staves;
    public TMP_Text Shields;
    public TMP_Text Short_Swords;
    public TMP_Text Throwing_Weapons;
    //public TMP_Text Throwing_Knives;
    public TMP_Text Wands;
    public TMP_Text Woodcutting;

    public TMP_Text mana;
    public TMP_Text health;

    public TMP_Text renown;
    public TMP_Text popularity;
    public TMP_Text honor;

    public TMP_Text level;

    public TMP_Text playerName;

    public TMP_Text orderOfUndruil;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateStatsUI()
    {
        level.text = $"{pS.playerLevel}";
        strength.text = $"{pS.maxStrength}";
        intellect.text = $"{pS.maxIntellect}";
        wisdom.text = $"{pS.maxWisdom}";
        dexterity.text = $"{pS.maxDexterity}";
        resolve.text = $"{pS.maxResolve}";
        spirit.text = $"{pS.maxSpirit}";
        luck.text = $"{pS.maxLuck}";
        charisma.text = $"{pS.maxCharisma}";


        Alchemy.text = $"{ pS.Alchemy}";
        Axes.text = $"{pS.Axes}";
        Blunt_Weapons.text = $"{pS.Blunt_Weapons}";
        Bows.text = $"{pS.Bows}";
        Cooking.text = $"{pS.Cooking}";
        Crafting.text = $"{pS.Crafting}";
        Cross_Bows.text = $"{pS.Cross_Bows}";
        Destruction.text = $"{pS.Destruction}";
        Enchanting.text = $"{pS.Enchanting}";
        Fishing.text = $"{pS.Fishing}";
        Great_Axes.text = $"{pS.Great_Axes}";
        Great_Swords.text = $"{pS.Great_Swords}";
        Heavy_Armors.text = $"{pS.Heavy_Armors}";
        Illusion.text = $"{pS.Illusion}";
        Light_Armors.text = $"{pS.Light_Armors}";
        Long_Swords.text = $"{pS.Long_Swords}";
        Medium_Armors.text = $"{pS.Medium_Armors}";
        Pickpocketing.text = $"{pS.Pickpocketing}";
        Restoration.text = $"{pS.Restoration}";
        Smithing.text = $"{pS.Smithing}";
        Staves.text = $"{pS.Staves}";
        Shields.text = $"{pS.Shields}";
        Short_Swords.text = $"{pS.Short_Swords}";
        Throwing_Weapons.text = $"{pS.Throwing_Weapons}";
        //Throwing_Knives.text = $"{pS.Throwing_Knives}";
        Wands.text = $"{pS.Wands}";
        Woodcutting.text = $"{pS.Woodcutting}";
        honor.text = "" + pS.honor;
        renown.text = "" + pS.renown;
        popularity.text = "" + pS.popularity;
        mana.text = "" + pS.maxMana;
        health.text = "" + pS.maxHealth;
        playerName.text = "" + pS.playerName;

    }

    
}
