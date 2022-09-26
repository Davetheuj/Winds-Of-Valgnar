using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonController : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject newPlayerCanvas;
    public GameObject loadCanvas;
    public GameObject persistentObjects;

    public SaveLoadManager slManager;

    private StatsController player;

    public String startScene = "CryptOfTheAncients";


    public void OnDemoButtonPressed()
    {
        //SceneManager.LoadSceneAsync("Loading");
        SetAmbientMusicVolume(.3f);
        persistentObjects.SetActive(true);

        try
        {
            player = slManager.LoadPlayer();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

        try
        {
            //SceneManager.LoadScene(manager.player.GetComponent<StatsController>().zoneName);
            SceneManager.LoadScene(player.zoneName);
            slManager.LoadZone(player.zoneName);
        }
        catch (Exception e)
        {
            Debug.Log("Couldn't find zoneName in playerstatscontroller. Loading the predetermined start scene instead");
            SceneManager.LoadScene(startScene);
        }


        //SceneManager.UnloadSceneAsync("GameStart");

    }

    public void OnNewButtonPressed()
    {
        newPlayerCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);
    }

    public void OnLoadbuttonPressed()
    {
        loadCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);
    }

    public void OnPatchNotesButtonPressed()
    {

    }

    public void SetAmbientMusicVolume(float volume = .5f)
    {
        volume = Mathf.Clamp(volume, 0, 1);
        GameObject.Find("SoundTrack").GetComponent<AudioSource>().volume = volume;
    }
}
