using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour
{
    public GameObject slotHolder;
    public List<GameObject> slots = new List<GameObject>();

    private void Start()
    {
        foreach (Transform trans in slotHolder.transform)
        {
            slots.Add(trans.gameObject);
        }
    }
    public GameObject GetFirstEmptySlot()
    {
        foreach (GameObject slot in slots)
        {
            if (slot.transform.childCount < 1)
            {
                return slot;
            }
        }

        return null;
    }
}
