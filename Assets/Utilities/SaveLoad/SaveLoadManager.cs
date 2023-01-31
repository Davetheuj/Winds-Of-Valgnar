using Assets.GameObjects.Characters.Player.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadManager : MonoBehaviour
{
    public GameObject player;
    public Scene scene;
    public StatusController statusController;
    private List<String> tempZonesToPermSave = new List<String>();
    private ConsoleManager console;

    public GameObject deathCanvas; //probably a more eloquent way to approach this...


    /// <summary>
    ///Saves the player as well as
    ///Moving temp zone saves to perm
    ///and clearing list.
    /// </summary>
    public void SavePlayer()
    {
        //player = GameObject.Find("Player");
        WoVBinarySerializer.SavePlayer(player);
        WoVBinarySerializer.TransferTempToPerm(player.GetComponent<StatsController>().playerName);
        console.AddConsoleMessage1("Save successful!");
        //Debug.Log("Saved the player");
        
    }

    /// <summary>
    /// 0 for temp save, else for permanent
    /// if new temp save, added to temp list for perm save later.
    /// </summary>
    public void SaveZone()
    {
        //Debug.Log($"Attempting to save properties from Scene {SceneManager.GetActiveScene().name}");
        scene = SceneManager.GetActiveScene();
        player = GameObject.Find("Player");
       
            WoVBinarySerializer.SaveZoneDataTemporary(scene, player);
           
       
           
       
        //Debug.Log("Saved the Zone's Data.");
        
    }

    public StatsController LoadPlayer()
    {
        Debug.Log("LoadPlayer() called from SL");
        player.GetComponent<PlayerSettings>().SetPlayerSettingsFromLoad(WoVBinarySerializer.LoadPlayerSettings(player));
        //player = GameObject.Find("Player");
        PlayerData loadedPlayer = WoVBinarySerializer.LoadPlayer(player);

        player.GetComponent<StatsController>().zoneName = loadedPlayer.zoneName;
        //Position
        player.transform.position = new Vector3(loadedPlayer.loc[0], loadedPlayer.loc[1], loadedPlayer.loc[2]);
        //rotation
        player.transform.rotation = new Quaternion(loadedPlayer.rot[0], loadedPlayer.rot[1], loadedPlayer.rot[2], loadedPlayer.rot[3]);
        //Stats
        player.GetComponent<StatsController>().SetStatsFromLoad(loadedPlayer.playerStats);


        //Inventory
        //Abilities
        //Quests
        player.GetComponent<QuestController>().SetQuestControllerFromLoad(loadedPlayer.playerQuests);
        //Journal
        player.GetComponent<JournalController>().SetJournalFromLoad(loadedPlayer.playerJournal);
        //Equipment
        //Other personalized settings?

        //Camera


        statusController.UpdateStatusUI();
        
        WoVBinarySerializer.ClearTempSaves(player.GetComponent<StatsController>().playerName); //clearing temporary zone data
        //Debug.Log("Loaded the player");

        return player.GetComponent<StatsController>();
    }
    public void LoadZone()
    { 
        scene = SceneManager.GetActiveScene();
        //player = GameObject.Find("Player");
        //Debug.Log($"Loading {scene.name}, here is some stuff to show information is being saved correctly");
        ZoneData loadedZone = WoVBinarySerializer.LoadZoneData(scene.name, player);
        //NPC Transforms
        int npcCounter = 0;
        foreach(string npcName in loadedZone.NPCSTransformNames)
        {
            GameObject go = GameObject.Find(npcName);
            go.transform.position = new Vector3(loadedZone.NPCSPositionX[npcCounter], loadedZone.NPCSPositionY[npcCounter], loadedZone.NPCSPositionZ[npcCounter]);

           go.transform.rotation = new Quaternion(loadedZone.NPCSRotationX[npcCounter], loadedZone.NPCSRotationY[npcCounter], loadedZone.NPCSRotationZ[npcCounter], loadedZone.NPCSRotationW[npcCounter]);
            npcCounter++;
        }
        //Physics.SyncTransforms();
        //NPC Dialogue Controllers
        int npcDialogueCounter = 0;
        foreach(string npcName in loadedZone.NPCDialogueNames)
        {
           
           GameObject.Find(npcName).GetComponent<NPCDialogueController>().SetControllerFromLoad(loadedZone.NPCDialogueControllers[npcDialogueCounter]);
           
                npcDialogueCounter++;
        }
        //Ground Items
        //Spawners
    }
  
    //public void LoadZone(string zoneName)
  //  {
  //      scene = SceneManager.GetSceneByName(zoneName);
  //      player = GameObject.Find("Player");
  //      //Debug.Log($"Loading {zoneName}, here is some stuff to show information is being saved correctly");
  //      ZoneData loadedZone = WoVBinarySerializer.LoadZoneData(scene.name, player);

  //      foreach (float npcPositionX in loadedZone.NPCSPositionX)
  //      {
  //          //Debug.Log($"PositionX: {npcPositionX}");
  //      }
  //      //NPCS
  //      //Ground Items
  //  }

    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        console = GameObject.Find("ConsolePanel").GetComponent<ConsoleManager>();

    }

    public void FullLoad()
    {

        Debug.Log("FullLoad() called from SL");
        StatsController playerStats= LoadPlayer();
        deathCanvas.SetActive(false);
        try
        {
            //SceneManager.LoadScene(manager.player.GetComponent<StatsController>().zoneName);
            SceneManager.LoadScene(playerStats.zoneName);
            
        }
        catch (Exception e)
        {
            Debug.Log("Couldn't find zoneName in playerstatscontroller. Loading the predetermined start scene instead from SL");
            SceneManager.LoadScene("CryptOfTheAncients");
        }


       
    }

    private void OnLevelWasLoaded(int level)
    {
        LoadZone(); //this will be called after FullLoad (or any time the scene is changed)
    }

}
