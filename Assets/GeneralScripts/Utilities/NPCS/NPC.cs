using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string npcName;
    public float angleFromPlayerForward; //used for calculating targetable objects for the player
    public Transform playerTransform;
    public float NPCPanelOffset;
    public int maxHealth;
    public int currentHealth;
    public int experience;
    public byte state =0;//0 for dead 1 for neutral 2 for aggressive

    public StatusController statusController;
    

   
    

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
        statusController = GameObject.Find("Status").GetComponent<StatusController>();
    }

    // Update is called once per frame
    void Update()
    {
        angleFromPlayerForward = Mathf.Acos(Vector3.Dot(playerTransform.forward.normalized, (playerTransform.position-gameObject.transform.position).normalized));
        if(currentHealth <= 0 && state!= 0)
        {
            state = 0;//npc is dead

        }

        if(state == 0)
        {
            Destroy(this.gameObject);
        }

    }



    public void DealDamageToNpc(int damage)
    {
        currentHealth -= damage;
        statusController.SpawnDamageText(damage, this.gameObject, NPCPanelOffset, (transform.position-playerTransform.position).magnitude);
        if (statusController.targeting.currentTarget == this.gameObject)
        {
            if (currentHealth >= 0)
            {
                statusController.UpdateTargetNPCHealthBar(currentHealth,maxHealth);
            }
            else
            {
                statusController.UpdateTargetNPCHealthBar(currentHealth, maxHealth);
            }
        }
    }
    
}
