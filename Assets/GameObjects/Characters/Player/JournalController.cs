using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class JournalController : MonoBehaviour
{

    public List<JournalEntry> entries = new List<JournalEntry>();
    public int entryCounter;
    public TMP_Text journalPage;
    public Button forwardButton;
    public Button backButton;
    public TMP_Text pageCounter;
    public ConsoleManager console;
    public ErrorScript error;

    /// <summary>
    /// Creates a new journal entry
    /// </summary>
    /// <param name="entryText">the text to be displayed</param>
    /// <param name="broadcast">if 0 creates an update in console</param>
    public void CreateNewEntry(string entryText, int broadcast)
    {
        entries.Add(new JournalEntry(entryText));
        entryCounter = entries.Count-1;
        journalPage.text = entries[entryCounter].entryDate + "\n" + entries[entryCounter].entry;
        CheckAvailableButtons();
        pageCounter.text = "" + (entryCounter + 1);

        //error.SetErrorText("New Journal Entry!",4f);
        if (broadcast == 0)
        {
            console.AddConsoleMessage1("You have a new journal entry.");
        }
    }

    public void TurnPageForward()
    {
        forwardButton.enabled = true;
        if (entryCounter+1 >= entries.Count)
        {
            forwardButton.enabled = false;
            return;
        }
        entryCounter++;
        journalPage.text = entries[entryCounter].entryDate + "\n" + entries[entryCounter].entry;
        CheckAvailableButtons();
        pageCounter.text = ""+(entryCounter + 1);
    }

    public void TurnPageBack()
    {
        backButton.enabled = true;
        if (entryCounter  <= 0)
        {
            backButton.enabled = false;
            return;
        }
        entryCounter--;
        journalPage.text = entries[entryCounter].entryDate + "\n" + entries[entryCounter].entry;

        CheckAvailableButtons();
        pageCounter.text = "" + (entryCounter + 1);

    }
    public void CheckAvailableButtons()
    {
        if (entryCounter + 1 <= 0)
        {
            backButton.enabled = false;
        }
        else
        {
            backButton.enabled = true;
        }
        if (entryCounter + 1 >= entries.Count)
        {
            forwardButton.enabled = false;
        }
        else
        {
            forwardButton.enabled = true;
        }

    }


    public void SetJournalFromLoad(SerializableJournalController loadedJournal)
    {
        entries = loadedJournal.entries;
        entryCounter = loadedJournal.entryCounter;
    }
}

[Serializable]
public class JournalEntry
{
    public string entryDate;
    public string entry;

    public JournalEntry(string entryText)
    {
        this.entry = entryText;
        this.entryDate = $"{System.DateTime.Now.Day}/{System.DateTime.Now.Month}/{System.DateTime.Now.Year}\n{System.DateTime.Now.Hour}:{System.DateTime.Now.Minute}";
    }
}
