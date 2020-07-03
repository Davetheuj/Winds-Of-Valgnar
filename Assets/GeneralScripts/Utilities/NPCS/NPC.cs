using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string npcName;
    public float angleFromPlayerForward; //used for calculating targetable objects for the player
    public GameObject player;
    public float NPCPanelOffset;
    public int maxHealth;
    public int currentHealth;
    public float attackRange;
    public float attackDelay;
    public float attackTimer;
    public float neutralPositionTimer;
    public float moveSpeed;
    public float baseAgroRange;
    //public List<NPCAttack> (max damage, cast chance, attack delays, animation clips)
    public int experience;
    public byte state =0;//0 for dead 1 for neutral 2 for aggressive 3 for looking at player 4 looking at spawn
    private Vector3 spawnLocation;
    private Vector3 moveDirection;


    public StatusController statusController;

    private CharacterController characterController;
    

   
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        statusController = GameObject.Find("Status").GetComponent<StatusController>();
       characterController = this.gameObject.GetComponent<CharacterController>();
    }

   
    void Update()
    {
        moveDirection = new Vector3();
        angleFromPlayerForward = Mathf.Acos(Vector3.Dot(player.transform.forward.normalized, (player.transform.position-gameObject.transform.position).normalized));
        if(currentHealth <= 0 && state!= 0)
        {
            state = 0;//npc is dead

        }

        if(state == 0)//dead
        {
            try
            {
                gameObject.transform.parent.GetComponent<EntitySpawner>().isSpawned = false;
            }catch(NullReferenceException e)
            {
                Debug.Log("gameObject's parent does not have an entitySpawner Component attached");
                
            }
           this.gameObject.SetActive(false);
            return;
        }
        CheckAggresion();
        if(state == 1)//aggressive
        {
            if (CheckIfInAttackRange())
            {
                if(attackTimer >= attackDelay)
                {
                    DealDamageToPlayer();
                    attackTimer = 0;
                }
                else 
                { 
                    attackTimer += Time.deltaTime;
                }
            }
            else //not in attack range
            {
                moveDirection = Vector3.Normalize(player.transform.position - transform.position);
                attackTimer += Time.deltaTime;
            }

        }
        else if(state == 2)//neutral
        {

        }

        moveDirection.y = Physics.gravity.y;
        characterController.Move(moveDirection*Time.deltaTime*moveSpeed);
        float lookDirection;
        lookDirection = Mathf.Lerp(transform.rotation.eulerAngles.y, Quaternion.LookRotation(player.transform.position-transform.position).eulerAngles.y,moveSpeed*Time.deltaTime) ;
        transform.rotation = Quaternion.Euler(0, lookDirection, 0);
    }



    public void DealDamageToNpc(int damage)
    {
        currentHealth -= damage;
        statusController.SpawnDamageText(damage, this.gameObject, NPCPanelOffset, (transform.position-player.transform.position).magnitude);
        if (statusController.targeting.currentTarget == this.gameObject)
        {
            if (currentHealth >= 0)
            {
                statusController.UpdateTargetNPCHealthBar(currentHealth,maxHealth);
            }
            else
            {
                statusController.UpdateTargetNPCHealthBar(0, maxHealth);
            }
        }
    }

    private void DealDamageToPlayer()
    {
        int damageDealt = (int)(UnityEngine.Random.value * 30);
        player.GetComponent<StatsController>().currentHealth -= damageDealt;
        statusController.UpdateStatusUI();
        statusController.SpawnDamageText(damageDealt, player, 0, 14);
    }
    private void SpawnItem()
    {

    }
    private void GrantXPToPlayer()
    {

    }
    private void CheckAggresion()
    {
        if ((transform.position - player.transform.position).magnitude <= baseAgroRange)
        {
            state = 1;
        }
        else
        {
            state = 2;
        }
    }
    private bool CheckIfInAttackRange()
    {
        if((transform.position - player.transform.position).magnitude <= attackRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    
}
