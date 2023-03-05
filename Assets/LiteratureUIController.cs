using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LiteratureUIController : MonoBehaviour
{

    private List<string> entries = new List<string>();
    private int entryCounter;
    public TMP_Text journalPage;
    public Button forwardButton;
    public Button backButton;
    public TMP_Text pageCounter;
    public ConsoleManager console;
    public ErrorScript error;
    
    [SerializeField]
    private GameObject literatureUIPanel;

    [SerializeField]
    private PlayerController playerControl;


    public void UpdateAndShowLiteratureUI(Literature literature)
    {
        foreach(MonoBehaviour boon in literature.boons)
        {
            
        }
        entries = literature.entries;
        entryCounter = 0;
        journalPage.text = entries[entryCounter];
        
        pageCounter.text = "" + (entryCounter + 1);

        CheckAvailableButtons();
        literatureUIPanel.SetActive(true);


    }

    public void TurnPageForward()
    {
        forwardButton.enabled = true;
        if (entryCounter + 1 >= entries.Count)
        {
            forwardButton.enabled = false;
            return;
        }
        entryCounter++;
        journalPage.text = entries[entryCounter];
        CheckAvailableButtons();
        pageCounter.text = "" + (entryCounter + 1);
    }

    public void TurnPageBack()
    {
        backButton.enabled = true;
        if (entryCounter <= 0)
        {
            backButton.enabled = false;
            return;
        }
        entryCounter--;
        journalPage.text = entries[entryCounter];

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

    public void CloseLiteraturePanel()
    {
        literatureUIPanel.SetActive(false);
    }
}
