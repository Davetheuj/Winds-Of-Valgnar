using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InterfaceController : MonoBehaviour
{
    public GameObject InventoryPanel;
    public GameObject StatsPanel;
    public GameObject AbilitiesPanel;
    public GameObject JournalPanel;
    public GameObject EquipmentPanel;

    public GameObject baseItemInfoPanel;
    public GameObject inventoryGrid;

    public void Start()
    {
      
    }

    public void InventoryToggle()
    {
        InventoryPanel.SetActive(!InventoryPanel.activeSelf);
        try
        {
            if (ItemInfo.CurrentElement.transform.parent.parent.gameObject == inventoryGrid)
            {
                baseItemInfoPanel.SetActive(false);
            }
        }
        catch (MissingReferenceException )
        {

        }
    }
    public void StatsToggle()
    {
        StatsPanel.SetActive(!StatsPanel.activeSelf);
    }
    public void AbilitiesToggle()
    {
        AbilitiesPanel.SetActive(!AbilitiesPanel.activeSelf);
    }
    public void JournalToggle()
    {
       JournalPanel.SetActive(!JournalPanel.activeSelf);
    }
    public void EquipmentToggle()
    {
       EquipmentPanel.SetActive(!EquipmentPanel.activeSelf);
        try
        {
            if (ItemInfo.CurrentElement.transform.parent.parent.parent.parent.gameObject == EquipmentPanel)
            {
                baseItemInfoPanel.SetActive(false);
            }
        }
        catch (MissingReferenceException)
        {

        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            InventoryToggle();
        }else if (Input.GetKeyDown(KeyCode.B))
        {
            AbilitiesToggle();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
           EquipmentToggle();
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            JournalToggle();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            StatsToggle();
        }
    }

  
   
}
