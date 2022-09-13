using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TipController : MonoBehaviour
{

    
    public float timer = 0;
    public float tipVisibleTime = 5;
    public TMP_Text tipText;
    public GameObject tipPanel;

    public void Start()
    {
        //tipText = transform.Find("TipText").GetComponent<TMP_Text>();
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if(timer >= tipVisibleTime)
        {
           tipPanel.SetActive(false);
        }
    }

    public void ShowTip(string text, float timer)
    {
        tipText.text = text;
        this.timer = 0;
        this.tipVisibleTime = timer;
        tipPanel.SetActive(true);
    }



}
