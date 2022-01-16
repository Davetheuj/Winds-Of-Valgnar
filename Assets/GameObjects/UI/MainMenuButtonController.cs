using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonController : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject newPlayerCanvas;
    public GameObject loadCanvas;
   

    public void OnDemoButtonPressed()
    {
        SceneManager.LoadSceneAsync("Loading");
        
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
}
