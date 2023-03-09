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
    private float minTimeForChange;

    private float time;



    // Start is called before the first frame update
    void Start()
    {
        light2 = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

   

        if (time >= minTimeForChange)
        {
            light2.intensity = Random.Range(minIntensity, maxIntensity);
            time = 0;
        }

    }
}