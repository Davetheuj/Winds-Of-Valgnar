using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{

    private Transform lineStart; //GameObject attached at the end of the fishing rod;
    private GameObject fishingRodUI;
    private GameObject fishingRod;
    private GameObject fishingLine;

    private GameObject player;
    private GameObject camera;

    [SerializeField]
    private GameObject linePrefab;

    private InventoryController inventoryController;
    private StatsController statsController;
    
    [SerializeField]
    private Vector3 fishingRodInitialPosition;

    [SerializeField]
    private Quaternion fishingRodInitialRotation;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        inventoryController = player.GetComponent<InventoryController>();
        statsController = player.GetComponent<StatsController>();
        camera = player.GetComponentInChildren<Camera>().gameObject;

        fishingRodUI = inventoryController.FindObjectByNameContains("Fish");
        if (fishingRodUI == null)
        {
            Debug.Log("Couldn't find fishing rod");
            Destroy(this.gameObject);
            return;
        }
        fishingRod = Instantiate(fishingRodUI.GetComponent<ItemInfo>().modelPrefab, player.transform);
        fishingRod.transform.localPosition = fishingRodInitialPosition;
        fishingRod.transform.localRotation = fishingRodInitialRotation;
        lineStart = fishingRod.transform.GetChild(0).transform;
        //fishingLine = Instantiate(linePrefab, lineStart);
       //Debug.Log($"line at {lineStart.position}");
       



        Debug.Log("Started Fishing!");
    }

    // Update is called once per frame
    void Update()
    {

    }
}