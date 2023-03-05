using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemContainerController : MonoBehaviour
{
    
    public ItemContainer container; //The container that is being currently interacted with
    [SerializeField]
    private TMP_Text panelTitle;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject containerPanel;

    public List<GameObject> slots = new List<GameObject>();

    public GameObject slotHolder;
    
    public float containerDisappearDistance = 3;

    private bool isShowing;

        private void Start()
        {
            foreach (Transform trans in slotHolder.transform)
            {
                slots.Add(trans.gameObject);
            }
        }
    

    // Update is called once per frame
    void Update()
    {
        if (isShowing)
        {
            if ((player.transform.position - container.gameObject.transform.position).magnitude > containerDisappearDistance)
            {
                CloseContainerPanel();
            }
        }
    }

    
    public void CloseContainerPanel()
    {
        foreach(GameObject slot in slots)
        {
            if(slot.transform.childCount > 0)
            {
                Destroy(slot.transform.GetChild(0).gameObject);
            }
        }
        isShowing = false;
        containerPanel.SetActive(false);
        player.GetComponent<PlayerController>().ToggleMouseRestriction();
    }

    public void UpdateAndShowItemContainerPanel(ItemContainer container)
    {
        this.container = container;
        panelTitle.text = container.containerName;

        if ((player.transform.position - container.gameObject.transform.position).magnitude > containerDisappearDistance)
        {
            return;
        }
        Debug.Log("setting container panel active");

        foreach(GameObject item in container.containerItems)
        {
            var containerSlot = GetFirstEmptySlot();
            if (containerSlot == null)
            {
                Debug.Log("Container is full, could not populate entirely (ItemContainerController.cs)");
                return;
            }
            Instantiate(item, containerSlot.transform);
        }
        containerPanel.SetActive(true);
        isShowing = true;
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

    public void RemoveItemFromContainer(int index)
    {
        container.RemoveContainerItem(index);
        foreach (GameObject slot in slots)
        {
            if (slot.transform.childCount > 0)
            {
                slot.transform.GetChild(0).parent = player.transform;
            }
        }
        foreach (GameObject item in container.containerItems)
        {
            var containerSlot = GetFirstEmptySlot();
            if (containerSlot == null)
            {
                Debug.Log("Container is full, could not populate entirely (ItemContainerController.cs)");
                return;
            }
            Instantiate(item, containerSlot.transform);
        }

    }

}
