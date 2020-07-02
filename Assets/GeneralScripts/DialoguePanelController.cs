using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DialoguePanelController : MonoBehaviour
{
    public TMP_Text responseText;
    public GameObject queryPanel;
    public GameObject queryPrefab;
    public GameObject newQuery;
    public GameObject NPC;
    public Transform player;
    public GameObject questHolder;
    public TMP_Text NPCName;
    public QuestController questController;
    public JournalController journalController;

    public ConsoleManager consoleManager;
   
   
    public List<GameObject> displayedQueries;
    public GameObject dialoguePanel;
    public bool isShowing;

    public float dialogueDisappearDistance;

    private float time;

    private string nonprogressString;
    private NPCDialogueController controller;
    public void UpdateAndShowDialoguePanel()
    {
        controller = NPC.GetComponent<NPCDialogueController>();
        NPCName.text = NPC.GetComponent<NPC>().npcName;

        responseText.text = controller.defaultResponse;
        if ((player.position - NPC.transform.position).magnitude > dialogueDisappearDistance)
        {
            return;
        }
            int count = queryPanel.transform.childCount;
        int i = 0;
        while (i < count)
        {
            Destroy(queryPanel.transform.GetChild(i).gameObject); //clearing all the queries from the previous NPC
            i++;
        }

        // displayedQueries = new List<GameObject>();
        try
        {
            queryPrefab.GetComponentInChildren<TMP_Text>().text = controller.queryLines1[controller.dialogueLineCounters[0]];
            newQuery = Instantiate(queryPrefab, queryPanel.transform);
        }
        catch (Exception e)
        {

        }
        try
        {
            queryPrefab.GetComponentInChildren<TMP_Text>().text = controller.queryLines2[controller.dialogueLineCounters[1]];
            newQuery = Instantiate(queryPrefab, queryPanel.transform);
        }
        catch (Exception e)
        {

        }

        try
        {
            queryPrefab.GetComponentInChildren<TMP_Text>().text = controller.queryLines3[controller.dialogueLineCounters[2]];
            newQuery = Instantiate(queryPrefab, queryPanel.transform);
        }
        catch (Exception e)
        {

        }
        try
        {
            queryPrefab.GetComponentInChildren<TMP_Text>().text = controller.queryLines4[controller.dialogueLineCounters[3]];
            newQuery = Instantiate(queryPrefab, queryPanel.transform);
        }
        catch (Exception e)
        {

        }
        try
        {
            queryPrefab.GetComponentInChildren<TMP_Text>().text = controller.queryLines5[controller.dialogueLineCounters[4]];
            newQuery = Instantiate(queryPrefab, queryPanel.transform);
        }
        catch (Exception e)
        {

        }
        try
        {
            queryPrefab.GetComponentInChildren<TMP_Text>().text = controller.queryLines6[controller.dialogueLineCounters[5]];
            newQuery = Instantiate(queryPrefab, queryPanel.transform);
        }
        catch (Exception e)
        {

        }
        try
        {
            queryPrefab.GetComponentInChildren<TMP_Text>().text = controller.queryLines7[controller.dialogueLineCounters[6]];
            newQuery = Instantiate(queryPrefab, queryPanel.transform);
        }
        catch (Exception e)
        {

        }
        try
        {
            queryPrefab.GetComponentInChildren<TMP_Text>().text = controller.queryLines8[controller.dialogueLineCounters[7]];
            newQuery = Instantiate(queryPrefab, queryPanel.transform);
        }
        catch (Exception e)
        {

        }




        dialoguePanel.SetActive(true);
       
        isShowing = true;
     
    }

    public void Update()
    {
        if (isShowing)
        {

            if ((player.position - NPC.transform.position).magnitude > dialogueDisappearDistance)
            {
                isShowing = false;
                dialoguePanel.SetActive(false);

            }

        }
    }

    public void SetResponseText(int responseIndex, TMP_Text newQueryText)
    {
        switch (responseIndex)
        {
            case 0:
                if (!CheckForQuest(0, controller.dialogueLineCounters[0]))
                {
                    SetResponseTextProgressDecline();
                    return;
                }
                responseText.text = controller.responseLines1[controller.dialogueLineCounters[0]];
                if(controller.dialogueLineCounters[0] < controller.queryLines1.Count-1)
                {
                   
                    controller.dialogueLineCounters[0]++;
                    newQueryText.text = controller.queryLines1[controller.dialogueLineCounters[0]];
                   
                }
               
                break;
            case 1:
                if (!CheckForQuest(1, controller.dialogueLineCounters[1]))
                {
                    SetResponseTextProgressDecline();
                    return;
                }
                responseText.text = controller.responseLines2[controller.dialogueLineCounters[1]];
                if (controller.dialogueLineCounters[1] < controller.queryLines2.Count - 1)
                {

                    controller.dialogueLineCounters[1]++;
                    newQueryText.text = controller.queryLines2[controller.dialogueLineCounters[1]];

                }
                break;
            case 2:
                if (!CheckForQuest(2, controller.dialogueLineCounters[2]))
                {
                    SetResponseTextProgressDecline();
                    return;
                }
                responseText.text = controller.responseLines3[controller.dialogueLineCounters[2]];
                if (controller.dialogueLineCounters[2] < controller.queryLines3.Count - 1)
                {

                    controller.dialogueLineCounters[2]++;
                    newQueryText.text = controller.queryLines3[controller.dialogueLineCounters[2]];

                }
                break;
            case 3:
                if (!CheckForQuest(3, controller.dialogueLineCounters[3]))
                {
                    SetResponseTextProgressDecline();
                    return;
                }
                responseText.text = controller.responseLines4[controller.dialogueLineCounters[3]];
                if (controller.dialogueLineCounters[3] < controller.queryLines4.Count - 1)
                {

                    controller.dialogueLineCounters[3]++;
                    newQueryText.text = controller.queryLines4[controller.dialogueLineCounters[3]];

                }
                break;
            case 4:
                if (!CheckForQuest(4, controller.dialogueLineCounters[4]))
                {
                    SetResponseTextProgressDecline();
                    return;
                }
                responseText.text = controller.responseLines5[controller.dialogueLineCounters[4]];
                if (controller.dialogueLineCounters[4] < controller.queryLines5.Count - 1)
                {

                    controller.dialogueLineCounters[4]++;
                    newQueryText.text = controller.queryLines5[controller.dialogueLineCounters[4]];

                }
                break;
            case 5:
                if (!CheckForQuest(5, controller.dialogueLineCounters[5]))
                {
                    SetResponseTextProgressDecline();
                    return;
                }
                responseText.text = controller.responseLines6[controller.dialogueLineCounters[5]];
                if (controller.dialogueLineCounters[5] < controller.queryLines6.Count - 1)
                {

                    controller.dialogueLineCounters[5]++;
                    newQueryText.text = controller.queryLines6[controller.dialogueLineCounters[5]];

                }
                break;
            case 6:
                if (!CheckForQuest(6, controller.dialogueLineCounters[6]))
                {
                    SetResponseTextProgressDecline();
                    return;
                }
                responseText.text = controller.responseLines7[controller.dialogueLineCounters[6]];
                if (controller.dialogueLineCounters[6] < controller.queryLines7.Count - 1)
                {

                    controller.dialogueLineCounters[6]++;
                    newQueryText.text = controller.queryLines7[controller.dialogueLineCounters[6]];

                }
                break;
            case 7:
                if (!CheckForQuest(7, controller.dialogueLineCounters[7]))
                {
                    SetResponseTextProgressDecline();
                    return;
                }
                responseText.text = controller.responseLines8[controller.dialogueLineCounters[7]];
                if (controller.dialogueLineCounters[7] < controller.queryLines8.Count - 1)
                {

                    controller.dialogueLineCounters[7]++;
                    newQueryText.text = controller.queryLines8[controller.dialogueLineCounters[7]];

                }
                break;




        }

      
     
       
    }
    public bool CheckForQuest(int lineCounter, int lineIndex) //lineCounter is which dialogue series it's within, the index is the position
    {

        QuestPerpetuator[] questPerps = controller.gameObject.GetComponents<QuestPerpetuator>();
        if (controller.NPCQuests.Count <= 0)
        {
           
        }
       else if(controller.NPCQuests[lineCounter] != null && lineIndex == controller.questLineCounters[lineCounter])
        {
            if (!questController.CheckQuestRequirements(controller.NPCQuests[lineCounter]))
            {
                return false;
            }
            questController.AddQuest(controller.NPCQuests[lineCounter]);
            //Quest newQuest = new Quest(controller.NPCQuests[lineCounter]);
          
            journalController.CreateNewEntry(controller.NPCQuests[lineCounter].journalEntry1,0);
            //controller.NPCQuests[lineCounter] = null; 
           
            return true;
        }
        if (questPerps.Length <= 0)
        {
            return true;
        }
        foreach(QuestPerpetuator perp in questPerps)
        {
            if(perp.dialogueLineCounter == lineCounter && perp.dialogueLineIndex == lineIndex)
            {
                Debug.Log("Perp found");

                foreach(Quest quest in player.gameObject.GetComponent<QuestController>().questList)
                {
                   
                    if (quest.questName == perp.questName)
                    {
                        Debug.Log("Quest has been accepted previously");
                        if ((quest.currentStep >= perp.minStepInQuest) && (quest.currentStep <= perp.maxStepInQuest))
                        {
                            Debug.Log("Correct step");
                            if (perp.journalEntry != "")
                            {
                                journalController.CreateNewEntry(perp.journalEntry, 0);
                            }
                            if(perp.consoleEntries.Count>0)
                            {
                                foreach(string entry in perp.consoleEntries)
                                {
                                    consoleManager.AddConsoleMessage1(entry);
                                }
                            }
                            quest.currentStep += 1;
                            questController.CheckForCompletion(quest);
                            return true;
                        }
                        else
                        {
                            Debug.Log("Displaying nonprogress string");
                            nonprogressString = perp.nonProgressText;
                            return false;
                        }
                       
                    }
                }
                break;
            }
        }
        return true;


    }

    private void SetResponseTextProgressDecline()
    {
        if (nonprogressString != null || nonprogressString != "")
        {
            responseText.text = nonprogressString;
        }
        else
        {
            responseText.text = "I have nothing more to say about that for now.";
        }

    }


}
