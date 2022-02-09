using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string classification;
    public float classMultiplier;
    public string NPCResistanceModifier;
    [SerializeField]
    private bool isAttacking;

    private int damage;
    [SerializeField]
    private float weaponStrength;

    private ConsoleManager console;
    private StatsController playerStats;
    [SerializeField]
    private int experienceModifier = 1;

    public SpatialTRController[] animations; //Attach the TR controller scripts to the equipment in the editor

    private SpatialTRController currentAnimation;

    private Transform trueParentObject = null;

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

            GameObject.Find("Player").GetComponent<StatsController>().GrantXPAndCheckIfLevelGained(damage * experienceModifier, classification);
            //isAttacking = false;
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

    public void SelectAndEnableRandomAnimation(Transform objectToReturnTo)
    {
        int rand = Random.Range(0, animations.Length); //min value is inclusive max value is exclusive >.>
        //Debug.Log($"Enabling random animation of index: {rand} from Equipment.cs");
        isAttacking = true;
        currentAnimation = animations[rand];
        currentAnimation.enabled = true;
        Debug.Log($"Enabled animation - will return to {objectToReturnTo}");
        trueParentObject = objectToReturnTo;
    }

    private void Update()
    {
        //Debug.Log("(75)IsAttacking: "+isAttacking);
        //Debug.Log("(76)CurrentAnimationEnabled: " + currentAnimation.enabled);
        if(isAttacking && !currentAnimation.enabled)
        {
            Debug.Log("IsAttacking is now false");
            isAttacking = false;
            if(trueParentObject != null)
            {
                Debug.Log($"Setting to true parent object {trueParentObject}");
                transform.parent = trueParentObject;
                trueParentObject = null;

                transform.localPosition = gameObject.GetComponent<Item>().inventoryButtonPrefab.GetComponent<Equipment>().defaultLocalPosition;
                transform.localRotation = Quaternion.Euler(gameObject.GetComponent<Item>().inventoryButtonPrefab.GetComponent<Equipment>().defaultLocalRotation);
            }
        }
        
    }
}
