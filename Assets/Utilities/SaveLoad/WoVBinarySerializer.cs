using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public static class WoVBinarySerializer 
{
    

    public static void SavePlayer(GameObject player)
    {
        //if (SceneManager.GetActiveScene().name != "Loading")
        //{
        //    player.GetComponent<StatsController>().zoneName = SceneManager.GetActiveScene().name;
        //}
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(Application.persistentDataPath + "/SavedCharacters/"+ player.GetComponent<StatsController>().playerName+"/PlayerInfo.WoV"));
        }
        catch(Exception e)
        {
            //Debug.Log(e);
        }
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/SavedCharacters/" + player.GetComponent<StatsController>().playerName + "/PlayerInfo.WoV", FileMode.Create);
        PlayerData data = new PlayerData(player);
        formatter.Serialize(stream, data);
        stream.Close();
        //Debug.Log(Application.persistentDataPath);
    }

    public static PlayerData LoadPlayer(GameObject player)
    {
        if(File.Exists(Application.persistentDataPath + "/SavedCharacters/" + player.GetComponent<StatsController>().playerName + "/PlayerInfo.WoV"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/SavedCharacters/" + player.GetComponent<StatsController>().playerName + "/PlayerInfo.WoV", FileMode.Open);

            PlayerData playerData = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            //Debug.Log("Loaded the playerdata");
            return playerData;

        }
        else
        {
            //Debug.Log("File does not exist");
            return null;
        }
    }

    public static ZoneData LoadZoneData(string zoneName, GameObject player)
    {
        
       

        if (File.Exists(Application.persistentDataPath + "/SavedCharacters/" + player.GetComponent<StatsController>().playerName + $"/Temp/Zones/{zoneName}.WoV"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/SavedCharacters/" + player.GetComponent<StatsController>().playerName  + $"/Temp/Zones/{zoneName}.WoV", FileMode.Open);

            ZoneData zoneData = formatter.Deserialize(stream) as ZoneData;
            stream.Close();
            //Debug.Log($"Loaded Temporary Zone Data for {zoneName}.");
            return zoneData;

        }
        else if (File.Exists(Application.persistentDataPath + "/SavedCharacters/" + player.GetComponent<StatsController>().playerName + $"/Perm/Zones/{zoneName}.WoV"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/SavedCharacters/" + player.GetComponent<StatsController>().playerName + $"/Perm/Zones/{zoneName}.WoV", FileMode.Open);

            ZoneData zoneData = formatter.Deserialize(stream) as ZoneData;
            stream.Close();
            //Debug.Log($"Loaded Permanent Zone Data for {zoneName}.");
            return zoneData;

        }

        else
        {
            //Debug.Log($"File does not exist for {zoneName} as either temporary or permanent file.");
            return null;
        }
    }

    public static void SaveZoneDataTemporary(Scene scene, GameObject player)
    {
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(Application.persistentDataPath + "/SavedCharacters/" + player.GetComponent<StatsController>().playerName + $"/Temp/Zones/{scene.name}.WoV"));
        }
        catch (Exception e)
        {
            //Debug.Log(e);
        }
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/SavedCharacters/" + player.GetComponent<StatsController>().playerName + $"/Temp/Zones/{scene.name}.WoV", FileMode.Create);
       
        ZoneData data = new ZoneData(scene,player);
        formatter.Serialize(stream, data);
        stream.Close();

    }
    public static void SaveZoneDataPermanent(Scene scene, GameObject player)
    {
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(Application.persistentDataPath + "/SavedCharacters/" + player.GetComponent<StatsController>().playerName + $"/Perm/Zones/{scene.name}.WoV"));
        }
        catch (Exception e)
        {
            //Debug.Log(e);
        }
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/SavedCharacters/" + player.GetComponent<StatsController>().playerName + $"/Perm/Zones/{scene.name}.WoV", FileMode.Create);

        ZoneData data = new ZoneData(scene, player);
        formatter.Serialize(stream, data);
        stream.Close();

    } //not in use

    public static void SavePlayerSettings()
    {

    }
    public static void SaveZoneDataPermanent()
    {

    }

    public static void TransferTempToPerm( string playerName)
    {
        
        string sourcePath = Application.persistentDataPath + "/SavedCharacters/" + playerName + "/Temp/Zones/";
        string targetPath = Application.persistentDataPath + "/SavedCharacters/" + playerName + "/Perm/Zones/";

        System.IO.Directory.CreateDirectory(targetPath);

        if (System.IO.Directory.Exists(sourcePath))
        {
            string[] files = System.IO.Directory.GetFiles(sourcePath);

            // Copy the files and overwrite destination files if they already exist.
            foreach (string s in files)
            {
                // Use static Path methods to extract only the file name from the path.
               string fileName = System.IO.Path.GetFileName(s);
              string  destFile = System.IO.Path.Combine(targetPath, fileName);
                System.IO.File.Copy(s, destFile, true);
                File.Delete(s);

            }
        }
        else
        {
            Console.WriteLine("Source path does not exist!");
        }


        return;
    }
    public static void ClearTempSaves(string playerName)
    {
        string sourcePath = Application.persistentDataPath + "/SavedCharacters/" + playerName + "/Temp/Zones/";
        if (System.IO.Directory.Exists(sourcePath))
        {
            string[] files = System.IO.Directory.GetFiles(sourcePath);

           
            foreach (string s in files)
            {
              
                File.Delete(s);

            }
        }
        else
        {
            Console.WriteLine("Source path does not exist!");
        }


        return;
    }
   
}

[Serializable]
public class PlayerData
{
    public string zoneName;
    public float[] loc;
    public float[] rot;
    public SerializableStatsController playerStats;
    public SerializableJournalController playerJournal;
    public SerializableQuestController playerQuests;

    public PlayerData(GameObject player)
    {
        Transform playerTrans = player.GetComponent<Transform>();
        loc = new float[3];
        loc[0] = playerTrans.position.x;
        loc[1] = playerTrans.position.y;
        loc[2] = playerTrans.position.z;
        
        rot = new float[4];
        rot[0] = playerTrans.rotation.x;
        rot[1] = playerTrans.rotation.y;
        rot[2] = playerTrans.rotation.z;
        rot[3] = playerTrans.rotation.w;

        playerStats = new SerializableStatsController(player.GetComponent<StatsController>());
        playerJournal = new SerializableJournalController(player.GetComponent<JournalController>());
        playerQuests = new SerializableQuestController(player.GetComponent<QuestController>());

        zoneName = player.GetComponent<StatsController>().zoneName;

    }
}
[Serializable]
public class ZoneData
{//NPC TRANSFORMS
    public List<String> NPCSTransformNames = new List<String>();
    public List<float> NPCSPositionX = new List<float>();
    public List<float> NPCSPositionY = new List<float>();
    public List<float> NPCSPositionZ = new List<float>();

    public List<float> NPCSRotationX = new List<float>();
    public List<float> NPCSRotationY = new List<float>();
    public List<float> NPCSRotationZ = new List<float>();
    public List<float> NPCSRotationW = new List<float>();

    //TODO GROUND ITEMS
    public List<String> ItemTransformNames = new List<String>();
    public List<float> ItemPositionX = new List<float>();
    public List<float> ItemPositionY = new List<float>();
    public List<float> ItemPositionZ = new List<float>();
                       
    public List<float> ItemRotationX = new List<float>();
    public List<float> ItemRotationY = new List<float>();
    public List<float> ItemRotationZ = new List<float>();
    public List<float> ItemRotationW = new List<float>();
    //NPC DIALOGUE CONTROLLERS
    public List<string> NPCDialogueNames = new List<String>();
    public List<SerializableNPCDialogueController> NPCDialogueControllers = new List<SerializableNPCDialogueController>();




    public ZoneData(Scene scene, GameObject player)
    {

        
        foreach(GameObject rootObjects in scene.GetRootGameObjects())
        {
            foreach (NPC npc in rootObjects.GetComponentsInChildren<NPC>())
            {
               
               NPCSTransformNames.Add(npc.gameObject.name); //getting npc transform names
              
                NPCSPositionX.Add(npc.gameObject.transform.position.x);
                Debug.Log($"Saving {npc.gameObject.name}'s x position to {npc.gameObject.transform.position.x}");
               NPCSPositionY.Add(npc.gameObject.transform.position.y);
               NPCSPositionZ.Add(npc.gameObject.transform.position.z);
                NPCSRotationX.Add(npc.gameObject.transform.rotation.x);
                NPCSRotationY.Add(npc.gameObject.transform.rotation.y);
                NPCSRotationZ.Add(npc.gameObject.transform.rotation.z);
                NPCSRotationW.Add(npc.gameObject.transform.rotation.w);

                if(npc.gameObject.GetComponent<NPCDialogueController>() != null)
                {
                    NPCDialogueNames.Add(npc.gameObject.name);
                    NPCDialogueControllers.Add(new SerializableNPCDialogueController(npc.gameObject.GetComponent<NPCDialogueController>()));
                }

              
            }
            

            foreach(Item item in rootObjects.GetComponentsInChildren<Item>())
            {


            }
            
        }
    }

}
