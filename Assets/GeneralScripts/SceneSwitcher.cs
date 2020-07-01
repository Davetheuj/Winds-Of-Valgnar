using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public Vector3 destination; //set this in the inspector in the script attached to the portal
    public GameObject target;
    public SaveLoadManager manager;
    public void OnLevelWasLoaded(int level)
    {

        gameObject.transform.position = destination;
        target.SetActive(false);
        manager.LoadZone();
    }
   
   


}
