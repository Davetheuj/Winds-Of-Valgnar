using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FrameRateShower : MonoBehaviour
{

    public TMP_Text frameText;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;
        if (time > .5f)
        {
            frameText.text = "FPS: " + (int)(1.0f / Time.deltaTime);
            time = 0;
        }

        
    }
}
