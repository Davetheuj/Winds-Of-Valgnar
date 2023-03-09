using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{

    public float castDuration;
    public int incrementor;
    private float time;
    public Transform startPos;
    public Transform endPos;

    // Start is called before the first frame update
    void Start()
    {
        transform.parent = GameObject.Find("Main Camera").transform;
        transform.position  = transform.parent.position + new Vector3(0, -.5f, 1);
        transform.rotation = transform.parent.rotation;


    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > castDuration)
        {
            DestroyImmediate(this.gameObject);
        }
    }



    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.GetComponent<NPC>() != null)
        {
            NPC npc = collision.gameObject.GetComponent<NPC>();

            
            npc.DealDamageToNpc(10);

            //Instantiate(hitParticle, col.ClosestPoint(transform.position), Quaternion.LookRotation(col.transform.position - col.ClosestPoint(transform.position)));

            //console.AddConsoleMessage1($"You deal {damage} damage to {npc.npcName}!");

            GameObject.Find("Player").GetComponent<StatsController>().GrantXPAndCheckIfLevelGained(100 , "Destruction");
            //isAttacking = false;
        }

    }

}
