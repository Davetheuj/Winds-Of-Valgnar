using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string npcName;
    public float angleFromPlayerForward; //used for calculating targetable objects for the player
    public GameObject player;
    public bool isDefaultAgro;
    public bool isStationary;
    public float NPCPanelOffset;
    public int maxHealth;
    public int currentHealth;
    public float attackRange;
    public float attackDelay;
    public float attackTimer;
    private float neutralPositionTimer;
    public float moveSpeed;
    private float actualMoveSpeed;
    public float baseAgroRange;
    private float lookDirection;
    public int roamRadius;
    //public List<NPCAttack> (max damage, cast chance, attack delays, animation clips)
    public int experience;
    public byte state =0;//0 for dead 1 for neutral 2 for aggressive 3 for looking at player 4 looking at spawn
    public Vector3 spawnLocation;
    private Vector3 moveDirection;
    private Animator animator;
    private Vector3 neutralLocation;
    private bool needsNeutralLocation;
    private bool needsAnimationChange;
    private bool wasOutOfRange;
    private Vector3 deltaNeutralLocation; 
    private float deltaRoamTimer;
    public float deltaNeutralMaxTime;
    public float neutralPositionMaxTime;
    public float neutPosTimeRandModifier;
    public float maxIdleTime;
   

    



    public StatusController statusController;

    private CharacterController characterController;
    

   
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        statusController = GameObject.Find("Status").GetComponent<StatusController>();
       characterController = gameObject.GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();
        if (!isDefaultAgro)
        {
            state = 1;
        }
        
            neutralLocation = spawnLocation;
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
        if (isDefaultAgro)
        {
            CheckAggresion();
        }
        if(state == 1)//aggressive
        {
            actualMoveSpeed = moveSpeed;
            lookDirection = Mathf.Lerp(transform.rotation.eulerAngles.y, Quaternion.LookRotation(player.transform.position - transform.position).eulerAngles.y, moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, lookDirection, 0);
            if (CheckIfInAttackRange()) //is in attack range
            {
                if (needsAnimationChange || wasOutOfRange)
                {
                    animator.Play("idle_battle");
                    needsAnimationChange = false;
                    wasOutOfRange = false;
                }
                
                if (attackTimer >= attackDelay)
                {
                    animator.Play("attack1");
                    DealDamageToPlayer(30);
                    attackTimer = 0;
                   // Wait(.05f);
                    //animator.Play("idle_battle");
                }
                else 
                {
                    
                    
                    attackTimer += Time.deltaTime;
                }
            }
            else //not in attack range
            {
                animator.Play("run");
                moveDirection = Vector3.Normalize(player.transform.position - transform.position);
                attackTimer += Time.deltaTime;
                wasOutOfRange = true;
            }

        }
        else if(state == 2)//neutral
        {
            actualMoveSpeed = moveSpeed / 2f;
            if (isStationary)
            {

            }
            else if (needsNeutralLocation)
            {
                neutralLocation = spawnLocation + new Vector3((UnityEngine.Random.value-.5f) * roamRadius*2, 0, UnityEngine.Random.value * roamRadius);
                deltaNeutralLocation = neutralLocation;
                deltaRoamTimer = 0;
                needsNeutralLocation = false;
            }
            else
            {
                if (neutralPositionTimer >= 5f) {
                    if (needsAnimationChange)
                    {
                        
                        animator.Play("walk");
                        
                        
                        needsAnimationChange = false;
                    }
                    if (deltaRoamTimer > deltaNeutralMaxTime)
                    {
                        deltaNeutralLocation = (new Vector3(1,0,1) * (UnityEngine.Random.value -.5f)*10) + neutralLocation;
                        deltaRoamTimer = 0;
                    }
                    lookDirection = Mathf.Lerp(transform.rotation.eulerAngles.y, Quaternion.LookRotation(deltaNeutralLocation - transform.position).eulerAngles.y, Time.deltaTime*3);
                    transform.rotation = Quaternion.Euler(0, lookDirection, 0);
                  
                    moveDirection = transform.forward;
                    neutralPositionTimer += Time.deltaTime;
                    deltaRoamTimer += Time.deltaTime;
                    if ((transform.position-neutralLocation).magnitude < 1 || neutralPositionTimer > neutralPositionMaxTime)
                    {
                        needsNeutralLocation = true;
                        neutralPositionTimer = (UnityEngine.Random.value-.5f)*neutPosTimeRandModifier;
                        needsAnimationChange = true;
                    }
                }
                else
                {
                    if (needsAnimationChange)
                    {
                        animator.Play("idle");
                        needsAnimationChange = false;
                    }

                    neutralPositionTimer += Time.deltaTime;
                    if(neutralPositionTimer >= maxIdleTime)
                    {
                        
                        needsAnimationChange = true;
                    }
                }
            }

        }

        moveDirection.y = Physics.gravity.y;
        characterController.Move(moveDirection*Time.deltaTime*actualMoveSpeed);
        
        
        
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

    private void DealDamageToPlayer(int maxDamage)
    {
        int damageDealt = (int)(UnityEngine.Random.value * maxDamage);
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
            if(state == 2)
            {
                needsAnimationChange = true;
            }
            state = 1;
        }
        else
        {
            if(state == 1)
            {
                needsAnimationChange = true;
            }
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

    IEnumerator Wait(float time)
    {

        yield return new WaitForSecondsRealtime(time);
       



    }


}
