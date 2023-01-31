using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{

    private JournalController journalController;
    private QuestController questController;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Quest quest = GetComponent<Quest>();

        if (quest == null)
        {
            return;
        }

        if (other.gameObject.name == "Player")
        {
            if (!player.GetComponent<QuestController>().CheckQuestRequirements(quest))
            {
                return;
            }
            player.GetComponent<QuestController>().AddQuest(quest);
            //Quest newQuest = new Quest(controller.NPCQuests[lineCounter]);

            player.GetComponent<JournalController>().CreateNewEntry(quest.journalEntry1, 0);

        }
        Destroy(this.gameObject);
    }
}
