using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{

    public Light lightSource;
    public Material skyboxMaterial;
   

    public Vector4 dayColor;
    public Vector4 sunriseColor;
    public Vector4 sunsetColor;
    public Vector4 nightColor;
    public Vector4 currentColor;

    private Vector4 targetColor;

    public float sunriseTime = 5.5f;
    public float sunsetTime = 20.5f;
    public float transitionModifier;
    public float rayleighDuration = .5f;

    public float ingameTime; //hours

  
    public float daySpeed = 1f; //dayspeed of 1 means 24 seconds in a day, .5 = 48 etc

    public bool isPhaseModified = true;
    public float phaseModifier; //greater than 0 for shorter nights

    // Start is called before the first frame update
    void Start()
    {
        lightSource.transform.localEulerAngles = new Vector3(-45, -90, -90);
        
    }

    // Update is called once per frame
    void Update()
    {
        ingameTime += Time.deltaTime * daySpeed;
        if(ingameTime > 24f)
        {
            ingameTime = 0f;
        }
        if(ingameTime < sunriseTime || ingameTime > sunsetTime + rayleighDuration)
        {
            targetColor = nightColor;
            lightSource.intensity = Mathf.Lerp(lightSource.intensity, .1f, .05f);
            if (!isPhaseModified)
            {
                isPhaseModified = true;
                daySpeed = daySpeed * phaseModifier;
            }
            
        }
        else if(ingameTime >sunriseTime + rayleighDuration && ingameTime < sunsetTime - rayleighDuration)
        {
            targetColor = dayColor;
            lightSource.intensity = Mathf.Lerp(lightSource.intensity, 1.1f, .05f);

        }
        else if(ingameTime >sunriseTime && ingameTime < sunriseTime + rayleighDuration)
        {
            targetColor = sunriseColor;
            lightSource.intensity = Mathf.Lerp(lightSource.intensity, .65f, .05f);

            if (isPhaseModified)
            {
                isPhaseModified = false;
                daySpeed = daySpeed / phaseModifier;
            }



        }
        else
        {
            targetColor = sunsetColor;
            lightSource.intensity = Mathf.Lerp(lightSource.intensity, .8f, .05f);


        }

        currentColor = Vector4.Lerp(currentColor, targetColor, Time.deltaTime * transitionModifier);

        skyboxMaterial.SetColor("_Tint", new Color(currentColor.x, currentColor.y, currentColor.z, currentColor.w));
        lightSource.transform.Rotate(new Vector3(0, Time.deltaTime * daySpeed * (360 / 24), 0));






    }
}
