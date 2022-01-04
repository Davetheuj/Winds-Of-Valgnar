using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EquipmentController : MonoBehaviour

    
{

    public GameObject[] slots = new GameObject[11];
    public StatsController playerStats;
    public InventoryController inventory;
    public GameObject equipmentHoverInfoPanel;

    public SkinnedMeshRenderer playerBody;
    public float shapeKeyArms;
    public float shapeKeyChest;
    public float shapeKeyLegs;
    public float shapeKeyFeet;
    public float shapeKeyHead;
    public float shapeKeyBicep;



    //Eqip quick info
    public TMP_Text hitpoints;
    public TMP_Text mana;
    public TMP_Text strength;
    public TMP_Text intelligence;
    public TMP_Text wisdom;
    public TMP_Text dexterity;
    public TMP_Text spirit;
    public TMP_Text resolve;
    public TMP_Text luck;
    public TMP_Text charisma;

    public TMP_Text armor;
    public TMP_Text holy;
    public TMP_Text voidText;
    public TMP_Text fire;
    public TMP_Text water;
    public TMP_Text electric;
    public TMP_Text earth;

    //Equip Cummulative info

    public TMP_Text hitpointsTotal;
    public TMP_Text manaTotal;
    public TMP_Text strengthTotal;
    public TMP_Text intelligenceTotal;
    public TMP_Text wisdomTotal;
    public TMP_Text dexterityTotal;
    public TMP_Text spiritTotal;
    public TMP_Text resolveTotal;
    public TMP_Text luckTotal;
    public TMP_Text charismaTotal;

    public TMP_Text armorTotal;
    public TMP_Text holyTotal;
    public TMP_Text voidTotal;
    public TMP_Text fireTotal;
    public TMP_Text waterTotal;
    public TMP_Text electricTotal;
    public TMP_Text earthTotal;

    public int nHitpointsTotal;
    public int nManaTotal;
    public int nStrengthTotal;
    public int nIntelligenceTotal;
    public int nWisdomTotal;
    public int nDexterityTotal;
    public int nSpiritTotal;
    public int nResolveTotal;
    public int nLuckTotal;
    public int nCharismaTotal;

    public int nArmorTotal;
    public int nHolyTotal;
    public int nVoidTotal;
    public int nFireTotal;
    public int nWaterTotal;
    public int nElectricTotal;
    public int nEarthTotal;

    public void EquipItem(GameObject itemToEquip)
    {
        //run a requirement check here

        var slot = slots[itemToEquip.GetComponent<Equipment>().slotType];
        if (slot.transform.childCount >0)
        {

            //check to see if itemToEquip is oldItem to not add shapeKeys
           
            var oldItem = slot.transform.GetChild(0);

            if (oldItem.gameObject != itemToEquip)
            {
                itemToEquip.transform.SetParent(slot.transform);
                itemToEquip.transform.localPosition = new Vector3(0, 0, 0);
                itemToEquip.transform.localScale = new Vector3(1, 1, 1);
                itemToEquip.GetComponent<ItemDragController>().enabled = false;
                AddShapeKeys(itemToEquip);
            }

            oldItem.transform.SetParent(inventory.GetFirstEmptySlot().transform);
            oldItem.transform.localPosition = new Vector3(0, 0, 0);
            oldItem.transform.localScale = new Vector3(1, 1, 1);
            oldItem.GetComponent<ItemDragController>().enabled = true;
            RemoveShapeKeys(oldItem.gameObject);

        }
        else
        {
            itemToEquip.transform.SetParent(slot.transform);
            itemToEquip.transform.localPosition = new Vector3(0, 0, 0);
            itemToEquip.GetComponent<ItemDragController>().enabled = false;
            itemToEquip.transform.localScale = new Vector3(1, 1, 1);
            AddShapeKeys(itemToEquip);
        }


        SendShapeKeysToBody();
        CalculateAndUpdateCummulativeEquipmentModifiers();
    }

    public void SetTextColor(int stat, TMP_Text text)
    {
        text.text = "" + Mathf.Abs(stat);

        if (stat < 0)
        {
            text.color = Color.red;
        }
        else if (stat == 0)
        {
            text.color = Color.white;
        }
        else
        {
            text.color = Color.green;
        }


    }
    public void CalculateAndUpdateCummulativeEquipmentModifiers()
    {

        nHitpointsTotal = playerStats.maxHealth;
        nManaTotal = playerStats.maxMana;
        nStrengthTotal = playerStats.maxStrength;
        nIntelligenceTotal = playerStats.maxIntellect;
        nWisdomTotal = playerStats.maxWisdom;
        nDexterityTotal = playerStats.maxDexterity;
        nSpiritTotal = playerStats.maxSpirit;
        nResolveTotal = playerStats.maxResolve;
        nLuckTotal = playerStats.maxLuck;
        nCharismaTotal = playerStats.maxCharisma;

        nArmorTotal = 0;
        nHolyTotal = 0;
        nVoidTotal = 0;
        nFireTotal = 0;
        nWaterTotal = 0;
        nElectricTotal = 0;
        nEarthTotal = 0;
        
        foreach(GameObject item in slots)
        {
            if (item.transform.childCount != 0)
            {
                
                nHitpointsTotal += item.transform.GetChild(0).GetComponent<Equipment>().modifierHitPoints;
                nManaTotal += item.transform.GetChild(0).GetComponent<Equipment>().modifierMana;
                nStrengthTotal += item.transform.GetChild(0).GetComponent<Equipment>().modifierStrength;
                nIntelligenceTotal += item.transform.GetChild(0).GetComponent<Equipment>().modifierIntelligence;
                nWisdomTotal += item.transform.GetChild(0).GetComponent<Equipment>().modifierWisdom;
                nDexterityTotal += item.transform.GetChild(0).GetComponent<Equipment>().modifierDexterity;
                nSpiritTotal += item.transform.GetChild(0).GetComponent<Equipment>().modifierSpirit;
                nResolveTotal += item.transform.GetChild(0).GetComponent<Equipment>().modifierResolve;
                nLuckTotal += item.transform.GetChild(0).GetComponent<Equipment>().modifierLuck;
                nCharismaTotal += item.transform.GetChild(0).GetComponent<Equipment>().modifierCharisma;

                nArmorTotal += item.transform.GetChild(0).GetComponent<Equipment>().resistanceArmor;
                nHolyTotal += item.transform.GetChild(0).GetComponent<Equipment>().resistanceHoly;
                nVoidTotal += item.transform.GetChild(0).GetComponent<Equipment>().resistanceVoid;
                nFireTotal += item.transform.GetChild(0).GetComponent<Equipment>().resistanceFire;
                nWaterTotal += item.transform.GetChild(0).GetComponent<Equipment>().resistanceWater;
                nEarthTotal += item.transform.GetChild(0).GetComponent<Equipment>().resistanceEarth;
                nElectricTotal += item.transform.GetChild(0).GetComponent<Equipment>().resistanceElectric;
            }

        }

         SetTextColor( nHitpointsTotal, hitpointsTotal);
         SetTextColor(nCharismaTotal, charismaTotal);
         SetTextColor(nDexterityTotal, dexterityTotal);
         SetTextColor(nIntelligenceTotal, intelligenceTotal);
         SetTextColor( nLuckTotal, luckTotal);
         SetTextColor(nManaTotal, manaTotal);
         SetTextColor(nResolveTotal, resolveTotal);
         SetTextColor(nSpiritTotal, spiritTotal);
         SetTextColor(nStrengthTotal, strengthTotal);
         SetTextColor( nWisdomTotal, wisdomTotal);
         SetTextColor(nArmorTotal, armorTotal);
         SetTextColor( nEarthTotal, earthTotal);
         SetTextColor( nElectricTotal, electricTotal);
         SetTextColor( nFireTotal, fireTotal);
         SetTextColor(nHolyTotal, holyTotal);
         SetTextColor( nVoidTotal, voidTotal);
         SetTextColor(nWaterTotal, waterTotal);
    }

    public void AddShapeKeys(GameObject item)
    {
        Equipment equipment = item.GetComponent<Equipment>();
        shapeKeyLegs += equipment.shapeKeyValues[0];
        shapeKeyChest += equipment.shapeKeyValues[1];
        shapeKeyArms += equipment.shapeKeyValues[2];
        shapeKeyFeet += equipment.shapeKeyValues[3];
        shapeKeyBicep += equipment.shapeKeyValues[4];
        shapeKeyHead += equipment.shapeKeyValues[5];
    }
    public void RemoveShapeKeys(GameObject item)
    {
        Equipment equipment = item.GetComponent<Equipment>();
        shapeKeyLegs -= equipment.shapeKeyValues[0];
        shapeKeyChest -= equipment.shapeKeyValues[1];
        shapeKeyArms -= equipment.shapeKeyValues[2];
        shapeKeyFeet -= equipment.shapeKeyValues[3];
        shapeKeyBicep -= equipment.shapeKeyValues[4];
        shapeKeyHead -= equipment.shapeKeyValues[5];
    }
    public void SendShapeKeysToBody()
    {
        playerBody.SetBlendShapeWeight(0, shapeKeyLegs);
        playerBody.SetBlendShapeWeight(1, shapeKeyChest);
        playerBody.SetBlendShapeWeight(2, shapeKeyArms);
        playerBody.SetBlendShapeWeight(3, shapeKeyFeet);
        playerBody.SetBlendShapeWeight(4, shapeKeyBicep);
       // playerBody.SetBlendShapeWeight(5, shapeKeyHead);

    }

    private void Start()
    {
        Debug.Log("Equipment controller instantiated");
    }

}
