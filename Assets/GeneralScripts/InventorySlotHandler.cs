using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlotHandler : MonoBehaviour, IDropHandler
{
    
    public GameObject originalItem;

    public GameObject item
    {
        get
        {
            if (transform.childCount > 0)
            {
              
                    return transform.GetChild(0).gameObject;
             

            }
            return null;
        }

    }

    public void OnDrop(PointerEventData eventData)
    {
        if (ItemDragController.itemBeingDragged == null)
        {
            return;
        }
        if (!item)
        {
            ItemDragController.itemBeingDragged.transform.SetParent(transform);
            ItemDragController.itemBeingDragged.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            ItemDragController.itemBeingDragged.GetComponent<RectTransform>().localScale = new Vector3(.9f, .9f, .9f);
        }
        else
        {
            originalItem = item;
            
                originalItem.transform.SetParent(ItemDragController.itemBeingDragged.transform.parent);
                originalItem.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);

                ItemDragController.itemBeingDragged.transform.SetParent(transform);
                ItemDragController.itemBeingDragged.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);

            
            


        }

    }
}
