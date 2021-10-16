using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour
{
    //Leave properties generic and set them using the editor...
    public string itemName;
    public bool isStackable;
    public int quantity;
    public GameObject inventoryButtonPrefab;

    public GameObject toolTip;
    public TMP_Text toolTipText;

    

   
    
}
