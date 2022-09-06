using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TipController : MonoBehaviour
{

    
    public float timer = 0;
    public float tipVisibleTime = 5;
    public TMP_Text tipText;

    public void Start()
    {
        tipText = transform.Find("TipText").GetComponent<TMP_Text>();
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if(timer >= tipVisibleTime)
        {
           gameObject.SetActive(false);
        }
    }



}
