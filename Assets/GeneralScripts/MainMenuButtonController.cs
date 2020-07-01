using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonController : MonoBehaviour
{

   

    public void OnDemoButtonPressed()
    {
        SceneManager.LoadSceneAsync("Loading");
        
        //SceneManager.UnloadSceneAsync("GameStart");

    }
}
