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
    public bool needsDestination;
    public void OnLevelWasLoaded(int level)
    {
        
        target.SetActive(false);
        manager.LoadZone();
        if (needsDestination)
        {
            gameObject.transform.position = destination;
            needsDestination = false;
        }
    }




}
