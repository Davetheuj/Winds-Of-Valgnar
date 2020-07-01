using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AbilityDragController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private GameObject abilityBookPanel;
    private GameObject abilityBarPanel;
    private GameObject empty;
    private GameObject current;

    public static GameObject itemBeingDragged;
    Transform startParent;

    Vector3 startPosition;
    void Start()
    {
        abilityBarPanel = GameObject.Find("AbilityBar");

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        abilityBookPanel = GameObject.Find("AbilityGrid");
        
        if (transform.parent.transform.parent.gameObject.Equals(abilityBookPanel))
        {
            Instantiate(gameObject, transform.parent);
        }
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    
        if (transform.parent.transform.parent == startParent && startParent != abilityBarPanel.transform)
        {
            Destroy(this.gameObject);


        }
        else
        {
            GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            gameObject.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        }
        if (abilityBookPanel == null)
        {
            return;
        }
        if (transform.parent.parent == abilityBookPanel.transform && startParent == abilityBookPanel.transform)
        {
            Destroy(this.gameObject);
        }
        if(transform.parent.parent == abilityBookPanel.transform && startParent == abilityBarPanel.transform)
        {
            Destroy(this.gameObject);
        }
        GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);


    }

    public bool isBookToBar()
    {
        if(startParent == abilityBookPanel.transform && transform.parent.parent == abilityBarPanel.transform)
        {
            return true;
        }


        return false;       
    }
}
