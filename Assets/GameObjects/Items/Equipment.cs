using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Equipment : MonoBehaviour
{
    public int slotType;
    public EquipmentController equipment;
    public int[] shapeKeyValues = new int[6];
    

    public int modifierHitPoints;
    public int modifierMana;
    public int modifierStrength;
    public int modifierIntelligence;
    public int modifierWisdom;
    public int modifierDexterity;
    public int modifierSpirit;
    public int modifierResolve;
    public int modifierLuck;
    public int modifierCharisma;

    public int resistanceArmor;
    public int resistanceHoly;
    public int resistanceVoid;
    public int resistanceFire;
    public int resistanceWater;
    public int resistanceElectric;
    public int resistanceEarth;

    public SpatialTRController[] animations; //Attach the TR controller scripts to the equipment in the editor

    public string weaponType;
    

    private void Start()
    {
        equipment = GameObject.Find("Player").GetComponent<EquipmentController>();

        animations = this.gameObject.GetComponents<SpatialTRController>();
    }

    public void SelectAndEnableRandomAnimation()
    {
        int rand = (int)Random.Range(0, animations.Length - .01f);
        Debug.Log($"Enabling random animation of index: {rand} from Equipment.cs");
        this.gameObject.GetComponent<Weapon>().isAttacking = true;
        animations[rand].enabled = true;
    }

   

    
}
