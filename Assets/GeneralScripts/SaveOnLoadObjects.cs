using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SaveOnLoadObjects : MonoBehaviour
{
    // Start is called before the first frame update
    public SaveLoadManager manager;
    public List<GameObject> objectList = new List<GameObject>();
    void Start()
    {
        DontDestroyOnLoad(this);
        foreach(GameObject gameComponent in objectList)
        {
            DontDestroyOnLoad(gameComponent);
        }
        try { manager.LoadPlayer(); } catch(Exception e)
        {
            Debug.Log(e);
        }
        try
        {
            SceneManager.LoadScene(manager.player.GetComponent<StatsController>().zoneName);
        }
        catch (Exception e)
        {
            SceneManager.LoadScene("AlphaZoneScene");
        }
        
    }

    public void RemoveFromList(GameObject objToRemove)
    {
        
    }
    public void AddObjectToList(GameObject objToAdd)
    {

    }
    public void VerifyList()
    {
        foreach (GameObject gameComponent in objectList)
        {
            DontDestroyOnLoad(gameComponent);
        }
    }


}
