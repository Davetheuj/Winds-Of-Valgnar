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
    private bool isAttacked;
    public bool isStationary;
    public float NPCPanelOffset;
    public int maxHealth;
    public int currentHealth;

    public int baseAttackStrength;

    public float resistanceMelee;
    public float resistanceRanged;
    public float resistanceMagic;


    public int xpGranted;
    public int honorGranted;
    public int popularityGranted;
    public int renownGranted;



    public float attackRange;
    public float attackDelay;
    public float attackTimer;
    private float neutralPositionTimer;
    [Tooltip("Default 20ish")]
    public float moveSpeed;
    private float actualMoveSpeed;
    [Tooltip("Default 5ish")]
    public float baseAgroRange;
    private float lookDirection;
    [Tooltip("Default 30ish")]
    public int roamRadius;
    //public List<NPCAttack> (max damage, cast chance, attack delays, animation clips)
    
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
    [Tooltip("Default 2")]
    public float deltaNeutralMaxTime;
    [Tooltip("Default 15")]
    public float neutralPositionMaxTime;
    [Tooltip("Default 6")]
    public float neutPosTimeRandModifier;
    [Tooltip("Default 5ish")]
    public float maxIdleTime;
    public StatusController statusController;
    private CharacterController characterController;
    private StatsController playerStats;

    private ConsoleManager console;

    private DropSpawner dropSpawner;

    //PATHFINDING
    private bool isStuck;
    private float stuckTimer;
    public float maxStuckTime;
    private Ray stuckRay;
    private RaycastHit stuckHit;
    private GameObject stuckHitObject;
    private Vector3 stuckLocation;
    private float minTravelDistance;


    
    void Start()
    {
        
        player = GameObject.Find("Player");
        playerStats = player.GetComponent<StatsController>();
        statusController = GameObject.Find("Status").GetComponent<StatusController>();
       characterController = gameObject.GetComponent<CharacterController>();
        console = GameObject.Find("ConsolePanel").GetComponent<ConsoleManager>();
        animator = gameObject.GetComponent<Animator>();
        if (!isDefaultAgro)
        {
            state = 1;
        }
        
            neutralLocation = spawnLocation;

        try 
        {
          dropSpawner = GetComponent<DropSpawner>();
        }
        catch(MissingComponentException e)
        {
            Debug.Log($"{npcName} doesn't have a drop spawner attached");
        }
    }

   
    void Update()
    {
        moveDirection = new Vector3();
        angleFromPlayerForward = Mathf.Acos(Vector3.Dot(player.transform.forward.normalized, (player.transform.position-gameObject.transform.position).normalized));
        if(currentHealth <= 0 && state!= 0)
        {
           
            state = 0;//npc is dead
            console.AddConsoleMessage1($"<color={Colors.tan}>{npcName}</color> has died!");
            playerStats.honor += honorGranted;
            playerStats.renown += renownGranted;
            playerStats.popularity += popularityGranted;
           

        }

        if(state == 0)//dead
        {
           
                dropSpawner.SpawnDrops();
                gameObject.transform.parent.GetComponent<EntitySpawner>().isSpawned = false;
            //}catch(NullReferenceException e)
            //{
            //    Debug.Log($"{npcName} 's parent does not have an entitySpawner Component attached");

                
            //}
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
                    DealDamageToPlayer(baseAttackStrength);
                    attackTimer = 0;
              
                }
                else 
                {
                    
                    
                    attackTimer += Time.deltaTime;
                }
            }
            else //not in attack range
            {
                if (CheckIfStuck())
                {
                    FindNewPath();
                }
                animator.Play("run");
                moveDirection = Vector3.Normalize(player.transform.position - transform.position);
                attackTimer += Time.deltaTime;
                wasOutOfRange = true;
            }
            if (isAttacked)
            {
                if ((transform.position - spawnLocation).magnitude >= roamRadius * 3)
                {
                    isAttacked = false;
                }
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
        isAttacked = true;
        currentHealth -= damage;
        Debug.Log($"player position {player.transform.position}" +
            $"npc position: {transform.position}" +
            $"Resulting font size: {(transform.position-player.transform.position).magnitude}");
        float fontSize = (transform.position - player.transform.position).magnitude * 2f;
        if(fontSize < 12)
        {
        fontSize = 12;
        }
       statusController.SpawnDamageText(damage, this.gameObject, NPCPanelOffset, fontSize);
        //statusController.SpawnDamageText(damage, this.gameObject, NPCPanelOffset, 14);
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
        statusController.SpawnDamageText(damageDealt, player, 0, 12);
    }
    private void SpawnItem()
    {

    }
    private void GrantXPToPlayer()
    {

    }
    private void CheckAggresion()
    {
        if ((transform.position - player.transform.position).magnitude <= baseAgroRange || (isAttacked))
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

    private bool CheckIfStuck()
    {
        stuckTimer += Time.deltaTime;
        if(stuckTimer >= maxStuckTime)
        {
            if ((stuckLocation - transform.position).magnitude <= minTravelDistance)
            {
                Debug.Log($"{gameObject.name} is stuck.");
                return true;
               
            }
            else {
                stuckLocation = transform.position;
                stuckTimer = 0;
            }

        }
        return false;

    }

    public Vector3 FindNewPath()
    {
        return new Vector3(0, 0, 0);
    }
    

}
