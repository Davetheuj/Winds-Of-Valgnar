using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public Vector3 destination; //set this in the inspector in the script attached to the portal
    public float destinationRotation;
    public GameObject target;
    public SaveLoadManager manager;
    public bool needsDestination;
    public void OnLevelWasLoaded(int level)
    {
        
        target.SetActive(false);
       
        if (needsDestination)
        {
            gameObject.transform.position = destination;
            gameObject.transform.rotation = Quaternion.Euler(0,destinationRotation,0);
            needsDestination = false;
        }
    }




}
