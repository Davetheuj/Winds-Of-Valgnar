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
    private StatsController player;
    void Start()
    {
       
       
        try 
        {
            player = manager.LoadPlayer(); 
        }
        catch(Exception e)
        {
            Debug.Log(e);
        }
       
        try
        {
            //SceneManager.LoadScene(manager.player.GetComponent<StatsController>().zoneName);
            SceneManager.LoadScene(player.zoneName);
            manager.LoadZone(player.zoneName);
        }
        catch (Exception e)
        {
            Debug.Log("Couldn't find zoneName in playerstatscontroller. Loading the predetermined start scene instead");
            SceneManager.LoadScene(startScene);
        }
        
    }



}
