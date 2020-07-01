using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

using UnityEngine.UI;
public class TalkOptionHover : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    DialoguePanelController dialogueController;
    private Color oldColor;
    private List<GameObject> panels = new List<GameObject>();
    private GameObject queryPanel;

    public void OnPointerClick(PointerEventData eventData) 
    {
        
        foreach (TalkOptionHover t in queryPanel.GetComponentsInChildren<TalkOptionHover>())
        {
            panels.Add(t.gameObject);
        }
        int panelComparer = 0;
        foreach(GameObject obj in panels)
        {
            if (obj.Equals(this.gameObject))
            {
                dialogueController.SetResponseText(panelComparer, this.gameObject.GetComponentInChildren<TMP_Text>());
                break;
            }
            panelComparer++;
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        oldColor = this.gameObject.GetComponent<Image>().color;
        this.gameObject.GetComponent<Image>().color = new Color(168f / 255, 74f / 255, 50f / 255);
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
       
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       this.gameObject.GetComponent<Image>().color = oldColor;
        transform.localScale = new Vector3(1, 1, 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogueController = GameObject.Find("NPCTalkCanvas").GetComponent<DialoguePanelController>();
        queryPanel = GameObject.Find("QueryPanel");
           
    }

   
}
