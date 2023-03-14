using Assets.GameObjects.Characters.Player.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public SaveLoadManager slManager;

    public String startScene = "CryptOfTheAncients";

    public InterfaceController interfaceController;



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
        
        //SetAmbientMusicVolume(.3f);
        persistentObjects.SetActive(true);

        //try
        //{
        //    player = slManager.LoadPlayer();
        //}
        //catch (Exception e)
        //{
        //    Debug.Log(e);
        //}

        //try
        //{
        //    //SceneManager.LoadScene(manager.player.GetComponent<StatsController>().zoneName);
        //    //SceneManager.LoadScene(player.zoneName);
        //    slManager.FullLoad();
        //}
        //catch (Exception e)
        //{
        //    Debug.Log("Couldn't find zoneName in playerstatscontroller. Loading the predetermined start scene instead");
        //    SceneManager.LoadScene(startScene);
        //}

        persistentObjects.SetActive(true);
        SceneManager.LoadScene(startScene);
        slManager.SavePlayer();
        WoVBinarySerializer.SavePlayerSettings(playerStats.gameObject);


        
        PlayerSettings ps = GameObject.Find("Player").GetComponent<PlayerSettings>();
        interfaceController.UpdateSettingsUI(ps);



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

    public void SetAmbientMusicVolume(float volume = .5f)
    {
        volume = Mathf.Clamp(volume, 0, 1);
        GameObject.Find("SoundTrack").GetComponent<AudioSource>().volume = volume;
    }


}
