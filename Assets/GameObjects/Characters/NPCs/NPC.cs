using Assets.GeneralScripts.Math;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string npcName;
    //public float angleFromPlayerForward; //used for calculating targetable objects for the player
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
    [Tooltip("0Dead,1Agro,2Neutral")]
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
    [Tooltip("Default 10ish")]
    public float deltaNeutralRandModifier;
    [Tooltip("Default 3ish")]
    public float rotationLerpModifier;
    public StatusController statusController;
    private CharacterController characterController;
    private StatsController playerStats;

    private ConsoleManager console;

    private DropSpawner dropSpawner;

    //PATHFINDING
    private bool isStuck;
    private float stuckTimer;
    private float lastStuckCheckTime;
    public float maxStuckTime;
    private Vector3 stuckLocation;
    public float minTravelDistance;
    private List<Vector3> unstuckPath;
    private int unstuckPathCounter;

    public GameObject debugMarker;

    private AudioClipController audioClipController;

    public string attackClipName;
    public string walkClipName;
    public string neutralIdleClipName;
    public string agressiveIdleClipName;
    public string runClipName;
    public string deathClipName;
    public string hitClipName;

    
    

    void Start()
    {
        
        player = GameObject.Find("Player");
        playerStats = player.GetComponent<StatsController>();
        statusController = GameObject.Find("Status").GetComponent<StatusController>();
       characterController = gameObject.GetComponent<CharacterController>();
        console = GameObject.Find("ConsolePanel").GetComponent<ConsoleManager>();
        animator = gameObject.GetComponent<Animator>();
        audioClipController = GetComponent<AudioClipController>();
        

        
            neutralLocation = spawnLocation;

        try 
        {
          dropSpawner = GetComponent<DropSpawner>();
        }
        catch(MissingComponentException e)
        {
            //Debug.Log($"{npcName} doesn't have a drop spawner attached");
        }
    }

   
    void Update()
    {
        moveDirection = new Vector3();
        //angleFromPlayerForward = Mathf.Acos(Vector3.Dot(player.transform.forward.normalized, (player.transform.position-gameObject.transform.position).normalized));
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
            if(GetComponent<QuestPerpetuator>() != null)
            {
                QuestPerpetuator perp = GetComponent<QuestPerpetuator>();
                foreach (Quest quest in player.gameObject.GetComponent<QuestController>().questList)
                {

                    if (quest.questName == perp.questName)
                    {
                        //Debug.Log("Quest has been accepted previously");
                        if ((quest.currentStep >= perp.minStepInQuest) && (quest.currentStep <= perp.maxStepInQuest))
                        {
                            //Debug.Log("Correct step");
                            if (perp.journalEntry != "")
                            {
                               // journalController.CreateNewEntry(perp.journalEntry, 0);
                            }
                            if (perp.consoleEntries.Count > 0)
                            {
                                foreach (string entry in perp.consoleEntries)
                                {
                                    //consoleManager.AddConsoleMessage1(entry);
                                }
                            }
                            quest.currentStep += 1;
                            player.GetComponent<QuestController>().CheckForCompletion(quest);
                         
                        }
                     
                    }
                }
            }

            try {
                dropSpawner.SpawnDrops();
            }
            catch (NullReferenceException e)
            {
                //Debug.Log($"{npcName} does not have an dropSpawner Component attached");


            }
            try
            {
                gameObject.transform.parent.GetComponent<EntitySpawner>().isSpawned = false;
            }
            catch (NullReferenceException e)
            {
                //Debug.Log($"{npcName} 's parent does not have an entitySpawner Component attached");


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

            if (CheckIfInAttackRange()) //is in attack range
            {
                if (needsAnimationChange || wasOutOfRange)
                {
                    if (!string.IsNullOrEmpty(agressiveIdleClipName))
                    {
                        animator.Play(agressiveIdleClipName);
                    }
                    needsAnimationChange = false;
                    wasOutOfRange = false;
                   // //Debug.Log($"{npcName} playing idle_battle");
                }
                
                if (attackTimer >= attackDelay)
                {
                    if (!string.IsNullOrEmpty(attackClipName))
                    {
                        animator.Play(attackClipName);
                    }
                    DealDamageToPlayer(baseAttackStrength);
                    attackTimer = 0;
                    ////Debug.Log($"{npcName} playing attack1");

                }
                else 
                {
                    
                    
                    attackTimer += Time.deltaTime;
                }
            }
            else //not in attack range
            {
                if (!isStuck && CheckIfStuck())
                {
                    isStuck = true;
                    unstuckPath = FindNewPath();
                    if(unstuckPath.Count ==2)
                    {
                        isStuck = false;
                    }
                    unstuckPathCounter = 1;
                }
                if (!string.IsNullOrEmpty(runClipName))
                {
                    animator.Play(runClipName);
                }
                if (!isStuck)
                {
                    lookDirection = Mathf.Lerp(transform.rotation.eulerAngles.y, Quaternion.LookRotation(player.transform.position - transform.position).eulerAngles.y, moveSpeed * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, lookDirection, 0);
                    moveDirection = Vector3.Normalize(player.transform.position - transform.position);
                }
                else //now following the path layed out by the FindNewPath() function
                {
                    if ((transform.position - unstuckPath[unstuckPathCounter]).magnitude < 2f){
                        ////Debug.Log("Now moving towards new unstuck location");
                        unstuckPathCounter++;
                        if(unstuckPathCounter == unstuckPath.Count - 1)
                        {
                            isStuck = false;
                            unstuckPathCounter = 1;
                            
                            ////Debug.Log("Npc is no longer stuck");
                            return;
                        }
                    }
                    lookDirection = Mathf.Lerp(transform.rotation.eulerAngles.y, Quaternion.LookRotation(unstuckPath[unstuckPathCounter] - transform.position).eulerAngles.y, 5*moveSpeed * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, lookDirection, 0);
                    moveDirection = Vector3.Normalize(unstuckPath[unstuckPathCounter] - transform.position);

                }
               
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
                return;
            }
            else if (needsNeutralLocation)
            {
                neutralLocation = spawnLocation + new Vector3((UnityEngine.Random.value-.5f) * roamRadius*2, 0, UnityEngine.Random.value * roamRadius);
                deltaNeutralLocation = neutralLocation;
                deltaRoamTimer = 0;
                needsNeutralLocation = false;
               // //Debug.Log($"New neutral location found : {neutralLocation}");
            }
            else
            {
                if (neutralPositionTimer >= 5f) {
                    if (needsAnimationChange)
                    {
                        if (!string.IsNullOrEmpty(walkClipName))
                        {
                            animator.Play(walkClipName);
                        }
                        
                        
                        
                        needsAnimationChange = false;
                    }
                    if (deltaRoamTimer > deltaNeutralMaxTime)
                    {
                        float xRand = (UnityEngine.Random.value - .5f)*deltaNeutralRandModifier;
                        float zRand = (UnityEngine.Random.value - .5f)*deltaNeutralRandModifier;


                        deltaNeutralLocation = new Vector3(xRand,0,zRand) + neutralLocation;
                        deltaRoamTimer = 0;
                       // //Debug.Log($"new Delta Neutral Location: {deltaNeutralLocation}");
                    }
                    lookDirection = Mathf.Lerp(transform.rotation.eulerAngles.y, Quaternion.LookRotation(deltaNeutralLocation - transform.position).eulerAngles.y, Time.deltaTime*rotationLerpModifier);
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
                        if (!string.IsNullOrEmpty(neutralIdleClipName))
                        {
                            animator.Play(neutralIdleClipName);
                        }
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
        //Debug.Log($"player position {player.transform.position}" +
        //    $"npc position: {transform.position}" +
        //    $"Resulting font size: {(transform.position-player.transform.position).magnitude}");
        float fontSize = (transform.position - player.transform.position).magnitude * 2f;
        if(fontSize < 12)
        {
        fontSize = 12;
        }
       statusController.SpawnDamageText(damage, this.gameObject, NPCPanelOffset, fontSize);
        //statusController.SpawnDamageText(damage, this.gameObject, NPCPanelOffset, 14);
       
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
        if ((((transform.position - player.transform.position).magnitude <= baseAgroRange) && isDefaultAgro)|| (isAttacked)) //if close enough or attacked
        {
            if(state == 2)
            {
                try
                {
                    audioClipController.PlayClip();
                }catch(NullReferenceException e)
                {
                    //Debug.Log($"There's no audioClipController on {gameObject.name}");
                }
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
        stuckTimer += Time.time - lastStuckCheckTime;
        lastStuckCheckTime = Time.time;
        if(stuckTimer >= maxStuckTime)
        {
            stuckTimer = 0;
            if ((stuckLocation - transform.position).magnitude <= minTravelDistance)
            {
                //Debug.Log($"{gameObject.name} is stuck. (NPC.cs CheckIfStuck()");
                
                return true;
               
            }
            else {
                stuckLocation = transform.position;
            }

        }
        return false;

    }

    public List<Vector3> FindNewPath()
    {
        List<Vector3> path1Locations = new List<Vector3>();
        List<Vector3> path2Locations = new List<Vector3>();
        bool foundRightPath = false;
        bool foundLeftPath = false;
        Vector3 finalPos = player.gameObject.transform.position;
        Vector3 currentPos = transform.position;
        Vector3 initialPos = currentPos;
        Vector3 rotatedPos;
        Collider collider = null;
        float localRadius = this.gameObject.GetComponent<CharacterController>().radius;

        path1Locations.Add(initialPos);
        path2Locations.Add(initialPos);
        int aCounter = 0;

        while(!foundRightPath && aCounter<500)
        {
            //cast a ray to identify the object that is currently being collided with
            if (Physics.Linecast(currentPos,finalPos, out RaycastHit hitInfo))
            {
               
                collider = hitInfo.collider;
                if(collider.transform.root.name == "Player")
                {
                    foundRightPath = true;
                    path1Locations.Add(finalPos);
                    continue;
                }
                //Debug.Log($"Collider name: {collider.gameObject.name}, Pathing Object: {this.gameObject.name}");
                rotatedPos = (Quaternion.AngleAxis(30, Vector3.up) * (currentPos - collider.transform.position));
                currentPos = collider.ClosestPoint(rotatedPos + collider.transform.position) + (localRadius*3.5f * rotatedPos.normalized);
                //Debug.LogWarning($"{collider.gameObject.name}");
                path1Locations.Add(currentPos);
            }
            else
            {
                foundRightPath = true;
                path1Locations.Add(finalPos);
            }
            aCounter++;
        }
        ////Debug.Log($"Found Right Path - {path1Locations.Count - 2} intermediate points - {Pathing.PathLength(path1Locations)} length");
        currentPos = initialPos;
        while (!foundLeftPath && aCounter<1000)
        {
            //cast a ray to identify the object that is currently being collided with
            if (Physics.Linecast(currentPos, finalPos, out RaycastHit hitInfo))
            {
                collider = hitInfo.collider;
                if (collider.gameObject.name == "Player")
                {
                    foundLeftPath = true;
                    path2Locations.Add(finalPos);
                    continue;
                }
                rotatedPos = (Quaternion.AngleAxis(-30, Vector3.up) * (currentPos - collider.transform.position));
                currentPos = collider.ClosestPoint(rotatedPos + collider.transform.position) + (localRadius*3.5f * rotatedPos.normalized);
                //Debug.LogWarning($"{collider.gameObject.name}");
                path2Locations.Add(currentPos);
            }
            else
            {
                foundLeftPath = true;
                path2Locations.Add(finalPos);
            }
            aCounter++;
        }
       // //Debug.Log($"Found Left Path - {path2Locations.Count - 2} intermediate points - {Pathing.PathLength(path2Locations)} length");
        if (Pathing.PathLength(path1Locations) <= Pathing.PathLength(path2Locations)){
            foreach (Vector3 pos in path1Locations)
            {
                //Debug.Log(pos);
                GameObject.Instantiate(debugMarker, pos + new Vector3(0, 1, 0), this.transform.rotation);
            }
            return path1Locations;
        }
        else
        {
            foreach (Vector3 pos in path2Locations)
            {
                //Debug.Log(pos);
                GameObject.Instantiate(debugMarker, pos+new Vector3(0,1,0), this.transform.rotation);
            }
            return path2Locations;
        }

    }
    

}
