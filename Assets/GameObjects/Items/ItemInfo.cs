using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;


//Item Info is used on the inventory and equipment buttons as opposed to "Item" which is used on the model prefabs.
public class ItemInfo : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject modelPrefab;
    public string itemName;
    public string weight;
    public string info;

    public GameObject baseItemInfoPanel;
    public TMP_Text baseItemNameText;
    public TMP_Text baseItemInfoText;
    public TMP_Text baseItemWeightText;
    public TMP_Text baseItemUseText;

    private float xVar;
    private float yVar;

    public static GameObject CurrentElement;

    public static GameObject equipmentPanel;

    //public GameObject EquipmentHoverInfoPanel;

   

    private EquipmentController controller;




    public void Start()
    {
       
        baseItemInfoPanel = GameObject.Find("GUI").GetComponent<InterfaceController>().baseItemInfoPanel;
        baseItemNameText = baseItemInfoPanel.transform.Find("Name").GetComponent<TMP_Text>();
        baseItemInfoText = baseItemInfoPanel.transform.Find("Info").GetComponent<TMP_Text>();
        baseItemWeightText = baseItemInfoPanel.transform.Find("Weight").GetComponent<TMP_Text>();
        baseItemUseText = baseItemInfoPanel.transform.Find("ClickText").GetComponent<TMP_Text>();
        equipmentPanel = GameObject.Find("EquipmentPanel").gameObject;
        controller = GameObject.Find("Player").GetComponent<EquipmentController>();
    }








    public void OnPointerClick(PointerEventData eventData)
    {

        baseItemInfoPanel.SetActive(false);
        controller.equipmentHoverInfoPanel.SetActive(false);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("Item dropped"); //Destory item, instantiate the model prefab
          
            Instantiate(modelPrefab, GameObject.Find("Player").transform.position,gameObject.transform.rotation);
            Destroy(this.gameObject);
            return;
        }
        else
        {
            Equipment itemComponent = gameObject.GetComponent<Equipment>();
            if (itemComponent != null)
            {
               controller.EquipItem(this.gameObject);
            }
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        CurrentElement = this.gameObject;

        baseItemNameText.text = itemName;
        baseItemInfoText.text = info;
        baseItemWeightText.text = weight;
        if (gameObject.GetComponent<Equipment>())
        {
            baseItemUseText.text = "<Click> to equip";
            //Now doing the stuff for the equipment panel
           
               
                Equipment equipmentTemp = gameObject.GetComponent<Equipment>();
                controller.SetTextColor(equipmentTemp.modifierHitPoints, controller.hitpoints);
                controller.SetTextColor(equipmentTemp.modifierCharisma, controller.charisma);
                controller.SetTextColor(equipmentTemp.modifierDexterity, controller.dexterity);
                controller.SetTextColor(equipmentTemp.modifierIntelligence, controller.intelligence);
                controller.SetTextColor(equipmentTemp.modifierLuck, controller.luck);
                controller.SetTextColor(equipmentTemp.modifierMana, controller.mana);
                controller.SetTextColor(equipmentTemp.modifierResolve, controller.resolve);
                controller.SetTextColor(equipmentTemp.modifierSpirit, controller.spirit);
                controller.SetTextColor(equipmentTemp.modifierStrength, controller.strength);
                controller.SetTextColor(equipmentTemp.modifierWisdom, controller.wisdom);
                controller.SetTextColor(equipmentTemp.resistanceArmor, controller.armor);
                controller.SetTextColor(equipmentTemp.resistanceEarth, controller.earth);
                controller.SetTextColor(equipmentTemp.resistanceElectric, controller.electric);
                controller.SetTextColor(equipmentTemp.resistanceFire, controller.fire);
                controller.SetTextColor(equipmentTemp.resistanceHoly, controller.holy);
                controller.SetTextColor(equipmentTemp.resistanceVoid, controller.voidText);
                controller.SetTextColor(equipmentTemp.resistanceWater, controller.water);

                controller.equipmentHoverInfoPanel.SetActive(true);

        
        }
        else
        {
            baseItemUseText.text = "";
        }
        baseItemInfoPanel.SetActive(true);
        //baseItemInfoPanel.transform.SetParent(gameObject.transform.parent.parent.parent);
        if (Input.mousePosition.x < Screen.width / 2)
        {
            xVar = 25;

        }
        else
        {
            xVar = -25;
        }

        if ((Input.mousePosition.y < Screen.height / 2))
        {
            yVar = 10.4f;
        }
        else
        {
            yVar = -10.4f;
        }
        baseItemInfoPanel.GetComponent<RectTransform>().position = Input.mousePosition + new Vector3(Screen.width / xVar, Screen.height / yVar, 0);


       
       
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        baseItemInfoPanel.SetActive(false);
        controller.equipmentHoverInfoPanel.SetActive(false);
    }

   
    
}
