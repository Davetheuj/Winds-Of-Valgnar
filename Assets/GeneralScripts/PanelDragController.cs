using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelDragController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Vector2 offset;

    public void OnBeginDrag(PointerEventData eventData)
    {
        offset = new Vector2(gameObject.GetComponent<RectTransform>().position.x - Input.mousePosition.x, gameObject.GetComponent<RectTransform>().position.y-Input.mousePosition.y);
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position+offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }
}
