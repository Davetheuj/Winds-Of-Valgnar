using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotHandler : MonoBehaviour, IDropHandler
{
    //THIS CLASS IS FOR ABILITIES, FOR OTHER SLOT HANDLERS LOOK FOR SPECIFIC NAMES, LIKE INVENTORYSLOTHANDLER
    public GameObject originalItem;
    
   public GameObject item
    {
        get
        {
            if(transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;

            }
            return null;
        }

    }

    public void OnDrop(PointerEventData eventData)
    {
        if(AbilityDragController.itemBeingDragged == null)
        {
            return;
        }
        if (!item)
        {
            AbilityDragController.itemBeingDragged.transform.SetParent(transform);
            AbilityDragController.itemBeingDragged.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            AbilityDragController.itemBeingDragged.GetComponent<RectTransform>().localScale = new Vector3(.9f, .9f, .9f);
        }
        else
        {
            originalItem = item;
            if (AbilityDragController.itemBeingDragged.transform.parent.parent == GameObject.Find("AbilityBar").transform && transform.parent == GameObject.Find("AbilityBar").transform){
               originalItem.transform.SetParent(AbilityDragController.itemBeingDragged.transform.parent);
               originalItem.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);

                AbilityDragController.itemBeingDragged.transform.SetParent(transform);
                AbilityDragController.itemBeingDragged.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                
            }
            else if (AbilityDragController.itemBeingDragged.transform.parent.parent == GameObject.Find("AbilityGrid").transform && transform.parent == GameObject.Find("AbilityGrid").transform)
            {
                return;
            }

            else
            {
                AbilityDragController.itemBeingDragged.transform.SetParent(transform);
                AbilityDragController.itemBeingDragged.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                Destroy(originalItem);
            }
           
            

        }
        
    }
}
