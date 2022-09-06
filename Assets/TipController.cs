using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipController : MonoBehaviour
{

    public GameObject tipButton;
    private float timer = 0;
    public float tipVisibleTime = 10;
    
    public void Update()
    {
        timer += Time.deltaTime;
        if(timer >= tipVisibleTime)
        {
            tipButton.SetActive(false);
        }
    }

}
