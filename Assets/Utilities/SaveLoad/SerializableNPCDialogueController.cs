using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[Serializable]
public class SerializableNPCDialogueController 
{
    
    

    public List<int> dialogueLineCounters;

    public SerializableNPCDialogueController(NPCDialogueController dialogueController)
    {
        
        dialogueLineCounters = dialogueController.dialogueLineCounters;
       

    }

}
