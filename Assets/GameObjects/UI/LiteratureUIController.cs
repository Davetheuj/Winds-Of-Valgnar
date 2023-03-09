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

    [SerializeField]
    private AudioClipController audioClipController;


    public void UpdateAndShowLiteratureUI(Literature literature)
    {
        Debug.Log("Called UdpateAndShowLiteratureUI");
        foreach(GameObject boon in literature.boons)
        {
            Instantiate(boon);
            
        }
        literature.boons = new List<GameObject>(); //Removes old boons so they wont be given again

        entries = literature.entries;
        entryCounter = 0;
        journalPage.text = entries[entryCounter];
        
        pageCounter.text = "" + (entryCounter + 1);

        CheckAvailableButtons();
        literatureUIPanel.SetActive(true);
        audioClipController.PlayClip(null, 0, .9f, false, 0, false, true, true, "Effects");


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
