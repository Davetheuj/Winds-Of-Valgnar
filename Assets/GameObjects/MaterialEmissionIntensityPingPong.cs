using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialEmissionIntensityPingPong : MonoBehaviour
{
    private float emissionIntensity;
    private Material emissiveMaterial;
    public float maxIntensity;
    public float minIntensity;
    private bool isRising;
    public float transitionSpeed;

    private void Start()
    {
        emissiveMaterial = GetComponent<Renderer>().material;
            }
    // Update is called once per frame
    void Update()
    {
        if (isRising) 
        {
            emissionIntensity += transitionSpeed *Time.deltaTime;
           
        }
        else
        {
            emissionIntensity -= transitionSpeed * Time.deltaTime;
        }
        emissiveMaterial.SetFloat("_EmissiveIntensity", emissionIntensity);
        //Debug.Log($"Emissive Intensity: {emissiveMaterial.GetFloat("_EmissiveIntensity")}");
        if (emissionIntensity<=minIntensity && !isRising)
        {
            isRising = true;
        }
        if(emissionIntensity >= maxIntensity && isRising)
        {
            isRising = false;
        }

        UpdateEmissiveColorFromIntensityAndEmissiveColorLDR(emissiveMaterial);


    }

    public static void UpdateEmissiveColorFromIntensityAndEmissiveColorLDR(Material material)
    {
        const string kEmissiveColorLDR = "_EmissiveColorLDR";
        const string kEmissiveColor = "_EmissiveColor";
        const string kEmissiveIntensity = "_EmissiveIntensity";

        if (material.HasProperty(kEmissiveColorLDR) && material.HasProperty(kEmissiveIntensity) && material.HasProperty(kEmissiveColor))
        {
            // Important: The color picker for kEmissiveColorLDR is LDR and in sRGB color space but Unity don't perform any color space conversion in the color
            // picker BUT only when sending the color data to the shader... So as we are doing our own calculation here in C#, we must do the conversion ourselves.
            Color emissiveColorLDR = material.GetColor(kEmissiveColorLDR);
            Color emissiveColorLDRLinear = new Color(Mathf.GammaToLinearSpace(emissiveColorLDR.r), Mathf.GammaToLinearSpace(emissiveColorLDR.g), Mathf.GammaToLinearSpace(emissiveColorLDR.b));
            material.SetColor(kEmissiveColor, emissiveColorLDRLinear * material.GetFloat(kEmissiveIntensity));
        }
    }
}
