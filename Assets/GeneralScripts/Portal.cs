using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private GameObject player;
   public Vector3 destPos;
    public string destScene;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(player))
        {
            GameObject.Find("SaveLoadManager").GetComponent<SaveLoadManager>().SaveZone();
            player.GetComponent<SceneSwitcher>().target.transform.SetParent(player.transform);
            player.GetComponent<SceneSwitcher>().destination = destPos;
           SceneManager.LoadScene(destScene);
            
        }
      
       
        //SceneManager.UnloadSceneAsync("AlphaZoneScene");
    
      
    }

    public void Start()
    {
        player = GameObject.Find("Player");
    }
}
