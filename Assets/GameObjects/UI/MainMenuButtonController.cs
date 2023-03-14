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

    [SerializeField]
    private StatsController player;

    public String startScene = "CryptOfTheAncients";


    public void OnDemoButtonPressed()
    {
        //SetAmbientMusicVolume(.3f);
        //persistentObjects.SetActive(true);

        //try
        //{
           
        //    player = slManager.LoadPlayer();
        //}
        //catch (Exception e)
        //{

        //    Debug.LogError(e);
        //}

      
            //SceneManager.LoadScene(manager.player.GetComponent<StatsController>().zoneName);
            //SceneManager.LoadScene(player.zoneName);
            //slManager.FullLoad();
      
            ////Debug.Log(e.StackTrace);
            ////Debug.Log("Couldn't find zoneName in playerstatscontroller. Loading the predetermined start scene instead");
            ////SceneManager.LoadScene(startScene);
            //slManager.SavePlayer();
            //WoVBinarySerializer.SavePlayerSettings(player.gameObject);
        


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
