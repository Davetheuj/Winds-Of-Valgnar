using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string classification;
    public float classMultiplier;
    public string NPCResistanceModifier;
    public bool isAttacking;

    private int damage;
    [SerializeField]
    private float weaponStrength;

    private ConsoleManager console;
    private StatsController playerStats;
    [SerializeField]
    private int experienceModifier = 1;

    public SpatialTRController[] animations; //Attach the TR controller scripts to the equipment in the editor

    private void Start()
    {
        console = GameObject.Find("ConsolePanel").GetComponent<ConsoleManager>();
        playerStats = GameObject.Find("Player").GetComponent<StatsController>();
        //equipment = GameObject.Find("Player").GetComponent<EquipmentController>();

        animations = this.gameObject.GetComponents<SpatialTRController>();
    }
    
    void OnTriggerEnter(Collider col)
    {
        if(isAttacking && col.gameObject.GetComponent<NPC>() != null)
        {
            NPC npc = col.gameObject.GetComponent<NPC>();

            damage = CalculateDamage(npc);
            npc.DealDamageToNpc(damage);
            console.AddConsoleMessage1($"You deal {damage} damage to {npc.npcName}!");

            this.gameObject.GetComponentInParent<StatsController>().GrantXPAndCheckIfLevelGained(damage * experienceModifier, classification);
            isAttacking = false;
        }

    }

    private int CalculateDamage(NPC npc)
    {
        float classificationStat = (float)((int)playerStats.GetType().GetField(classification).GetValue(playerStats));
        float damageBeforeResistances = classMultiplier * classificationStat;
        float resistedDamage = ((float)npc.GetType().GetField(NPCResistanceModifier).GetValue(npc) / 100) * damageBeforeResistances;

        int maxDamage = (int)(damageBeforeResistances - resistedDamage); 
        return ((int)(Random.Range(0, maxDamage)));
    }

    public void SelectAndEnableRandomAnimation()
    {
        int rand = Random.Range(0, animations.Length); //min value is inclusive max value is exclusive >.>
        //Debug.Log($"Enabling random animation of index: {rand} from Equipment.cs");
        isAttacking = true;
        animations[rand].enabled = true;
    }
}
