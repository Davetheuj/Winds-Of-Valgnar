using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SampleSpellControl : MonoBehaviour
{
  public GameObject target;
// public GameObject origin;

   
    public GameObject explosion;
    public float rotationY;
    public float translationSpeed;
    public float rotationSpeed;
    private float time;
    public float intellectModifier;
    public string abilityName;
   
    public int spellType;

    public int damage;

    public GameObject player;

    public ConsoleManager console;
    
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        damage = (int)(player.GetComponent<StatsController>().currentIntellect / intellectModifier);
        target = player.GetComponent<PlayerTargeting>().currentTarget;
        //transform.SetParent(player.transform);
        transform.SetPositionAndRotation(player.transform.position,player.transform.rotation);
        console = GameObject.Find("ConsolePanel").GetComponent<ConsoleManager>();
        console.AddConsoleMessage1($"You cast <color={Colors.cyan}>{abilityName}</color> at <color={Colors.tan}>{target.GetComponent<NPC>().npcName}</color>!");

      
    }

        // Update is called once per frame
        void Update()
        {

       
      
      
            //increase time
            time += Time.deltaTime;      
            //update position
            transform.position += (transform.forward * translationSpeed * Time.deltaTime);
        var step = rotationSpeed * Time.deltaTime;
        // Rotate our transform a step closer to the target's.
      
        transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.LookRotation(target.transform.position+(new Vector3(0,target.GetComponent<NPC>().NPCPanelOffset/2,0))-transform.position,  Vector3.up), step);
        
        //DESTROY THE OBJECT
        if (time > 30)
            {
                Destroy(gameObject);
            }
        }


    void OnTriggerEnter(Collider col)
    {

        print("Collider name: " + col.gameObject.name);
        

        if (col.gameObject.Equals(target))
        {
            //  CmdSpawnExplosion();
            damage = (int) (damage * Random.value);
            target.GetComponent<NPC>().DealDamageToNpc(damage);
            console.AddConsoleMessage1($"<color={Colors.cyan}>{abilityName}</color> deals <color={Colors.red}>{damage}</color> damage to <color={Colors.tan}>{target.GetComponent<NPC>().npcName}</color>!");
            StartCoroutine(WaitAndDestroy());

        }
       
    }
    
   
    IEnumerator WaitAndDestroy()
    {

        yield return new WaitForSecondsRealtime(.025f);
        Destroy(gameObject);


       
    }


}