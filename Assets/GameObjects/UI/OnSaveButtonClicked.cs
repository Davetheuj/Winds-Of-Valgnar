using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnSaveButtonClicked : MonoBehaviour
{

    public void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            PressButton();
        });
    }
    private void PressButton()
    {
        GameObject.Find("SaveLoadManager").GetComponent<SaveLoadManager>().SaveZone();
        GameObject.Find("SaveLoadManager").GetComponent<SaveLoadManager>().SavePlayer();
        
        //Debug.Log("Save button clicked");
    }
}
