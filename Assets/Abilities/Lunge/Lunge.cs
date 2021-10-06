using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lunge : MonoBehaviour
{
    

    public GameObject target;
    // public GameObject origin;


    public GameObject weapon;
    public float rotationY;
    public float translationSpeed;
    public float rotationSpeed;
    private float time;
    public float strengthModifier;
    public string abilityName;

    public int spellType;

    public int damage;

    public GameObject player;

    public ConsoleManager console;

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        weapon = GameObject.Find("Hand_R").GetComponentInChildren<Item>().gameObject;
        damage = (int)(player.GetComponent<StatsController>().currentStrength / strengthModifier);
        player.GetComponent<StatsController>().GrantXPAndCheckIfLevelGained(100, "shortSword");
   
       

        console = GameObject.Find("ConsolePanel").GetComponent<ConsoleManager>();
        console.AddConsoleMessage1($"You <color={Colors.cyan}>{abilityName}</color>!");

        //attaches the LungeTRController script (In the lunge prefab as a child object) to the weapon for animation
        Transform trController = this.gameObject.transform.GetChild(0);
        trController.SetParent(weapon.transform);
        trController.GetComponent<LungeTRController>().enabled = true;


    }

    // Update is called once per frame
    void Update()
    {

        //increase time
        time += Time.deltaTime;

        //DESTROY THE OBJECT
        if (time > 30)
        {
            //This will destroy the ability rather than the weapon itself (lunge gameobject)
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter(Collider col)
    {
        print("Collider name: " + col.gameObject.name);

        if (col.gameObject.Equals(target))
        {
            //  CmdSpawnExplosion();
            damage = (int)(damage * Random.value);
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
