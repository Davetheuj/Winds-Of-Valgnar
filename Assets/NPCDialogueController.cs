using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogueController : MonoBehaviour
{
    public List<string> queryLines1;
    public List<string> responseLines1;
    public List<string> queryLines2;
    public List<string> responseLines2;
    public List<string> queryLines3;
    public List<string> responseLines3;
    public List<string> queryLines4;
    public List<string> responseLines4;
    public List<string> queryLines5;
    public List<string> responseLines5;
    public List<string> queryLines6;
    public List<string> responseLines6;
    public List<string> queryLines7;
    public List<string> responseLines7;
    public List<string> queryLines8;
    public List<string> responseLines8;
   
    public List<Quest> NPCQuests;
    public List<int> questLineCounters;
    
    public List<int> dialogueLineCounters;

    public string defaultResponse;


    public void SetControllerFromLoad(SerializableNPCDialogueController dialogueController)
    {
      
        dialogueLineCounters = dialogueController.dialogueLineCounters;
        
    }

}
