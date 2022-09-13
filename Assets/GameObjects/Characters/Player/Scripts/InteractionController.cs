using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{

    
    public StatsController playerStats;
    public ErrorScript errorScript;
    public StatusController statusController;

    public float combatCooldown = .5f;
    public float cooldownTimer;

    public GameObject abilitySlot1;
    public GameObject abilitySlot2;
    public GameObject abilitySlot3;
    public GameObject abilitySlot4;
    public GameObject abilitySlot5;
    public GameObject abilitySlot6;
    public GameObject abilitySlot7;
    public GameObject abilitySlot8;
    public GameObject abilitySlot9;
    public GameObject abilitySlot10;

    public AbilityInstantiator abilityInstantiator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            if(cooldownTimer < combatCooldown)
            {
                return;
            }
           abilityInstantiator = abilitySlot1.GetComponentInChildren<AbilityInstantiator>();
            UseAbilitySlot();

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            if (cooldownTimer < combatCooldown)
            {
                return;
            }
            abilityInstantiator = abilitySlot2.GetComponentInChildren<AbilityInstantiator>();
            UseAbilitySlot();

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {

            if (cooldownTimer < combatCooldown)
            {
                return;
            }
            abilityInstantiator = abilitySlot3.GetComponentInChildren<AbilityInstantiator>();
            UseAbilitySlot();

        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {

            if (cooldownTimer < combatCooldown)
            {
                return;
            }
            abilityInstantiator = abilitySlot4.GetComponentInChildren<AbilityInstantiator>();
            UseAbilitySlot();

        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {

            if (cooldownTimer < combatCooldown)
            {
                return;
            }
            abilityInstantiator = abilitySlot5.GetComponentInChildren<AbilityInstantiator>();
            UseAbilitySlot();

        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {

            if (cooldownTimer < combatCooldown)
            {
                return;
            }
            abilityInstantiator = abilitySlot6.GetComponentInChildren<AbilityInstantiator>();
            UseAbilitySlot();

        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {

            if (cooldownTimer < combatCooldown)
            {
                return;
            }
            abilityInstantiator = abilitySlot7.GetComponentInChildren<AbilityInstantiator>();
            UseAbilitySlot();

        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {

            if (cooldownTimer < combatCooldown)
            {
                return;
            }
            abilityInstantiator = abilitySlot8.GetComponentInChildren<AbilityInstantiator>();
            UseAbilitySlot();

        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {

            if (cooldownTimer < combatCooldown)
            {
                return;
            }
            abilityInstantiator = abilitySlot9.GetComponentInChildren<AbilityInstantiator>();
            UseAbilitySlot();

        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {

            if (cooldownTimer < combatCooldown)
            {
                return;
            }
            abilityInstantiator = abilitySlot10.GetComponentInChildren<AbilityInstantiator>();
            UseAbilitySlot();

        }

    }

    private void UseAbilitySlot()
    {
      

        if (abilityInstantiator != null)//now to check ability prereqs
        {
          
            if (playerStats.currentMana < abilityInstantiator.manaCost)
            {
                errorScript.SetErrorText("You don't have enough mana!", .5f);
                return;

            }
            if (playerStats.currentHealth < abilityInstantiator.healthCost)
            {
                errorScript.SetErrorText("You don't have enough health!", .5f);
                return;

            }
            playerStats.currentMana -= abilityInstantiator.manaCost;
            playerStats.currentHealth -= abilityInstantiator.healthCost;
            statusController.UpdateStatusUI();
            abilityInstantiator.InstantiateAbility();
            cooldownTimer = 0;
        }
        else
        {
            errorScript.SetErrorText("No ability in slot!", .5f);
        }

    }
}
