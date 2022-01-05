using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialEmissionIntensityPingPong : MonoBehaviour
{
    private float emissionIntensity;
    public Material emissiveMaterial;
    public float maxIntensity;
    public float minIntensity;
    private bool isRising;
    public float lerpSpeedMultiplier = 1; //You can adjust this in the editor just don't make it 0 or there wont be any changes.

    // Update is called once per frame
    void Update()
    {
        if (isRising) 
        {
            emissiveMaterial.SetFloat("Emissive Intensity", Mathf.Lerp(emissionIntensity, maxIntensity, Time.deltaTime * lerpSpeedMultiplier));
        }
        else
        {
            emissiveMaterial.SetFloat("Emissive Intensity", Mathf.Lerp(emissionIntensity, minIntensity, Time.deltaTime * lerpSpeedMultiplier));
        }
        if(emissionIntensity<-minIntensity && !isRising)
        {
            isRising = true;
        }
        if(emissionIntensity >= maxIntensity && isRising)
        {
            isRising = false;
        }
        
    }
}
