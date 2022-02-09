using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadPlayerCanvasButtonController : MonoBehaviour
{
    public GameObject persistentObjects;
    public GameObject mainMenuCanvas;
    public Button loadButton;

    public StatsController playerStats;









    public void OnBackButtonPressed()
    {
        mainMenuCanvas.SetActive(true);
        this.gameObject.SetActive(false); 
    }

  

    private void OnLoadButtonPressed()
    {

    }


    public void SetAmbientMusicVolume(float volume = .5f)
    {
        volume = Mathf.Clamp(volume, 0, 1);
        GameObject.Find("SoundTrack").GetComponent<AudioSource>().volume = volume;
    }
}
