using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class AbilityInfo : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField]
    private string abilityName;
    [SerializeField]
    private string infoText;

    private float xVar;
    private float yVar;

    private GameObject baseAbilityInfoPanel;
    private TMP_Text abilityNameText;
    private TMP_Text abilityInfoText;
    

    public void Start()
    {
        baseAbilityInfoPanel = GameObject.Find("GUI").GetComponent<InterfaceController>().abilityQuickHoverPanel;
        abilityNameText = baseAbilityInfoPanel.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<TMP_Text>();
        abilityInfoText = baseAbilityInfoPanel.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<TMP_Text>();

    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        

        abilityNameText.text = abilityName;
        abilityInfoText.text = infoText;
     

        
        baseAbilityInfoPanel.SetActive(true);
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

        baseAbilityInfoPanel.GetComponent<RectTransform>().position = Input.mousePosition + new Vector3(Screen.width / xVar, Screen.height / yVar, 0);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        baseAbilityInfoPanel.SetActive(false);

    }
}
