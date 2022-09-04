using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SaveOnLoadObjects : MonoBehaviour
{

    public SaveLoadManager manager;
    public List<GameObject> objectList = new List<GameObject>();
    public String startScene;
    void Start()
    {
        DontDestroyOnLoad(this);
        foreach(GameObject gameComponent in objectList)
        {
            DontDestroyOnLoad(gameComponent);
        }
       
        try 
        {
            manager.LoadPlayer(); 
        }
        catch(Exception e)
        {
            Debug.Log(e);
        }
       
        try
        {
            //SceneManager.LoadScene(manager.player.GetComponent<StatsController>().zoneName);
            SceneManager.LoadScene(startScene);
        }
        catch (Exception e)
        {
            SceneManager.LoadScene("AlphaZoneScene");
        }
        
    }



}
