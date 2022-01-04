using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ConsoleManager : MonoBehaviour
{

    public TMP_Text consoleMessage1; //the prefab for a standard console message
    public TMP_Text consoleMessage2; //the prefab for a 2-line console message ( not formatted properly ) 
    public TMP_Text currentMessage;
 
    public GameObject consolePanel;



    public void AddConsoleMessage1(string richTextMessage)
    {
       
        currentMessage = GameObject.Instantiate(consoleMessage1, consolePanel.transform);
        currentMessage.SetText("[" + System.DateTime.Now.ToShortTimeString() + "]: " + richTextMessage);
    


    }

    public void AddConsoleMessage2(string richTextMessage)
    {

        currentMessage = GameObject.Instantiate(consoleMessage2, consolePanel.transform);
        currentMessage.SetText("[" + System.DateTime.Now.ToShortTimeString() + "]: " + richTextMessage);
        


    }

    void Start()
    {
       
            AddConsoleMessage1("Welcome to Valgnar!");


    }

}
