using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject slotHolder;
    public List<GameObject> slots = new List<GameObject>();
    public int coins;

    private void Start()
    {
        foreach(Transform trans in slotHolder.transform)
        {
            slots.Add(trans.gameObject);
        }
    }
    public GameObject GetFirstEmptySlot()
    {
        foreach(GameObject slot in slots)
        {
            if(slot.transform.childCount < 1)
            {
                return slot;
            }
        }
       
        return null; 
    }

    public GameObject FindObjectByNameContains(string contains)
    {
        foreach(GameObject slot in slots)
        {
            if(slot.transform.childCount >= 1)
            {
                if (slot.GetComponentInChildren<ItemInfo>().gameObject.name.Contains(contains))
                {
                    Debug.Log("Inventory contains item");
                    return slot.GetComponentInChildren<ItemInfo>().gameObject;
                }
            }
        }
        return null;

    }
    
}
