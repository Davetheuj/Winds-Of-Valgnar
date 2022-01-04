using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
   

    public static GameObject itemBeingDragged;
    

    Vector3 startPosition;
   
    public void OnBeginDrag(PointerEventData eventData)
    {
      
        itemBeingDragged = gameObject;
        startPosition = transform.position;
       
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

      
        GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);


    }

   
}
