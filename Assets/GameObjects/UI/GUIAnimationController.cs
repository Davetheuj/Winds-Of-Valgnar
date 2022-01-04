using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GUIAnimationController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite originalSprite;
    public Sprite hoverSprite;
    public GameObject toShowOnClick;
    public Image image;
    public GameObject originalText;
    public GameObject hoverText;

    public void OnPointerClick(PointerEventData eventData)
    {
     
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.sprite = hoverSprite;
        originalText.SetActive(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.sprite = originalSprite;
        originalText.SetActive(true);
    }

    public void Start()
    {
        image = gameObject.GetComponent < Image > ();
    }
}
