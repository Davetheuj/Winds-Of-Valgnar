using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StatusController : MonoBehaviour
{

    public Transform playerHealthBar;
    public Transform playerManaBar;

    public StatsController stats;

    public TMP_Text playerManaText;
    public TMP_Text playerHealthText;

    public PlayerTargeting targeting; //need to set this in the inspector

    public Transform NPCHoverHealthbar;
    public TMP_Text NPCHoverHealthText;
    public TMP_Text NPCHoverNameText;

    public Transform NPCTargetHealthbar;
    public TMP_Text NPCTargetHealthText;
    public TMP_Text NPCTargetNameText;

    public GameObject damageText;




    public void UpdateStatusUI()
    {
        playerHealthBar.localScale = new Vector3(stats.currentHealth / (float)stats.maxHealth, 1, 1);
        playerManaBar.localScale = new Vector3(stats.currentMana / (float)stats.maxMana, 1, 1);

        playerHealthText.text = "" + stats.currentHealth + "/" + stats.maxHealth;
        playerManaText.text = "" + stats.currentMana + "/" + stats.maxMana;
    }

    public void UpdateHoverNPCHealthBar(float currentHealth, float maxHealth)
    {
        if (currentHealth/maxHealth >= 0)
        {
            NPCHoverHealthbar.localScale = new Vector3(currentHealth / maxHealth, 1, 1);
            NPCHoverHealthText.text = $"{currentHealth}/{maxHealth}";
        }
        else
        {
            NPCHoverHealthbar.localScale = new Vector3(0, 1, 1);
            NPCHoverHealthText.text = $"0/{maxHealth}";
        }
    }

    public void UpdateHoverNPCName(string name)
    {
        NPCHoverNameText.text = name;
    }

    public void UpdateTargetNPCHealthBar(float currentHealth, float maxHealth)
    {
        if (currentHealth / maxHealth >= 0)
        {
            NPCTargetHealthbar.localScale = new Vector3(currentHealth / maxHealth, 1, 1);
            NPCTargetHealthText.text = $"{currentHealth}/{maxHealth}";
        }
        else
        {
            NPCTargetHealthbar.localScale = new Vector3(0, 1, 1);
            NPCTargetHealthText.text = $"0/{maxHealth}";
        }

}

    public void UpdateTargetNPCName(string name)
    {
        NPCTargetNameText.text = name;
}

    public void SpawnDamageText(int damage, GameObject parent, float damagePanelOffset, float distance)
    {
        damageText.transform.position = new Vector3(0, damagePanelOffset - damagePanelOffset / 10, 0);//, parent.transform.rotation);
        damageText.transform.LookAt(GameObject.Find("Main Camera").GetComponent<Camera>().transform, new Vector3(0,1,0));
        damageText.transform.Rotate(new Vector3(0, 180, 0));
        damageText.GetComponent<TMP_Text>().text = $"{damage}";
        damageText.GetComponent<TMP_Text>().fontSize = distance;
       
        Instantiate(damageText, parent.transform);
       
    }

    
}
