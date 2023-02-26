using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    Light light2;

    [SerializeField]
    private float maxIntensity;
    [SerializeField]
    private float minIntensity;
    [SerializeField]
    private float intensityRange;
    [SerializeField]
    private float intensityLerpSpeed;
    [SerializeField]
    private float minTimeForChange;

    private float time;


    private bool ascending = false;
    private float currentIntensity;

    // Start is called before the first frame update
    void Start()
    {
        light2 = GetComponent<Light>();
        currentIntensity = light2.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (ascending)
        {
            currentIntensity += intensityLerpSpeed * Time.deltaTime;
            if ((currentIntensity + intensityRange / 2) > maxIntensity)
            {
                ascending = false;
            }
        }
        else
        {
            currentIntensity -= intensityLerpSpeed * Time.deltaTime;
            if ((currentIntensity - intensityRange / 2) < minIntensity)
            {
                ascending = true;
            }
        }

        if (time >= minTimeForChange)
        {
            light2.intensity = Random.Range(currentIntensity - (intensityRange / 2), currentIntensity + (intensityRange / 2));
            time = 0;
        }

    }
}