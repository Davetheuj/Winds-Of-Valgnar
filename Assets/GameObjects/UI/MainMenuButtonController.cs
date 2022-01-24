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
   

    public void OnDemoButtonPressed()
    {
        //SceneManager.LoadSceneAsync("Loading");
        SetAmbientMusicVolume(.3f);
        persistentObjects.SetActive(true);

        
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
