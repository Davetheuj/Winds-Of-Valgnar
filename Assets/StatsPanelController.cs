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
    public TMP_Text alchemy;
    public TMP_Text pickpocketing;
    public TMP_Text woodcutting;
    public TMP_Text crafting;
    public TMP_Text smithing;
    public TMP_Text fishing;
    public TMP_Text enchanting;
    public TMP_Text cooking;
    public TMP_Text mana;
    public TMP_Text health;
    public TMP_Text renown;
    public TMP_Text popularity;
    public TMP_Text honor;

    public TMP_Text playerName;
   
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateStatsUI()
    {
        strength.text = $"{pS.currentStrength}/{pS.maxStrength}";
        intellect.text = $"{pS.currentIntellect}/{pS.maxIntellect}";
        wisdom.text = $"{pS.currentWisdom}/{pS.maxWisdom}";
        dexterity.text = $"{pS.currentDexterity}/{pS.maxDexterity}";
        resolve.text = $"{pS.currentResolve}/{pS.maxResolve}";
        spirit.text = $"{pS.currentSpirit}/{pS.maxSpirit}";
        luck.text = $"{pS.currentLuck}/{pS.maxLuck}";
        charisma.text = $"{pS.currentCharisma}/{pS.maxCharisma}";
        smithing.text = ""+pS.Smithing;
        alchemy.text = ""+pS.Alchemy;
        crafting.text = ""+pS.Crafting;
        woodcutting.text = "" + pS.Woodcutting;
        enchanting.text = "" + pS.Enchanting;
        pickpocketing.text = "" + pS.Pickpocketing;
        cooking.text = "" + pS.Cooking;
        honor.text = "" + pS.honor;
        renown.text = "" + pS.renown;
        popularity.text = "" + pS.popularity;
        mana.text = "" + pS.maxMana;
        health.text = "" + pS.maxHealth;
        playerName.text = "" + pS.playerName;

    }

    
}
