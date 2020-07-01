using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
   
    public GameObject[] slots = new GameObject[30];

    // Start is called before the first frame update
   

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
    
}
