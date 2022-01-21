using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewPlayerCanvasButtonController : MonoBehaviour
{
    public GameObject persistentObjects;
    public GameObject mainMenuCanvas;
    public Button createButton;
    
    public StatsController playerStats;

    //NewPlayerCanvasFields
    public TMP_InputField lastNameInput;
    public TMP_InputField nameInputField;



    private void Update()
    {
        if (VerifyPlayer())
        {
            createButton.interactable = true;
        }
        else
        {
            createButton.interactable = false;
        }
    }



    public void OnBackButtonPressed()
    {
        mainMenuCanvas.SetActive(true);
        this.gameObject.SetActive(false); //this gameobject should be the newPlayercanvas itself.
    }

    public void OnCreateButtonPressed()
    {
        VerifyFirstName();
        VerifyLastName();
        SetPlayerStats();
        //Setting the persistent objects to true will initiate the game load sequence
        persistentObjects.SetActive(true);
    }

    private void SetPlayerStats()
    {
        playerStats.playerName = nameInputField.text;
        playerStats.zoneName = "CryptOfTheAncients";
    }

    private bool VerifyPlayer()
    {
        if (
            VerifyFirstName() &&
            VerifyLastName()
            )
        {


            return true;
        }
        return false;
    }

    private bool VerifyLastName()
    {
        //TODO
        if (true)
        {
            return true;
        }
        return false;
    }

    private bool VerifyFirstName()
    {
       if(nameInputField.text.Length >=1)
        {
            return true;
        }

        return false;
    }

    public void OnRandomNameButtonPressed()
    {
        nameInputField.text = Assets.Utilities.StringGenerators.GenerateRandomName();
    }


}
