using Assets.GameObjects.Characters.Player.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{
    public GameObject InventoryPanel;
    public GameObject StatsPanel;
    public StatsPanelController statsPanelController;
    public GameObject AbilitiesPanel;
    public GameObject JournalPanel;
    public GameObject EquipmentPanel;
    public GameObject WorldMapPanel;
    public GameObject SettingsPanel;
    public GameObject DevCanvas;
    public GameObject MenuPanel;

    
    public GameObject inventoryGrid;

    public GameObject playerInformationCanvas;

    public GameObject itemQuickHoverPanel;

    public GameObject player;

    //SettingsPanel
    public Slider inputSensitivitySlider;
    public Slider masterAudioSlider;

    public void Start()
    {
        
    }
    public void PlayerInformationToggle()
    {
        statsPanelController.UpdateStatsUI();
        itemQuickHoverPanel.SetActive(false);
        playerInformationCanvas.SetActive(!playerInformationCanvas.activeSelf);
        

    }

    public void InventoryToggle()
    {
        InventoryPanel.SetActive(!InventoryPanel.activeSelf);
        try
        {
            if (ItemInfo.CurrentElement.transform.parent.parent.gameObject == inventoryGrid)
            {
                //baseItemInfoPanel.SetActive(false);
            }
        }
        catch (MissingReferenceException )
        {

        }
    }
    public void DevToggle()
    {
        DevCanvas.SetActive(!DevCanvas.activeSelf);
    }
    public void StatsToggle()
    {
        statsPanelController.UpdateStatsUI();
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
    public void MapToggle()
    {
        WorldMapPanel.SetActive(!WorldMapPanel.activeSelf);
    }
    public void EquipmentToggle()
    {
       EquipmentPanel.SetActive(!EquipmentPanel.activeSelf);
        try
        {
            if (ItemInfo.CurrentElement.transform.parent.parent.parent.parent.gameObject == EquipmentPanel)
            {
                //baseItemInfoPanel.SetActive(false);
            }
        }
        catch (MissingReferenceException)
        {
            //Debug.Log("missingReferenceException in InterfaceController at EquipmentToggle()");
        }
        catch (NullReferenceException)
        {
            //Debug.Log("NullReferenceException in InterfaceController at EquipmentToggle()");
        }
    }

    public void SettingsToggle()
    {
        SettingsPanel.SetActive(!SettingsPanel.activeSelf);
    }

    public void MenuToggle()
    {
        MenuPanel.SetActive(!MenuPanel.activeSelf);
    }

    public void SaveSettingsAndReturnToMenu()
    {
        SaveSettings();
        SettingsPanel.SetActive(false);
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
        else if (Input.GetKeyDown(KeyCode.M))
        {
            MapToggle();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuToggle();

        }
        else if (Input.GetKeyDown(KeyCode.Tilde))
        {
            DevToggle();
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            PlayerInformationToggle();
        }
    }

    public void SaveSettings()
    {
        Debug.Log($"Saving player settings from Interface Controller  - passing argument of {player}");
        WoVBinarySerializer.SavePlayerSettings(player);
    }
    
    public void CancelSettings()
    {

    }

    public void ApplySettings()
    {
        Debug.Log("Applying Settings");
        PlayerSettings settings = player.GetComponent<PlayerSettings>();

        float masterAudioVolume = masterAudioSlider.value * 100;
        player.GetComponent<AudioClipController>().mixer.SetFloat("MasterVolume", masterAudioVolume);
        settings.masterAudioVolume = masterAudioVolume;

        float inputSensitivity = inputSensitivitySlider.value * 100;
        player.GetComponent<PlayerController>().inputSensitivity = inputSensitivity;
        settings.inputSensitivity = inputSensitivity;

    }

    public void UpdateSettingsUIFromLoad(PlayerSettings playerSettings)
    {
        Debug.Log("Updating Settings UI");
        masterAudioSlider.value = playerSettings.masterAudioVolume / 100;

        inputSensitivitySlider.value = playerSettings.inputSensitivity / 100;

        ApplySettings();

    }

    public void CloseGame()
    {
        Application.Quit();
    }

  
   
}
