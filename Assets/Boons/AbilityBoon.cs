using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBoon : MonoBehaviour
{

    private ConsoleManager console;
    
    [SerializeField]
    private AudioClipController audioController;
    
    [SerializeField]
    private GameObject abilityToGive;

    private AbilityController abilityController;

    [SerializeField]
    private string abilityName;

    // Start is called before the first frame update
    void Start()
    {
        console = GameObject.Find("ConsolePanel").GetComponent<ConsoleManager>();
        abilityController = GameObject.Find("Player").GetComponent<AbilityController>();
        audioController = gameObject.GetComponent<AudioClipController>();

        GameObject abilitySlot = abilityController.GetFirstEmptySlot();
        
        if (abilitySlot == null)
        {
            //errorScript.SetErrorText("Inventory is full!", .5f);
            return;
        }

        var abilityObject = Instantiate(abilityToGive, abilitySlot.transform);
   
            console.AddConsoleMessage1($"You've learned how to cast <color={Colors.cyan}>{abilityName}</color>!");
        
        audioController.PlayClip(null, 0, .7f, false, 0, false, true, true, "Effects");
        abilityObject.transform.localPosition = new Vector3(0, 0, 0);
        abilityObject.transform.localScale = new Vector3(1, 1, 1);

        //Check for quest components here
        if (gameObject.GetComponent<TipTrigger>() != null)
        {
            gameObject.GetComponent<TipTrigger>().TriggerToolTip();
        }
        Destroy(this.gameObject);

    }

}
