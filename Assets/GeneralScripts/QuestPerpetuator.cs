using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuestPerpetuator : MonoBehaviour
{
    public string questName;
    public int dialogueLineCounter;
    public int dialogueLineIndex;
    public string journalEntry;
    public List<string> consoleEntries = new List<string>();
    public int minStepInQuest;
    public int maxStepInQuest;
    public string nonProgressText;
    
}
