using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[Serializable]
public class SerializableJournalController
{
    public List<JournalEntry> entries = new List<JournalEntry>();
    public int entryCounter;
    
    public SerializableJournalController(JournalController loadedJournal)
    {
        entries = loadedJournal.entries;
        entryCounter = loadedJournal.entryCounter;
    }

}
