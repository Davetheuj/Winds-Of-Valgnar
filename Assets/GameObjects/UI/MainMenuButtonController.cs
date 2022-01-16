using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonController : MonoBehaviour
{
    GameObject mainMenuCanvas;
    GameObject newPlayerCanvas;
    GameObject loadCanvas;
   

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
