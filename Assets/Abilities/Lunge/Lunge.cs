using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lunge : MonoBehaviour
{
    

    
    public GameObject origin;

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
        //origin = this.transform.parent.gameObject;
        //player = GameObject.Find("Player");
        //weapon = GameObject.Find("Hand_R").GetComponentInChildren<Item>().gameObject;
        //damage = (int)(player.GetComponent<StatsController>().currentStrength / strengthModifier);
        //player.GetComponent<StatsController>().GrantXPAndCheckIfLevelGained(100, "Short_Swords");



        //console = GameObject.Find("ConsolePanel").GetComponent<ConsoleManager>();
        //console.AddConsoleMessage1($"You <color={Colors.cyan}>{abilityName}</color>!");

        ////attaches the LungeTRController script (In the lunge prefab as a child object) to the weapon for animation
        //Transform trController = this.gameObject.transform.GetChild(0);
        //trController.SetParent(weapon.transform);
        //trController.GetComponent<LungeTRController>().enabled = true;


        //Send message to main hand's Equipment Controller to compute damage, select a weapon animation to play,
        GameObject.Find("Hand_R").GetComponentInChildren<Equipment>().SelectAndEnableRandomAnimation();
        //Destroy this gameobject
        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {

    }



    IEnumerator WaitAndDestroy()
    {

        yield return new WaitForSecondsRealtime(.025f);
        Destroy(gameObject);
    }
}
