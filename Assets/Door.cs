using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private GameObject player;

    public string doorName;
    public Vector3 destPos;
    public string destScene;

    public bool isPortal;


    public void OpenDoor()
    {
        if (isPortal)
        {
            GameObject.Find("SaveLoadManager").GetComponent<SaveLoadManager>().SaveZone();
            player.GetComponent<SceneSwitcher>().target.transform.SetParent(player.transform);
            player.GetComponent<SceneSwitcher>().destination = destPos;
            player.GetComponent<SceneSwitcher>().needsDestination = true;
            player.GetComponent<StatsController>().zoneName = destScene;
            SceneManager.LoadScene(destScene);

        }

    }

    public void Start()
    {
        player = GameObject.Find("Player");
    }
}
